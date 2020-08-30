using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using WinClinic.DTOs.Records;
using WinClinic.Model;
using WinClinic.Model.Records;
using WinClinic.Model.ViewModels;

namespace KingsMedicalVillage.Controllers.Records
{
    public class AttendanceController : Controller
    {
        private readonly RecordsHelper helper;

        public AttendanceController(DbContextOptions<DataContext> dbContextOptions) => helper = new RecordsHelper(dbContextOptions);

        [HttpGet]
        public async Task<IActionResult> Patient(int id)
        {
            PatientsVm pat = await helper.Find(id);
            if (pat == null)
                return NotFound(new { Message = "Patient was not found" });
            return !pat.IsActive ? BadRequest(new { Message = "Patient does not have an active session" }) : (IActionResult)Ok(pat);
        }

        [HttpGet]
        public async Task<IActionResult> FindPatient(string id)
        {
            PatientsVm pat = await helper.Find(id);
            return pat == null ? NotFound(new { Message = "Patient was not found" }) : (IActionResult)Ok(pat);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody]PatientAttendance attendance)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            var patient = await helper.Find(attendance.PatientsID);
            if (patient == null)
                return BadRequest(new { Message = $"{patient.PatientsID} is not a valid OPD number" });
            attendance.UserName = User.Identity.Name;
            attendance.IsActive = true;
            await helper.ClosePreviousesAsync(patient.PatientsID);
            helper.AddAttendance(patient.PatientsID, attendance.UserName, attendance.VisitType);
            await helper.Save();
            return Created($"/Attendance/FInd?id={attendance.PatientAttendanceID}", attendance);
        }

        [HttpGet]
        public async Task<IEnumerable> List(byte num)
        {
            var list = await helper.Attendances(num);
            return list.Select(x => new { x.DateSeen, x.FullName, x.ID, x.PatientsID, x.VisitType, x.SessionName });
        }

        [HttpGet]
        public async Task<IEnumerable> ActiveSessions() => await helper.ActiveSessions();

        [HttpPost]
        public async Task<IActionResult> CloseSession([FromBody]AttendanceVm attendance)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            var att =await helper.FindSession(attendance.PatientAttendanceID);
            if (att == null)
                return BadRequest(new { Message = "The session was not found" });
            helper.CloseSession(att);
           await helper.Save();
            return Accepted();
        }
    }
}