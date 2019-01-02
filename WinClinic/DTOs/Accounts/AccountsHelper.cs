using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinClinic.Model;
using WinClinic.Model.ViewModels;
using WinClinic.Models.ViewModels;

namespace WinClinic.DTOs.Accounts
{
    public class AccountsHelper
    {
        private readonly DataContext db;

        public AccountsHelper(DbContextOptions<DataContext> context) => db = new DataContext(context);

        public async Task<PaymentsVm> GetPaymentsAsync(Guid id)
        {
            var payments = new PaymentsVm
            {
                Drugs = await db.PatientDrugs.Where(x => x.PatientAttendanceID == id && !x.IsPaid).Select(x => new DrugsVm
                {
                    Description = "",
                    DrugName = x.Drugcodes.Drugs.DrugName,
                    MeasurementUnit = "pc",
                    UnitCost = x.Drugcodes.Cost,
                    Quantity = x.QuantityRequested
                }).ToListAsync(),
                Services = await db.PatientServices.Where(x => x.PatientAttendanceID == id && !x.IsPaid).Select(x => new ServicesVm
                {
                    Amount = x.ServiceCodes.Cost,
                    Frequency = x.Frequency,
                    PatientServicesID = x.PatientServicesID,
                    Service = x.ServiceCodes.Services.Service,
                }).ToListAsync(),
            };
            var groups = await db.PatientLaboratoryServices.Where(x => x.PatientAttendanceID == id && !x.IsPaid).Include(p => p.LaboratoryService).GroupBy(c => new { c.LaboratoryService.LabGroupsID, c.LaboratoryService.LabGroup.Cost, c.LaboratoryService.LabGroup.GroupName }, (k, v) => new Groups { Cost = k.Cost, GroupName = k.GroupName, LabGroupsID = k.LabGroupsID, Labs = new List<LabsVm>() }).ToListAsync();
            groups.ForEach(t =>
            {
                var labs = db.PatientLaboratoryServices.Where(x => x.PatientAttendanceID == id && x.LaboratoryService.LabGroupsID == t.LabGroupsID).Select(x => new LabsVm
                {
                    Lab = x.LaboratoryService.LaboratoryProcedure,
                    Amount = x.Amount,
                    LabsID = x.LaboratoryServicesID,
                    LabGroupsID = t.LabGroupsID,
                    AttendanceID = x.PatientAttendanceID,
                    PatLabID = x.PatientLaboratoryServicesID
                }).ToList();
                t.Labs = labs;
            });
            payments.PatientAttendanceID = id;
            payments.Groups = groups;
            return payments;
        }

    }
}
