using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WinClinic.Model;
using WinClinic.Model.Records;

namespace WinClinic.DTOs
{
    public static class SessionHelper
    {
        private static readonly DataContext db = new DataContext(new DbContextOptions<DataContext>());

        public static Task<PatientAttendance> GetSession(Patients pat) => db.PatientAttendance.OrderByDescending(x => x.DateSeen).ThenBy(x => x.IsActive).FirstOrDefaultAsync(x => x.PatientsID == pat.PatientsID && x.IsActive);


    }
}
