using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WinClinic.Model.ViewModels
{
    //public class PatientLaboratoryServices
    //{
    //    public Guid ID { get; set; }

    //    [Column(TypeName = "varchar")]
    //    [Required(AllowEmptyStrings = false, ErrorMessage = "{0} is required"), MaxLength(20)]
    //    [Display(Name = "PatientsID")]
    //    [Remote("VerifyUniqueID", "Helpers")]
    //    public string PatientsID { get; set; }

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
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} is required"), MaxLength(20)]
        public string PatientsID { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string ServiceCode { get; set; }

        public double Cost { get; set; }

        public DateTime DatePaid { get; set; }

        public DateTime Requested { get; set; }

        public bool IsPaid { get; set; }

        public string ReceivingOficcer { get; set; }

        public bool Paid { get; set; }

        public Guid ID { get; set; }

        [StringLength(20)]
        public string Receipt { get; set; }
    }

    public class ServiceRequestVm
    {
        [Required]
        public Guid ID { get; set; }

        [Required]
        [MaxLength(20)]
        public string PatientsID { get; set; }

        [StringLength(100)]
        public string Service { get; set; }
    }

    public class InvestigationResults
    {
        public Guid ID { get; set; }

        public string PatientsID { get; set; }

        public string ServiceCode { get; set; }

        public string ServiceName { get; set; }

        [StringLength(1500, ErrorMessage = "{0} should not exceed {1} characters")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} is required")]
        public string Results { get; set; }

        public DateTime DateRequested { get; set; }
    }
}
