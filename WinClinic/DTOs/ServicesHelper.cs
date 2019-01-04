using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinClinic.Model;
using WinClinic.Model.Services;

namespace WinClinic.DTOs
{
    public class ServicesHelper
    {
        readonly DataContext db;

        public ServicesHelper(DbContextOptions<DataContext> context) => db = new DataContext(context);

        public Task<IEnumerable> GetServices(Guid id) => Task.Run<IEnumerable>(async () => await db.PatientServices.Where(x => x.PatientAttendanceID == id && !x.IsServed).Select(x => new { x.DateRequested, x.ServiceCodes.ServiceCode, x.ServiceCodes.Services.Service, x.ServiceCodesID, x.Frequency, x.PatientServicesID, x.NumberOfDays, x.PatientAttendanceID }).ToListAsync());

        public void Serve(List<PatientServices> services, string user)
        {
            services.ForEach(x =>
            {
                var drug = db.PatientServices.Find(x.PatientServicesID);
                if (drug != null)
                {
                    drug.IsServed = x.IsServed;
                    x.DateServed = DateTime.Now;
                    x.ServingOficcer = user;
                    db.Entry(drug).State = EntityState.Modified;
                }
            });
        }

        public Task<int> Save() => Task.Run(async () => await db.SaveChangesAsync());
    }
}
