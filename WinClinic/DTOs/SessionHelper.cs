using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WinClinic.Model;
using WinClinic.Model.Records;

namespace WinClinic.DTOs
{
    public class SessionHelper
    {
        static readonly DataContext db;

        static SessionHelper() => db = new DataContext(new DbContextOptions<DataContext>());

        public static Task<PatientAttendance> GetSession(Patients pat) => db.PatientAttendance.OrderByDescending(x => x.DateSeen).ThenBy(x => x.IsActive).FirstOrDefaultAsync(x => x.PatientsID == pat.PatientsID && x.IsActive);


    }
}
