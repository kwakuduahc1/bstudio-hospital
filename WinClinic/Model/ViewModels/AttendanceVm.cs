using System;

namespace WinClinic.Model.ViewModels
{
    public class AttendanceVm
    {
        public string FullName { get; set; }

        public DateTime DateSeen { get; set; }

        public string VisitType { get; set; }

        public int PatientsID { get; set; }

        public string FolderID { get; set; }

        public string SessionName { get; set; }

        public int ID { get; set; }

        public int PatientAttendanceID { get; set; }
    }
}
