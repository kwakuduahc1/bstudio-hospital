using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bStudioHospital.Model.ViewModels
{
    //public class PatientLaboratoryServices
    //{
    //    public Guid ID { get; set; }

    //    [Column(TypeName = "varchar")]
    //    [Required(AllowEmptyStrings = false, ErrorMessage = "{0} is required"), MaxLength(20)]
    //    [Display(Name = "PatientID")]
    //    [Remote("VerifyUniqueID", "Helpers")]
    //    public string PatientID { get; set; }

    //    [Display(Name = "Service")]
    //    public int ServiceCodesID { get; set; }

    //    [Display(Name = "Name")]
    //    public string ServiceName { get; set; }

    //    [StringLength(1500, ErrorMessage = "{0} should be less than {1} characters")]
    //    [Column(TypeName = "varchar")]
    //    public string Results { get; set; }

    //    [Display(Name = "Date requested")]
    //    [DisplayFormat(DataFormatString = "{0:D}")]
    //    public DateTime DateRequested { get; set; }
    //}

    public class InvestigationsPayments
    {
        [Column(TypeName = "varchar")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} is required"), MaxLength(20)]
        [Display(Name = "PatientID")]
        public string PatientID { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Column(TypeName = "varchar")]
        [Display(Name = "Service")]
        public string ServiceCode { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public double Cost { get; set; }

        [Display(Name = "Date paid")]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(DataFormatString = "{0:D}")]
        public DateTime? DatePaid { get; set; }

        [Display(Name = "Date Requested")]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(DataFormatString = "{0:D}")]
        public DateTime Requested { get; set; }

        public bool PaymentStatus { get; set; }

        [Display(Name = "User Name"), MaxLength(30)]
        [Column(TypeName = "varchar")]
        public string ReceivingOficcer { get; set; }

        public bool Paid { get; set; }

        public Guid ID { get; set; }

        [StringLength(15, MinimumLength = 8, ErrorMessage = "{0} must be within {0} and {1} characters")]
        public string Receipt { get; set; }
    }

    public class ServiceRequestVm
    {
        [Required]
        public Guid ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} is required"), MaxLength(20)]
        public string PatientID { get; set; }

        [StringLength(100)]
        public string Service { get; set; }
    }

    public class InvestigationResults
    {
        public Guid ID { get; set; }

        public string PatientID { get; set; }

        public string ServiceCode { get; set; }

        public string ServiceName { get; set; }

        [StringLength(1500, ErrorMessage = "{0} should not exceed {1} characters")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} is required")]
        public string Results { get; set; }

        [Display(Name = "Date Requested")]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(DataFormatString = "{0:D}")]
        public DateTime DateRequested { get; set; }
    }
}
