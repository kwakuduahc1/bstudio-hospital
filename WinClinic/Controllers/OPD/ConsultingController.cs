using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WinClinic.Controllers.OPD
{
    public class ConsultingController : Controller
    {
        [HttpGet]
        public IActionResult Patient(string id) => Redirect($"/Attendance/Patient?id={id}");


    }
}