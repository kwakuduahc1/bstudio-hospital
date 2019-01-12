using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinClinic.DTOs;
using WinClinic.Model;
using WinClinic.Model.Laboratory;
using WinClinic.Models.ViewModels;

namespace WinClinic.Controllers.Labs
{
    public class LabsController : Controller
    {
        private readonly LabsHelper db;

        public LabsController(DbContextOptions<DataContext> dbContextOptions) => db = new LabsHelper(dbContextOptions);

        [HttpGet]
        public async Task<IEnumerable> Prescription(Guid id) => await db.GetLabs(id);

        [HttpPost]
        public async Task<IActionResult> Dispense([FromBody]List<Groups> drugs)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            db.Serve(drugs, User.Identity.Name );
            await db.Save();
            return Accepted();
        }
    }
}