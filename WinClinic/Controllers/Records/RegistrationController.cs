using bStudioHospital.Model;
using bStudioHospital.Model.Records;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using WinClinic.DTOs.Records;

namespace KingsMedicalVillage.Controllers.Records
{
    public class RegistrationController : Controller
    {
        private readonly RecordsHelper helper;

        public RegistrationController(DbContextOptions<DataContext> dbContextOptions) => helper = new RecordsHelper(dbContextOptions);

        [HttpPost]
        public async Task<IActionResult> Create([FromBody, Bind("Surname", "FirstName", "OtherNames", "MobileNumber", "Gender", "PatientsID")]Patients patient)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            if (await helper.CheckIDExists(patient.PatientsID))
                return BadRequest(new { Message = $"A patient already uses the id {patient.PatientsID}" });
            patient.UserName = User.Identity.Name ?? "";
            helper.Register(patient);
            int status = await helper.Save();
            return Created($"/Patients/Find?id={patient.PatientsID}", new { patient.Gender, patient.MobileNumber, patient.Surname, patient.OtherNames, patient.PatientsID });
        }

        [HttpGet]
        public async Task<IEnumerable> List(byte num, byte off) => await helper.List(num, off);

        [HttpGet]
        public async Task<IEnumerable> SchemeList(Guid id, byte num, byte off) => await helper.SchemeList(id, num, off);

        [HttpGet]
        public async Task<IEnumerable> Search(string name) => await helper.Search(name);
        //[HttpGet]
        //public async Task<PartialViewResult> Search(string Name)
        //{
        //    var branch = await d.Staff.Where(x => x.UserName == User.Identity.Name).Select(x => x.Branch).FirstOrDefaultAsync();
        //    var pts = await d.Patients.Where(x => x.Branch == branch).Where(x => x.FirstName.Contains(Name) || x.Surname.Contains(Name) || x.PatientID.Contains(Name)).ToListAsync();
        //    if (pts != null)
        //    {
        //        ViewBag.Message = string.Format("Your search returned {0} results", pts.Count);
        //        return PartialView("Details", pts);
        //    }
        //    else
        //    {
        //        var list = await d.Patients.Where(x => x.Branch == branch).OrderByDescending(x => x.DateAdded).Take(10).ToListAsync();
        //        ViewBag.ErrorMessage = "No patient with name: " + Name + "was found in your branch";
        //        return PartialView("Details", list);
        //    }
        //}

        //[HttpPost]
        ////    [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit([Bind("Surname", "FirstName", "OtherNames", "MobileNumber", "KinContact", "PatientID", "Concurrency")]Patients patient)
        //{

        //    var pt = await db.Patients.FindAsync(patient.PatientsID);
        //    if (pt == null)
        //        return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
        //    pt.Surname = Surname.ToUpper();
        //    pt.FirstName = FirstName.ToUpper();
        //    pt.OtherNames = string.IsNullOrWhiteSpace(OtherNames) ? "" : OtherNames.ToUpper();
        //    pt.KinContact = $"+233{KinContact.Substring(1)}";
        //    pt.MobileNumber = $"+233{MobileNumber.Substring(1)}";
        //    if (!ModelState.IsValid)
        //        return new HttpStatusCodeResult(HttpStatusCode.NotAcceptable);
        //    db.Entry(pt).State = EntityState.Modified;
        //    return new HttpStatusCodeResult(HttpStatusCode.Accepted, "Changes have been made");
        //}

    }
}