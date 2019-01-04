using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WinClinic.DTOs;
using WinClinic.Model;
using WinClinic.Model.Services;

namespace WinClinic.Controllers.Services
{
    public class ServicesController : Controller
    {
        private readonly ServicesHelper db;

        public ServicesController(DbContextOptions<DataContext> dbContextOptions) => db = new ServicesHelper(dbContextOptions);

        [HttpGet]
        public async Task<IEnumerable> List(Guid id) =>await db.GetServices(id);

        [HttpPost]
        public async Task<IActionResult> Serve([FromBody]List<PatientServices> services)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            db.Serve(services, User.Identity.Name);
            await db.Save();
            return Accepted();
        }
    }
}
