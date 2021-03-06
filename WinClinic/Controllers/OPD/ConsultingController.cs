﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinClinic.DTOs.Consulting;
using WinClinic.Model;
using WinClinic.Model.ConsultingRoom;
using WinClinic.Model.Pharmacy;
using WinClinic.Model.ViewModels;

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
        public async Task<IEnumerable> Vitals(int id)
        {
            var vs = await db.Vitals(id);
            return vs.Select(x => new { x.DateSeen, x.Diastolic, x.FirstAid, x.History, x.OPDID, x.Pulse, x.Respiration, x.Systolic, x.Temperature, x.Weight });
        }

        [HttpGet]
        public async Task<IEnumerable> ConsultHistory(int id)
        {
            var hist = await db.ConHistory(id);
            return hist.Select(x => new { x.Complaints, x.DateAdded, x.Examination, x.PatientConsultationID, PatientsID = id }).ToList();
        }

        [HttpPost]
        public async Task<IActionResult> CreateConsult([FromBody]PatientConsultation cons)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            cons.DateAdded = DateTime.Now;
            cons.UserName = User.Identity.Name;
            db.AddConsult(cons);
            await db.Save();
            return Ok();
        }

        [HttpGet]
        public async Task<IEnumerable> DiagnosesHistory(int id) => await db.DiagnosesHistory(id);

        [HttpGet]
        public async Task<IEnumerable> SchemeDiagnoses(int id) => await db.SchemeDiagnosisAsync(id);

        [HttpPost]
        public async Task<IActionResult> Diagnose([FromBody]List<PatientDiagnosis> diagnoses)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            diagnoses.ForEach(x =>
            {
                x.UserName = User.Identity.Name;
                x.DateAdded = DateTime.Now;
            });
            db.Diagnose(diagnoses);
            await db.Save();
            return Ok();
        }

        [HttpGet]
        public async Task<IEnumerable> SchemeLabs()
        {
            var list = await db.SchemeLabs();
            return list.Select(x => new { x.Cost, x.GroupName, x.LabGroupsID }).OrderBy(x => x.GroupName).ToList();
        }

        [HttpGet]
        public async Task<IEnumerable> LabHistory(int id) => await db.LaboratoryHistory(id);

        [HttpGet]
        public async Task<IEnumerable> CurrentLabs(int id) => await db.CurrentLabs(id);

        [HttpPost]
        public async Task<IActionResult> RequestLabs([FromBody] List<ReqLabVm> labs)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            labs.ForEach(x => x.UserName = User.Identity.Name);
            db.RequestLabs(labs);
            await db.Save();
            return Accepted();
        }

        [HttpGet]
        public async Task<IEnumerable> CurrentDrugs(int id) => await db.CurrenntDrugs(id);

        [HttpGet]
        public async Task<IActionResult> SchemeDrugs(int id)
        {
            var drugs = await db.SchemeDrugs(id);
            if (drugs == null)
                return BadRequest(new { Message = "Invalid operation. No drugs were returned for this patient" });
            return Ok(drugs.Select(x => new { x.Drugs.DrugName, x.DrugsID, x.DrugCodesID }));
        }

        [HttpPost]
        public async Task<IActionResult> RequestDrugs([FromBody]List<PatientDrugs> drugs)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            drugs.ForEach(x =>
            {
                x.DateRequested = DateTime.Now;
                x.RequestingOficcer = User.Identity.Name;
            });
            db.RequestDrugs(drugs);
            await db.Save();
            return Created("", drugs);
        }

        [HttpGet]
        public async Task<IEnumerable> Services(int id) => await db.SchemeServices(id);

        [HttpPost]
        public async Task<IActionResult> RequestServices([FromBody]List<RequestServiceVm> services)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            services.ForEach(x => x.UserName = User.Identity.Name);
            db.RequestService(services);
            await db.Save();
            return Created("", services);
        }

        [HttpGet]
        public async Task<IEnumerable> ServicesHistory(int id) => await db.PatientServices(id);

        //[HttpGet]
        //public async Task<IEnumerable> ServicesHistory(string id) => await db.PatientServices(id);
    }
}