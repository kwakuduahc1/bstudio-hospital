using System;

namespace WinClinic.Model.ViewModels
{
    public class RequestServiceVm
    {
        public int PatientAttendanceID { get; set; }

        public int ServiceCodesID { get; set; }

        public byte Frequency { get; set; }

        public string UserName { get; set; }

        public byte NumberOfDays { get; set; }
    }
}
