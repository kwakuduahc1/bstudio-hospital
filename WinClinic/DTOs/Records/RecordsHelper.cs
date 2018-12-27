using Microsoft.EntityFrameworkCore;
using System;
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
        public Task<bool> CheckIDExists(string id) => Task.Run(async () => await db.Patients.AnyAsync(t => t.PatientsID == id));

        /// <summary>
        /// Add patient attendance
        /// </summary>
        /// <param name="patient"></param>
        public void AddAttendance(Patients patient, string visit)
        {
            db.Add(new PatientAttendance
            {
                DateSeen = DateTime.Now,
                PatientsID = patient.PatientsID,
                UserName = patient.UserName,
                VisitType = visit,
                SessionName = RandomString(new Random().Next(6, 10)),
                PatientAttendanceID = Guid.NewGuid()
            });
        }

        public async Task ClosePreviousesAsync(Patients patient)
        {
            var atts = await db.PatientAttendance.Where(x => x.PatientsID == patient.PatientsID && !x.IsActive).ToListAsync();
            if (atts.Any())
                atts.ForEach(x =>
                {
                    x.IsActive = true;
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
            AddAttendance(patient, "Acute");
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
        public Task<List<Patients>> SchemeList(Guid id, byte num, byte off) => Task.Run(async () => await db.Patients.Where(x => x.PatientDetails.SchemesID == id).OrderByDescending(x => x.DateAdded).Skip(off).Take(num).ToListAsync());

        public Task<Patients> Find(string id) => Task.Run(async () => await db.Patients.Include(x => x.Schemes).SingleOrDefaultAsync(x => x.PatientsID == id));

        /// <summary>
        /// Get list of patients visiting the clinic today
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public Task<List<AttendanceVm>> Attendances(byte num) => Task.Run(async () => await db.PatientAttendance.OrderByDescending(x => x.DateSeen).Take(num).Include(x => x.Patients).Select(x => new AttendanceVm { DateSeen = x.DateSeen, FullName = x.Patients.FullName, ID = x.PatientAttendanceID, PatientsID = x.PatientsID, VisitType = x.VisitType, SessionName = x.SessionName }).ToListAsync());

        public async Task<List<Patients>> Search(string name) => await db.Patients
            .Where(x =>
            EF.Functions.Like(x.Surname, $"%{name}%") ||
            EF.Functions.Like(x.OtherNames, $"%{name}%") ||
            EF.Functions.Like(x.MobileNumber, $"%{name}%") ||
            EF.Functions.Like(x.PatientsID, $"%{name}%"))
            .Include(x => x.Schemes)
            .ToListAsync();
    }
}
