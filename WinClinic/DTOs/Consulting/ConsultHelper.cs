using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinClinic.Model;
using WinClinic.Model.Accounts;
using WinClinic.Model.ConsultingRoom;
using WinClinic.Model.Laboratory;
using WinClinic.Model.OPD;
using WinClinic.Model.Pharmacy;
using WinClinic.Model.Records;
using WinClinic.Model.Services;

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
        public Task<List<OPD>> Opd(string id) => Task.Run(async () => await db.OpdHistory.Where(x => x.PatientAttendance.PatientsID == id).OrderByDescending(x => x.DateSeen).Take(20).ToListAsync());

        /// <summary>
        /// Gets the list of patients vital signs
        /// </summary>
        /// <param name="num">The number to fetch</param>
        /// <param name="off">The number to skip or offset</param>
        /// <returns>List of patients</returns>
        public Task<List<OPD>> Vitals(string id) => Task.Run(async () => await db.OpdHistory.Where(x => x.PatientAttendance.PatientsID == id).OrderByDescending(x => x.DateSeen).Take(15).ToListAsync());

        public Task<List<PatientConsultation>> ConHistory(string id) => Task.Run(() => db.PatientConsultations.Where(x => x.PatientAttendance.PatientsID == id).OrderByDescending(x => x.DateAdded).Take(10).ToListAsync());
        /// <summary>
        /// Get last 20 drugs taken by patient
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable> CurrenntDrugs(Guid id)
        {
            return await db.PatientDrugs.Where(x => x.PatientAttendanceID == id).Include(x => x.Drugcodes).ThenInclude(x => x.Drugs).Select(x => new
            {
                x.DateRequested,
                x.Drugcodes.DrugCode,
                x.Drugcodes.Drugs.DrugName,
                x.IsServed,
                x.QuantityRequested,
                x.DrugCodesID,
                x.PatientAttendanceID,
                x.ID
            }).OrderByDescending(x => x.DateRequested).ToListAsync();
        }

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

        internal void Diagnose(List<PatientDiagnosis> diagnoses) => db.AddRange(diagnoses);

        /// <summary>
        /// Get patient services history
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<List<PatientServices>> PatientServices(string id) => Task.Run(async () => await db.PatientServices.Where(x => x.PatientAttendance.PatientsID == id).Include(x => x.ServiceCodes).ThenInclude(x => x.Services).ToListAsync());

        public async Task<List<ServiceCodes>> SchemeServices(string id)
        {
            Patients pt = await db.Patients.FindAsync(id);
            if (pt == null)
                return null;
            var services = await db.ServiceCodes.Include(x => x.Services).Where(x => x.SchemesID == pt.SchemesID).ToListAsync();
            return services;
        }

        public void AddConsult(PatientConsultation patientConsultation) => db.Add(patientConsultation);

        /// <summary>
        /// Get the diagnostic history of a patient
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<List<PatientDiagnosis>> DiagnosesHistory(string id) => Task.Run(async () => await db.PatientDiagnosis.Where(x => x.PatientAttendance.PatientsID == id).ToListAsync());

        /// <summary>
        /// Get the list of possible diagnosis for a scheme
        /// </summary>
        /// <param name="id">The unique identifier for the patient</param>
        /// <returns></returns>
        public async Task<List<DiagnosticCodes>> SchemeDiagnosisAsync(string id)
        {
            var pt = await db.Patients.FindAsync(id);
            if (pt == null)
                return null;
            return await Task.Run(async () => await db.DiagnosticCodes.Where(x => x.SchemesID == pt.SchemesID).ToListAsync());
        }

        /// <summary>
        /// Get all the lab procedures
        /// </summary>
        /// <returns>LaboratoryServices</returns>
        public async Task<List<LabGroups>> SchemeLabs()
        {
            return await Task.Run(async () => await db.LabGroups.ToListAsync());
        }

        /// <summary>
        /// Get the lab history for a patient
        /// </summary>
        /// <param name="id">The unique identifier for a patient</param>
        /// <returns></returns>
        public async Task<IEnumerable> LaboratoryHistory(string id)
        {
            var pt = await db.Patients.FindAsync(id);
            if (pt == null)
                return null;
            return await db.PatientLaboratoryServices.Where(x => x.PatientAttendance.PatientsID == pt.PatientsID).Include(x => x.LaboratoryService.LabGroup).Select(x => new { x.DateRequested, x.IsPaid, x.IsServed, x.LaboratoryServicesID, x.Notes, x.Results, x.PatientLaboratoryServicesID, x.LaboratoryService.LabGroup.GroupName, x.LaboratoryService.LaboratoryProcedure }).ToListAsync();
        }

        public async Task<IEnumerable> CurrentLabs(Guid id)
        {
            return await db.PatientLaboratoryServices.Where(x => x.PatientAttendanceID == id && x.DateRequested.Date == DateTime.Now.Date).Include(x => x.LaboratoryService.LabGroup).Select(x => new { x.DateRequested, x.IsPaid, x.IsServed, x.LaboratoryServicesID, x.Notes, x.Results, x.PatientLaboratoryServicesID, x.LaboratoryService.LabGroup.GroupName, x.LaboratoryService.LaboratoryProcedure }).OrderByDescending(x => x.DateRequested).ToListAsync();
        }

        public void RequestLabs(List<ReqLabVm> labs)
        {
            var list = new List<LaboratoryServices>();
            foreach (var item in labs)
            {
                var _list = db.LaboratoryServices.Where(t => t.LabGroupsID == item.LabGroupsID).ToList();
                list.AddRange(_list);
            }
            foreach (var x in list)
            {
                var req = new PatientLaboratoryServices
                {
                    Amount = 0,
                    DateRequested = DateTime.Now,
                    IsPaid = false,
                    IsServed = false,
                    PatientAttendanceID = labs[0].PatientAttendanceID,
                    Notes = "",
                    LabOfficer = labs[0].UserName,
                    LaboratoryServicesID = x.LaboratoryServicesID
                };
                db.PatientLaboratoryServices.Add(req);
            }
        }

        public void RequestDrugs(List<PatientDrugs> drugs) => db.PatientDrugs.AddRange(drugs);

        public void RequestServic(List<PatientServices> services)
        {
            services.ForEach(x =>
            {
                x.DateRequested = DateTime.Now;
                x.IsPaid = false;
                x.PatientServicesID = Guid.NewGuid();
            });
            db.PatientServices.AddRange(services);
        }

        public Task<IEnumerable> CurrentServices(Guid id) => Task.Run<IEnumerable>(async () => await db.PatientServices.Where(x => x.PatientAttendanceID == id).Select(x => new { x.PatientServicesID, x.IsServed, x.DateRequested, x.Frequency, x.NumberOfDays, x.ServiceCodesID, x.ServiceCodes.Services.Service }).ToListAsync());
    }
}
