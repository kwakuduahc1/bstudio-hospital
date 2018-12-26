using bStudioHospital.Model;
using bStudioHospital.Model.Accounts;
using bStudioHospital.Model.ConsultingRoom;
using bStudioHospital.Model.OPD;
using bStudioHospital.Model.Pharmacy;
using bStudioHospital.Model.Records;
using bStudioHospital.Model.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WinClinic.DTOs.Consulting
{
    public class ConsultHelper
    {
        readonly DataContext db;

        public ConsultHelper(DbContextOptions<DataContext> context) => db = new DataContext(context);

        /// <summary>
        /// Checks whether the given opd number of the patient already exists
        /// </summary>
        /// <param name="id">The index number, staff id or other unique identifier of the patient</param>
        /// <returns></returns>
        public Task<bool> CheckIDExists(string id) => Task.Run(async () => await db.Patients.AnyAsync(t => t.PatientsID == id));

        /// <summary>
        /// Save changes
        /// </summary>
        /// <returns></returns>
        public Task<int> Save() => Task.Run(async () => await db.SaveChangesAsync());

        /// <summary>
        /// Get the patient vital signs
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<List<OPD>> Opd(string id) => Task.Run(async () => await db.OpdHistory.Where(x => x.PatientsID == id).OrderByDescending(x => x.DateSeen).Take(20).ToListAsync());

        /// <summary>
        /// Gets the list of patients
        /// </summary>
        /// <param name="num">The number to fetch</param>
        /// <param name="off">The number to skip or offset</param>
        /// <returns>List of patients</returns>
        public Task<List<OPD>> Vitals(string id) => Task.Run(async () => await db.OpdHistory.Where(x => x.PatientsID == id).OrderByDescending(x => x.DateSeen).Take(15).ToListAsync());

        public Task<List<PatientConsultation>> ConHistory(string id) => Task.Run(() => db.PatientConsultations.Where(x => x.PatientsID == id).OrderByDescending(x => x.DateAdded).Take(10).ToListAsync());
        /// <summary>
        /// Get last 20 drugs taken by patient
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<List<PatientDrugs>> PatientDrugs(string id) => Task.Run(async () => await db.PatientDrugs.Where(x => x.PatientsID == id).Include(x => x.Drugcodes).ThenInclude(x => x.Drugs).ToListAsync());

        /// <summary>
        /// Get all the drugs that can be given to patients of a scheme
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<DrugCodes>> SchemeDrugs(string id)
        {
            Patients pt = await db.Patients.FindAsync(id);
            if (pt == null)
                return null;
            var drugs = await db.DrugCodes.Include(x => x.Drugs).Where(x => x.SchemesID == pt.SchemesID).ToListAsync();
            return drugs;
        }

        /// <summary>
        /// Get patient services history
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<List<PatientServices>> PatientServices(string id) => Task.Run(async () => await db.PatientServices.Where(x => x.PatientsID == id).Include(x => x.ServiceCodes).ThenInclude(x => x.Services).ToListAsync());

        public async Task<List<ServiceCodes>> SchemeServices(string id)
        {
            Patients pt = await db.Patients.FindAsync(id);
            if (pt == null)
                return null;
            var services = await db.ServiceCodes.Include(x => x.Services).Where(x => x.SchemesID == pt.SchemesID).ToListAsync();
            return services;
        }

        //public Task<List<PatientDrugs>> PatientDrugs(string id) => Task.Run(async () => await db.PatientDrugs.Where(x => x.PatientsID == id).Include(x => x.Drugcodes).ThenInclude(x => x.Drugs).ToListAsync());

        //public async Task<List<DrugCodes>> SchemeDrugs(string id)
        //{
        //    Patients pt = await db.Patients.FindAsync(id);
        //    if (pt == null)
        //        return null;
        //    var drugs = await db.DrugCodes.Include(x => x.Drugs).Where(x => x.SchemesID == pt.SchemesID).ToListAsync();
        //    return drugs;
        //}

        public void AddConsult(PatientConsultation patientConsultation) => db.Add(patientConsultation);
    }
}
