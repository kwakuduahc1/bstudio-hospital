using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WinClinic.DTOs;
using WinClinic.Model;
using WinClinic.Model.Pharmacy;

namespace WinClinic.Controllers.Dispensary
{
    public class DispensaryController : Controller
    {
        private readonly DispensaryHelper db;

        public DispensaryController(DbContextOptions<DataContext> dbContextOptions) => db = new DispensaryHelper(dbContextOptions);

        [HttpGet]
        public async Task<IEnumerable> Prescription(Guid id) => await db.Prescriptions(id);

        [HttpGet]
        public async Task<IActionResult> Dispense([FromBody]List<PatientDrugs> drugs)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            db.Dispense(drugs);
            await db.Save();
            return Accepted();
        }
    }
}