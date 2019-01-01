using System;

namespace WinClinic.Model.ViewModels
{
    public class RequestServiceVm
    {
        public Guid PatientAttendanceID { get; set; }

        public Guid ServiceCodesID { get; set; }

        public byte Frequency { get; set; }

        public string UserName { get; set; }

        public byte NumberOfDays { get; set; }
    }
}
