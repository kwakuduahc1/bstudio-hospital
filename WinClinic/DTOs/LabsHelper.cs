using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinClinic.Model;
using WinClinic.Models.ViewModels;

namespace WinClinic.DTOs
{
    public class LabsHelper
    {
        readonly DataContext db;

        public LabsHelper(DbContextOptions<DataContext> context) => db = new DataContext(context);

        public async Task<IEnumerable> GetLabs(int id)
        {
            var groups = await db.PatientLaboratoryServices.Where(x => x.PatientAttendanceID == id && !x.IsServed).Include(p => p.LaboratoryService).GroupBy(c => new { c.LaboratoryService.LabGroupsID, c.LaboratoryService.LabGroup.Cost, c.LaboratoryService.LabGroup.GroupName, c.LaboratoryServicesID }, (k, v) => new Groups { Cost = k.Cost, GroupName = k.GroupName, LabGroupsID = k.LabGroupsID, LaboratoryServicesID = k.LaboratoryServicesID, Labs = new List<LabsVm>() }).ToListAsync();
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
            return groups;
        }

        public void Serve(List<Groups> groups, string user)
        {
            groups.ForEach(x =>
            {
                x.Labs.ForEach(t =>
                {
                    var lab = db.PatientLaboratoryServices.Find(t.PatLabID);
                    if (lab != null)
                    {
                        lab.IsServed = true;
                        lab.DateServed = DateTime.Now;
                        lab.RequestingOfficer = user;
                        db.Entry(lab).State = EntityState.Modified;
                    }
                });
            });
        }

        public Task<int> Save() => Task.Run(async () => await db.SaveChangesAsync());
    }
}
