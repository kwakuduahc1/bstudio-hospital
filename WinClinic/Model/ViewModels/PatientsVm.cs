using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WinClinic.Model.ViewModels
{
    public class PatientsVm
    {
        public Guid PatientAttendanceID { get; set; }

        public string PatientsID { get; set; }

        public string FullName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Surname { get; set; }

        public string OtherNames { get; set; }

        public string Gender { get; set; }

        public string MobileNumber { get; set; }

        public Guid SchemesID { get; set; }

        public string Scheme { get; set; }

        public string SessionName { get; set; }

        public bool IsActive { get; set; }

        public DateTime AttendanceDate { get; set; }
    }
}
