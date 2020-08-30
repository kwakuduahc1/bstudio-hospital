using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinClinic.Model;
using WinClinic.Model.Records;
using WinClinic.Model.ViewModels;
using static WinClinic.DTOs.RandomStringGenerator;

namespace WinClinic.DTOs.Records
{
    public class RecordsHelper
    {
        readonly DataContext db;

        public RecordsHelper(DbContextOptions<DataContext> context) => db = new DataContext(context);

        /// <summary>
        /// Checks whether the given opd number of the patient already exists
        /// </summary>
        /// <param name="id">The index number, staff id or other unique identifier of the patient</param>
        /// <returns></returns>
        public Task<bool> CheckIDExists(string id) => Task.Run(async () => await db.Patients.AnyAsync(t => t.FolderID == id));

        /// <summary>
        /// Add patient attendance
        /// </summary>
        /// <param name="patient"></param>
        public void AddAttendance(int pid, string uname, string visit)
        {
            db.Add(new PatientAttendance
            {
                DateSeen = DateTime.Now,
                PatientsID = pid,
                UserName = uname,
                VisitType = visit,
                SessionName = RandomString(new Random().Next(6, 10)),
                IsActive = true,
            });
        }

        public async Task ClosePreviousesAsync(int pid)
        {
            var atts = await db.PatientAttendance.Where(x => x.PatientsID == pid && x.IsActive).ToListAsync();
            if (atts.Any())
                atts.ForEach(x =>
                {
                    x.IsActive = false;
                    x.DateClosed = DateTime.Now;
                    db.Entry(x).State = EntityState.Modified;
                });
        }
        /// <summary>
        /// Register new patient
        /// </summary>
        /// <param name="patient"></param>
        public void Register(Patients patient)
        {
            patient.DateAdded = DateTime.Now;
            db.Patients.Add(patient);
            AddAttendance(patient.PatientsID, patient.UserName, "Acute");
        }

        /// <summary>
        /// Save changes
        /// </summary>
        /// <returns></returns>
        public Task<int> Save() => Task.Run(async () => await db.SaveChangesAsync());

        /// <summary>
        /// Gets the list of patients
        /// </summary>
        /// <param name="num">The number to fetch</param>
        /// <param name="off">The number to skip or offset</param>
        /// <returns>List of patients</returns>
        public Task<List<Patients>> List(byte num, byte off) => Task.Run(async () => await db.Patients.OrderByDescending(x => x.DateAdded).Skip(off).Take(num).ToListAsync());

        /// <summary>
        ///  Gets the list of patients in a scheme
        /// </summary>
        /// <param name="id">The scheme id</param>
        /// <param name="num">The number to fetch</param>
        /// <param name="off">The number to skip or offset</param>
        /// <returns>List of patients based on scheme type</returns>
        public Task<List<Patients>> SchemeList(int id, byte num, byte off) => Task.Run(async () => await db.Patients.Where(x => x.PatientDetails.SchemesID == id).OrderByDescending(x => x.DateAdded).Skip(off).Take(num).ToListAsync());

        /// <summary>
        /// Find details about the patient using the registration ID 
        /// </summary>
        /// <param name="id">The Unique ID of the patient</param>
        /// <returns></returns>
        public Task<PatientsVm> Find(string id)
        {
            return Task.Run(async () => await db.Patients.Where(x => x.FolderID == id).SelectMany(x => x.PatientAttendance, (p, c) => new PatientsVm { PatientsID = c.PatientsID, DateOfBirth = p.DateOfBirth, FullName = p.FullName, Gender = p.Gender, MobileNumber = p.MobileNumber, OtherNames = p.OtherNames, PatientAttendanceID = c.PatientAttendanceID, Scheme = p.Schemes.Scheme, SchemesID = p.SchemesID, SessionName = c.SessionName, Surname = p.Surname, IsActive = c.IsActive, AttendanceDate = c.DateSeen }).OrderByDescending(x => x.AttendanceDate).FirstOrDefaultAsync());
        }

        /// <summary>
        /// Find the patient using an attendance ID
        /// Mostly used in OPD, Consulting etc
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A patient session</returns>
        public Task<PatientsVm> Find(int id) => Task.Run(async () => await db.PatientAttendance.Where(x => x.PatientAttendanceID == id).OrderByDescending(x => x.DateSeen).Select(c => new PatientsVm
        {
            PatientsID = c.PatientsID,
            DateOfBirth = c.Patients.DateOfBirth,
            FullName = c.Patients.FullName,
            Gender = c.Patients.Gender,
            MobileNumber = c.Patients.MobileNumber,
            OtherNames = c.Patients.OtherNames,
            PatientAttendanceID = c.PatientAttendanceID,
            Scheme = c.Patients.Schemes.Scheme,
            SchemesID = c.Patients.SchemesID,
            SessionName = c.SessionName,
            Surname = c.Patients.Surname,
            IsActive = c.IsActive
        }).FirstOrDefaultAsync());

        public Task<PatientAttendance> FindSession(int id)
        {
            return Task.Run(async () => await db.PatientAttendance.FindAsync(id));
        }
        /// <summary>
        /// Get list of patients visiting the clinic today
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public Task<List<AttendanceVm>> Attendances(byte num) => Task.Run(async () => await db.PatientAttendance.OrderByDescending(x => x.DateSeen).Take(num).Include(x => x.Patients).Select(x => new AttendanceVm { DateSeen = x.DateSeen, FullName = x.Patients.FullName, ID = x.PatientAttendanceID, PatientsID = x.PatientsID, VisitType = x.VisitType, SessionName = x.SessionName, FolderID = x.Patients.FolderID }).ToListAsync());

        public async Task<List<Patients>> Search(string name) => await db.Patients
            .Where(x =>
            EF.Functions.Like(x.Surname, $"%{name}%") ||
            EF.Functions.Like(x.OtherNames, $"%{name}%") ||
            EF.Functions.Like(x.MobileNumber, $"%{name}%") ||
            EF.Functions.Like(x.FolderID, $"%{name}%"))
            .Include(x => x.Schemes)
            .ToListAsync();

        internal async Task<IEnumerable> ActiveSessions()
        {
            return await db.PatientAttendance.Where(x => x.IsActive).Select(x => new
            {
                x.IsActive,
                x.PatientsID,
                x.SessionName,
                x.PatientAttendanceID,
                x.Patients.FullName,
                x.DateSeen
            }).ToListAsync();
        }

        internal void CloseSession(PatientAttendance attendance)
        {
            attendance.DateClosed = DateTime.Now;
            attendance.IsActive = false;
            db.Entry(attendance).State = EntityState.Modified;
        }
    }
}
