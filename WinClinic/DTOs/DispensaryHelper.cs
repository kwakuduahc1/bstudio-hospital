﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinClinic.Model;
using WinClinic.Model.Pharmacy;

namespace WinClinic.DTOs
{
    public class DispensaryHelper
    {
        readonly DataContext db;

        public DispensaryHelper(DbContextOptions<DataContext> context) => db = new DataContext(context);

        public Task<IEnumerable> GetPrescriptions(int id) => Task.Run<IEnumerable>(async () => await db.PatientDrugs.Where(x => x.PatientAttendanceID == id && !x.IsQuantitySet).Select(x => new { x.DateRequested, x.Drugcodes.DrugCode, x.Drugcodes.Drugs.DrugName, x.DrugCodesID, x.Frequency, x.PatientDrugsID, x.NumberOfDays, x.PatientAttendanceID }).ToListAsync());

        /// <summary>
        /// Gets the list of drugs to be served
        /// </summary>
        /// <param name="id">The session id</param>
        /// <returns>IEnumerable of PatientsDrugs</returns>
        public Task<IEnumerable> Prescriptions(int id) => Task.Run<IEnumerable>(async () => await db.PatientDrugs.Where(x => x.PatientAttendanceID == id && x.IsPaid && x.IsQuantitySet && !x.IsServed).Select(x => new { x.DateRequested, x.Drugcodes.DrugCode, x.Drugcodes.Drugs.DrugName, x.DrugCodesID, x.Frequency, x.PatientDrugsID, x.NumberOfDays, x.PatientAttendanceID }).ToListAsync());

        public void UpdateQuantity(List<PatientDrugs> drugs)
        {
            drugs.ForEach(x =>
            {
                var drug = db.PatientDrugs.Find(x.PatientDrugsID);
                if (drug != null)
                {
                    drug.QuantityRequested = x.QuantityRequested;
                    drug.IsQuantitySet = true;
                    drug.DateQuantitySet = DateTime.Now;
                    db.Entry(drug).State = EntityState.Modified; ;
                }
            });
        }

        public void Dispense(List<PatientDrugs> drugs)
        {
            var dgs = new List<PatientDrugs>();
            drugs.ForEach(x =>
            {
                var drug = db.PatientDrugs.Find(x.PatientDrugsID);
                if (drug != null)
                {
                    drug.IsServed = x.IsServed;
                    x.DateServed = DateTime.Now;
                    dgs.Add(drug);
                }
            });
            dgs.ForEach(x =>
            {
                db.Entry(x).State = EntityState.Modified;
            });
        }

        public Task<int> Save() => Task.Run(async () => await db.SaveChangesAsync());
    }
}
