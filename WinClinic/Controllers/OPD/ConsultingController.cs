using bStudioHospital.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

    }
}