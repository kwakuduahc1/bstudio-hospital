using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinClinic.DTOs.Consulting;
using WinClinic.Model;
using WinClinic.Model.ConsultingRoom;

namespace WinClinic.Controllers.OPD
{
    public class ConsultingController : Controller
    {
        private readonly ConsultHelper db;

        public ConsultingController(DbContextOptions<DataContext> dbContextOptions)
        {
            db = new ConsultHelper(dbContextOptions);
        }

        [HttpGet]
        public IActionResult Patient(string id) => Redirect($"/Attendance/Patient?id={id}");

        [HttpGet]
        public async Task<IEnumerable> Vitals(string id)
        {
            var vs = await db.Vitals(id);
            return vs.Select(x => new { x.DateSeen, x.Diastolic, x.FirstAid, x.History, x.ID, x.Pulse, x.Respiration, x.Systolic, x.Temperature, x.Weight });
        }

        [HttpGet]
        public async Task<IEnumerable> ConsultHistory(string id)
        {
            var hist = await db.ConHistory(id);
            return hist.Select(x => new { x.Complaints, x.DateAdded, x.Examination, x.PatientConsultationID, PatientsID = id }).ToList();
        }

        [HttpPost]
        public async Task<IActionResult> CreateConsult([FromBody]PatientConsultation cons)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            cons.DateAdded = DateTime.Now;
            cons.UserName = User.Identity.Name;
            db.AddConsult(cons);
            await db.Save();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> SchemeDrugs(string id)
        {
            var drugs = await db.SchemeDrugs(id);
            if (drugs == null)
                return BadRequest(new { Message = "Invalid operation. No drugs were returned for this patient" });
            return Ok(drugs?.Select(x => new { x.Drugs?.DrugName, x.DrugsID, x.DrugCodesID }));
        }

        [HttpGet]
        public async Task<IEnumerable> DiagnosesHistory(string id) => await db.DiagnosesHistory(id);

        [HttpGet]
        public async Task<IEnumerable> SchemeDiagnoses(string id) => await db.SchemeDiagnosisAsync(id);

        [HttpPost]
        public async Task<IActionResult> Diagnose([FromBody]List<PatientDiagnosis> diagnoses)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            diagnoses.ForEach(x =>
            {
                x.UserName = User.Identity.Name;
                x.PatientDiagnosisID = Guid.NewGuid();
                x.DateAdded = DateTime.Now;
            });
            db.Diagnose(diagnoses);
            await db.Save();
            return Ok();
        }

        [HttpGet]
        public async Task<IEnumerable> SchemeLabs()
        {
            var list = await db.SchemeLabs();
            return list.Select(x => new { x.Cost, x.GroupName, x.LabGroupsID }).OrderBy(x => x.GroupName).ToList();
        }

        [HttpGet]
        public async Task<IEnumerable> LabHistory(string id) => await db.LaboratoryHistory(id);

        [HttpPost]
        public async Task<IActionResult> RequestLabs([FromBody] List<ReqLabVm> labs)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            labs.ForEach(x => x.UserName = User.Identity.Name);
            db.RequestLabs(labs);
            await db.Save();
            return Accepted();
        }
    }
}