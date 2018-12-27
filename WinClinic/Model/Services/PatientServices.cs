using WinClinic.Model.Accounts;
using WinClinic.Model.Records;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WinClinic.Model.Services
{
    public class PatientServices
    {
        public Guid PatientServicesID { get; set; }

        [Required]
        public Guid PatientAttendanceID { get; set; }


        [Required]
        public Guid ServiceCodesID { get; set; }

        [Required]
        [DefaultValue(1)]
        [Range(1, 90)]
        public byte NumberOfDays { get; set; }

        [Required]
        [Range(1, 3)]
        [DefaultValue(1)]
        public byte Frequency { get; set; }


        [StringLength(30, MinimumLength = 7)]
        public string RequestingOficcer { get; set; }

        [Required(ErrorMessage = "Indicate the cost of the service")]
        [Range(0, double.MaxValue)]
        public decimal ServiceCost { get; set; }

        public DateTime DatePaid { get; set; }

        [DefaultValue(false)]
        public bool IsPaid { get; set; }

        [MaxLength(30)]
        public string ReceivingOficcer { get; set; }

        [StringLength(15, MinimumLength = 10, ErrorMessage = "{0} should be between {1} and {2} characters")]
        public string Receipt { get; set; }

        public bool IsServed { get; set; }

        public DateTime DateServed { get; set; }

        public string ServingOficcer { get; set; }

        public DateTime DateRequested { get; set; }

        [ConcurrencyCheck, Timestamp]
        public byte[] Concurrency { get; set; }

        public virtual PatientAttendance PatientAttendance { get; set; }

        public virtual ServiceCodes ServiceCodes { get; set; }
    }
}
