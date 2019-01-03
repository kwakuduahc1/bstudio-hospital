using System;
using System.ComponentModel.DataAnnotations;

namespace WinClinic.Models.ViewModels
{
    public class ServicesVm
    {
        [Required]
        public Guid PatientServicesID { get; set; }

        public string Service { get; set; }

        public decimal Amount { get; set; }

        [Required]
        public byte Frequency { get; set; }

        [Required]
        public Guid PatientAttendanceID { get; set; }

        [Required]
        public string PatientsID { get; set; }

        public string Report { get; set; }
    }

}
