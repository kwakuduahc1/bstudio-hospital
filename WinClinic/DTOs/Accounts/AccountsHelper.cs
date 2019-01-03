using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinClinic.Model;
using WinClinic.Model.Laboratory;
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
                    UnitCost = x.Drugcodes.Cost * x.QuantityRequested,
                    PatientDrugsID = x.ID,
                }).ToListAsync(),
                Services = await db.PatientServices.Where(x => x.PatientAttendanceID == id && !x.IsPaid).Select(x => new ServicesVm
                {
                    Amount = x.ServiceCodes.Cost,
                    Frequency = x.Frequency,
                    PatientServicesID = x.PatientServicesID,
                    Service = x.ServiceCodes.Services.Service,
                    PatientAttendanceID = x.PatientAttendanceID,
                    PatientsID = x.PatientAttendance.PatientsID
                }).ToListAsync(),
            };
            var groups = await db.PatientLaboratoryServices.Where(x => x.PatientAttendanceID == id && !x.IsPaid).Include(p => p.LaboratoryService).GroupBy(c => new { c.LaboratoryService.LabGroupsID, c.LaboratoryService.LabGroup.Cost, c.LaboratoryService.LabGroup.GroupName, c.LaboratoryServicesID }, (k, v) => new Groups { Cost = k.Cost, GroupName = k.GroupName, LabGroupsID = k.LabGroupsID, LaboratoryServicesID = k.LaboratoryServicesID, Labs = new List<LabsVm>() }).ToListAsync();
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

        public void ReceivePayment(PaymentsVm payment, string user)
        {
            string receipt = RandomStringGenerator.RandomString(8);
            if (payment.Drugs.Count > 0)
                PayDrugs(payment.Drugs, user, receipt);
            if (payment.Services.Count > 0)
                PayServices(payment.Services, user, receipt);
            if (payment.Groups.Count > 0)
                PayLabs(payment.Groups, user, receipt);
        }

        void PayDrugs(List<DrugsVm> drugs, string user, string receipt)
        {
            drugs.ForEach(x =>
            {
                var tran = db.PatientDrugs.Find(x.PatientDrugsID);
                if (tran != null)
                {
                    tran.IsPaid = true;
                    tran.DatePaid = DateTime.Now;
                    tran.ReceivingOficcer = user;
                    tran.Receipt = receipt;
                    db.Entry(tran).State = EntityState.Modified;
                }
            });
        }

        void PayServices(List<ServicesVm> services, string user, string receipt)
        {
            services.ForEach(x =>
            {
                var tran = db.PatientServices.Find(x.PatientServicesID);
                if (tran != null)
                {
                    tran.IsPaid = true;
                    tran.DatePaid = DateTime.Now;
                    tran.ReceivingOficcer = user;
                    tran.Receipt = user;
                    db.Entry(tran).State = EntityState.Modified;
                }
            });
        }

        void PayLabs(List<Groups> labs, string user, string receipt)
        {
            foreach (var group in labs)
            {
                var groups = new List<PatientLaboratoryServices>();
                foreach (var lab in group.Labs)
                {
                    var ptLab = db.PatientLaboratoryServices.Find(lab.PatLabID);
                    if (ptLab != null)
                    {
                        ptLab.IsPaid = true;
                        ptLab.DatePaid = DateTime.Now;
                        ptLab.AccountsOfficer = user;
                        groups.Add(ptLab);
                    }
                }
                groups.First(x => x.LaboratoryServicesID == group.LaboratoryServicesID).Amount = group.Cost;
                groups.ForEach(x => db.Entry(x).State = EntityState.Modified);
            }

        }

        public Task<int> Save() => Task.Run(async () => await db.SaveChangesAsync());
    }
}
