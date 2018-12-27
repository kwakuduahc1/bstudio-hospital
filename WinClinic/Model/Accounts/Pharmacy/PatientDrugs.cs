using WinClinic.Model.Records;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WinClinic.Model.Pharmacy
{
    public class PatientDrugs
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        public Guid PatientAttendanceID { get; set; }

        [Required]
        public Guid DrugCodesID { get; set; }

        [Required(ErrorMessage = "Kindly Indicate the {0} for this drug")]
        [Range(1, 6, ErrorMessage = "Frequency must be between {0} and {1} daily")]
        public byte Frequency { get; set; }

        [Range(1, 200), Required(ErrorMessage = "Kindly Indicate the {0} for this drug")]
        public byte NumberOfDays { get; set; }

        [StringLength(20)]
        public string Receipt { get; set; }

        [Range(0, 200)]
        public byte QuantityRequested { get; set; }

        [Range(0, 200)]
        public byte QuantityIssued { get; set; }

        [DisplayFormat(DataFormatString = "{0:D}")]
        public DateTime DatePaid { get; set; }

        [DefaultValue(false)]
        public bool IsPaid { get; set; }

        [MaxLength(30)]
        public string ReceivingOficcer { get; set; }

        [DefaultValue(false)]
        public bool IsServed { get; set; }

        public DateTime DateServed { get; set; }

        [MaxLength(30)]
        public string ServingOficcer { get; set; }

        public DateTime DateRequested { get; set; }

        public decimal AmountPaid { get; set; }

        [MaxLength(30)]
        public string RequestingOficcer { get; set; }

        [DefaultValue(false)]
        public bool IsCompleted { get; set; }

        [ConcurrencyCheck, Timestamp]
        public byte[] Concurrency { get; set; }

        public virtual PatientAttendance PatientAttendance { get; set; }

        public virtual DrugCodes Drugcodes { get; set; }
    }
}
