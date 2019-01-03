using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinClinic.DTOs;
using WinClinic.Model;
using WinClinic.Model.Pharmacy;

namespace WinClinic.Controllers.Dispensary
{
    public class DrugQuantitiesController : Controller
    {
        private readonly DispensaryHelper db;

        public DrugQuantitiesController(DbContextOptions<DataContext> dbContextOptions) => db = new DispensaryHelper(dbContextOptions);

        [HttpGet]
        public IActionResult FindPatient(string id) => RedirectToAction(actionName: "FindPatient", controllerName: "Attendance", routeValues: new { id });

        [HttpGet]
        public async Task<IEnumerable> GetPrescriptions(Guid id) => await db.GetPrescriptions(id);

        [HttpGet]
        public async Task<IEnumerable> Prescription(Guid id) => await db.Prescriptions(id);

        [HttpPost]
        public async Task<IActionResult> Set([FromBody]List<PatientDrugs> drugs)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            db.UpdateQuantity(drugs);
            await db.Save();
            return Accepted();
        }

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