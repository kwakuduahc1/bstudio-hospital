using System;

namespace WinClinic.Model.ViewModels
{
    public class AttendanceVm
    {
        public string FullName { get; set; }

        public DateTime DateSeen { get; set; }

        public string VisitType { get; set; }

        public string PatientsID { get; set; }

        public string SessionName { get; set; }

        public Guid ID { get; set; }

        public Guid PatientAttendanceID { get; set; }
    }
}
