using bStudioHospital.Model;
using bStudioHospital.Model.OPD;
using bStudioHospital.Model.Records;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinClinic.Model.ViewModels;

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
        public Task<bool> CheckIDExists(string id) => Task.Run(async () => await db.Patients.AnyAsync(t => t.PatientsID == id));


        /// <summary>
        /// Add new vital signs
        /// </summary>
        /// <param name="opd"></param>
        public void Add(OPD opd)
        {
            opd.DateSeen = DateTime.Now;
            opd.ID = Guid.NewGuid();
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
        public Task<List<OPD>> List(byte num, byte off) => Task.Run(async () => await db.OpdHistory.OrderByDescending(x => x.DateSeen).Skip(off).Take(num).Include(x => x.Patients).ToListAsync());

        public Task<OPD> Find(Guid id) => Task.Run(async () => await db.OpdHistory.FindAsync(id));

        public Task<Patients> Patient(string id) => Task.Run(async () => await db.Patients.SingleOrDefaultAsync(x => x.PatientsID == id));
    }
}
