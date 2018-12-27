using bStudioHospital.Model;
using bStudioHospital.Model.ConsultingRoom;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using WinClinic.DTOs.Consulting;

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
            return hist.Select(x => new { x.Complaints, x.DateAdded, x.Examination, x.ID, x.PatientsID });
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
        public async Task<IEnumerable> SchemeDrugs(string id)
        {
            var drugs = await db.SchemeDrugs(id);
            return drugs.Select(x => new { x.Drugs.DrugName, x.DrugsID, x.DrugCodesID });
        }

    }
}