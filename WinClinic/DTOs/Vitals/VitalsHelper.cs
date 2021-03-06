﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinClinic.Model;
using WinClinic.Model.OPD;
using WinClinic.Model.Records;

namespace WinClinic.DTOs.Records
{
    public class VitalsHelper
    {
        readonly DataContext db;

        public VitalsHelper(DbContextOptions<DataContext> context) => db = new DataContext(context);

        /// <summary>
        /// Checks whether the given opd number of the patient already exists
        /// </summary>
        /// <param name="id">The index number, staff id or other unique identifier of the patient</param>
        /// <returns></returns>
        public Task<bool> CheckIDExists(string id) => Task.Run(async () => await db.Patients.AnyAsync(t => t.FolderID == id));

        /// <summary>
        /// Ensures the patient has visited the records department at least once today
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<bool> CheckVisit(int id) => Task.Run(async () => await db.PatientAttendance.AnyAsync(x => x.PatientAttendanceID == id && x.DateSeen.Date == DateTime.Now.Date));

        /// <summary>
        /// Add new vital signs
        /// </summary>
        /// <param name="opd"></param>
        public void Add(OPD opd)
        {
            opd.DateSeen = DateTime.Now;
            db.Add(opd);
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
        public Task<List<OPD>> List(byte num, byte off) => Task.Run(async () => await db.OpdHistory.OrderByDescending(x => x.DateSeen).Skip(off).Take(num).Include(x => x.PatientAttendance).ThenInclude(x => x.Patients).ToListAsync());

        public Task<OPD> Find(int id) => Task.Run(async () => await db.OpdHistory.FindAsync(id));

        public Task<PatientAttendance> Patient(int id) => Task.Run(async () => await db.PatientAttendance.Include(x => x.Patients).ThenInclude(x => x.Schemes).OrderByDescending(x => x.DateSeen).FirstOrDefaultAsync(x => x.PatientsID == id && x.IsActive));
    }
}
