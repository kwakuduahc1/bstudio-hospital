﻿using bStudioHospital.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using WinClinic.DTOs.Records;
using bsopd = bStudioHospital.Model.OPD;

namespace WinClinic.Controllers.OPD
{
    public class VitalSignsController : Controller
    {
        private readonly VitalsHelper db;

        public VitalSignsController(DbContextOptions<DataContext> dbContextOptions)
        {
            db = new VitalsHelper(dbContextOptions);
        }

        [HttpGet]
        public async Task<IEnumerable> List(byte num, byte off)
        {
            var list = await db.List(num, off);
            return list.Select(x => new { x.PatientAttendance.Patients.FullName, x.Temperature, x.Systolic, x.Diastolic, x.Respiration, x.Weight, x.DateSeen, x.Pulse, x.ID, x.UserName });
        }

        [HttpGet]
        public async Task<IActionResult> Patient(string id)
        {
            var pat = await db.Patient(id);
            if (pat == null)
                return NotFound(new { Message = $"{id} does not match any known record" });
            return Ok(new { pat.FullName, pat.PatientsID, pat.Schemes.Scheme, pat.DateOfBirth });
        }

        [HttpGet]
        public async Task<IActionResult> Find(Guid id)
        {
            bsopd.OPD opd = await db.Find(id);
            if (opd == null)
                return BadRequest(new { Message = "Record was not found" });
            return Ok(opd);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]bsopd.OPD opd)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            if (!await db.CheckVisit(opd.PatientAttendanceID))
                return BadRequest(new { Message = "Patient has not visited the records today" });
            db.Add(opd);
            await db.Save();
            return Created($"/OPD/Find?id={opd.ID}", opd);
        }
    }
}