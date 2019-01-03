using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinClinic.Model;
using WinClinic.Model.ConsultingRoom;
using WinClinic.Model.Laboratory;
using WinClinic.Model.OPD;
using WinClinic.Model.Pharmacy;
using WinClinic.Model.Records;
using WinClinic.Model.Services;
using WinClinic.Model.ViewModels;

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
        public Task<List<OPD>> Vitals(Guid id) => Task.Run(async () => await db.OpdHistory.Where(x => x.PatientAttendanceID == id).OrderByDescending(x => x.DateSeen).Take(15).ToListAsync());

        /// <summary>
        /// Get the consulting history of the patient
        /// </summary>
        /// <param name="id">The unique identifier of the patient</param>
        /// <returns>PatientConsultation</returns>
        public Task<List<PatientConsultation>> ConHistory(Guid id) => Task.Run(() => db.PatientConsultations.Where(x => x.PatientAttendanceID == id).OrderByDescending(x => x.DateAdded).Take(10).ToListAsync());

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
        public async Task<List<DrugCodes>> SchemeDrugs(Guid id)
        {
            Patients pt = await db.PatientAttendance.Where(x => x.PatientAttendanceID == id).Select(x => x.Patients).FirstOrDefaultAsync();
            if (pt == null)
                return null;
            var drugs = await db.DrugCodes.Include(x => x.Drugs).Where(x => x.SchemesID == pt.SchemesID).ToListAsync();
            return drugs;
        }

        /// <summary>
        /// Add Patient diagnoses
        /// </summary>
        /// <param name="diagnoses">The list of diagnoses to add</param>
        internal void Diagnose(List<PatientDiagnosis> diagnoses) => db.AddRange(diagnoses);

        /// <summary>
        /// Add patient signs and symptoms
        /// </summary>
        /// <param name="patientConsultation"></param>
        public void AddConsult(PatientConsultation patientConsultation) => db.Add(patientConsultation);

        /// <summary>
        /// Get the diagnostic history of a patient
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<List<PatientDiagnosis>> DiagnosesHistory(Guid id) => Task.Run(async () => await db.PatientDiagnosis.Where(x => x.PatientAttendanceID == id).ToListAsync());

        /// <summary>
        /// Get the list of possible diagnosis for a scheme
        /// </summary>
        /// <param name="id">The unique identifier for the patient</param>
        /// <returns></returns>
        public async Task<List<DiagnosticCodes>> SchemeDiagnosisAsync(Guid id)
        {
            var pt = await Patient(id);
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

        /// <summary>
        /// The current labs which have been requested for this patient for this session
        /// </summary>
        /// <param name="id">Attendance ID or the sessions</param>
        /// <returns></returns>
        public async Task<IEnumerable> CurrentLabs(Guid id)
        {
            return await db.PatientLaboratoryServices.Where(x => x.PatientAttendanceID == id).Include(x => x.LaboratoryService.LabGroup).Select(x => new { x.DateRequested, x.IsPaid, x.IsServed, x.LaboratoryServicesID, x.Notes, x.Results, x.PatientLaboratoryServicesID, x.LaboratoryService.LabGroup.GroupName, x.LaboratoryService.LaboratoryProcedure }).OrderByDescending(x => x.DateRequested).ToListAsync();
        }

        /// <summary>
        /// Request labs for the patient
        /// </summary>
        /// <param name="labs">The list of labs being requested for</param>
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

        /// <summary>
        /// Request drugs for the patient
        /// </summary>
        /// <param name="drugs">The list of drugs to be requested for</param>
        public void RequestDrugs(List<PatientDrugs> drugs) => db.PatientDrugs.AddRange(drugs);

        /// <summary>
        /// Request a service for a patient
        /// </summary>
        /// <param name="services">List of services being requested for</param>
        public void RequestService(List<RequestServiceVm> services)
        {
            services.ForEach(x =>
            {
                var cost = db.ServiceCodes.First(t => t.ServiceCodesID == x.ServiceCodesID).Cost;
                db.PatientServices.Add(new PatientServices
                {
                    DateRequested = DateTime.Now,
                    Frequency = x.Frequency,
                    IsPaid = false,
                    IsServed = false,
                    NumberOfDays = x.NumberOfDays,
                    PatientAttendanceID = x.PatientAttendanceID,
                    Receipt = "",
                    PatientServicesID = Guid.NewGuid(),
                    RequestingOficcer = x.UserName,
                    ServiceCodesID = x.ServiceCodesID,
                    ServiceCost = cost,
                });
            });
        }

        /// <summary>
        /// Get the patient services for the current sessions
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<IEnumerable> PatientServices(Guid id) => Task.Run<IEnumerable>(async () => await db.PatientServices.Where(x => x.PatientAttendanceID == id).Select(x => new
        {
            x.PatientServicesID,
            x.IsServed,
            x.DateRequested,
            x.Frequency,
            x.NumberOfDays,
            x.ServiceCodesID,
            x.ServiceCodes.Services.Service,
            x.IsPaid
        }).ToListAsync());

        /// <summary>
        /// Get a history of patient services
        /// </summary>
        /// <param name="id"></param>
        /// <param name="num"></param>
        /// <param name="off"></param>
        /// <returns></returns>
        public Task<IEnumerable> PatientServices(string id, byte num = 10, Byte off = 0) => Task.Run<IEnumerable>(async () => await db.PatientServices.Where(x => x.PatientAttendance.PatientsID == id).Select(x => new { x.PatientServicesID, x.IsServed, x.DateRequested, x.Frequency, x.NumberOfDays, x.ServiceCodesID, x.ServiceCodes.Services.Service }).ToListAsync());

        /// <summary>
        /// Get the services possible for a scheme
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable> SchemeServices(Guid id)
        {
            Patients pt = await Patient(id);
            if (pt == null)
                return null;
            var services = await db.ServiceCodes.Include(x => x.Services).Where(x => x.SchemesID == pt.SchemesID).Select(x => new
            {
                x.Cost,
                x.Description,
                x.SchemesID,
                x.ServiceCodesID,
                x.Services.Service,
                x.Services.ServiceGroup,
                x.ServicesID
            }).ToListAsync();
            return services;
        }


        async Task<Patients> Patient(Guid id) => await db.PatientAttendance.Where(u => u.PatientAttendanceID == id).Select(p => p.Patients).FirstOrDefaultAsync();
    }
}
