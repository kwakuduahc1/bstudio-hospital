﻿using bStudioHospital.Model;
using bStudioHospital.Model.Records;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using WinClinic.DTOs.Records;

namespace KingsMedicalVillage.Controllers.Records
{
    public class AttendanceController : Controller
    {
        private readonly RecordsHelper helper;

        public AttendanceController(DbContextOptions<DataContext> dbContextOptions)
        {
            helper = new RecordsHelper(dbContextOptions);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PatientID", "VisitType")]PatientAttendance attendance)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            var patient = await helper.Find(attendance.PatientsID);
            if (patient == null)
                return BadRequest(new { Message = $"{patient.PatientsID} is not a valid OPD number" });
            helper.AddAttendance(patient, attendance.VisitType);
            await helper.Save();
            return Created($"/Attendance/FInd?id={attendance.ID}", attendance);
        }

        [HttpGet]
        public async Task<IEnumerable> List() => await helper.Attendances();
    }
}