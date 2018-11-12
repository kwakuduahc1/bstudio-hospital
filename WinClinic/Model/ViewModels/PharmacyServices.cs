using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace bStudioHospital.Model.ViewModels
{
    public class PhysicianDrugRequisition
    {
        public int ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} is required"), MaxLength(20)]
        [Display(Name = "PatientID")]
        [Remote("VerifyUniqueID", "Helpers")]
        public string PatientID { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Column(TypeName = "varchar")]
        [Display(Name = "Drug")]
        public int DrugCodesID { get; set; }

        public string Description { get; set; }

        public string MeasurementUnit { get; set; }

        [Required(ErrorMessage = "Kindly Indicate the {0} for this drug")]
        public byte? Frequency { get; set; }

        [Range(1, 100, ErrorMessage = "{0} is invalid"), Required(ErrorMessage = "Kindly Indicate the {0} for this drug")]
        [Display(Name = "Number of Days")]
        public byte? NumberOfDays { get; set; }

        public bool ServiceStatus { get; set; }

        [Display(Name = "Date requested")]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(DataFormatString = "{0:D}")]
        public DateTime DateRequested { get; set; }

        [Display(Name = "Requested by?"), MaxLength(30)]
        [Column(TypeName = "varchar")]
        public string RequestingOficcer { get; set; }

        public decimal? Cost { get; set; }
        public double Dose { get; set; }
    }

    public class PharmacyPayments
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} is required"), MaxLength(20)]
        [Display(Name = "PatientID")]
        [Remote("VerifyUniqueID", "Helpers")]
        public string PatientID { get; set; }

        [Display(Name = "QTY")]
        public byte QuantityIssued { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "{0} must be {1} to {2} long")]
        public string Receipt { get; set; }

        public Guid ID { get; set; }
    }

    public class Dispensary
    {
        [Column(TypeName = "varchar")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} is required"), MaxLength(20)]
        [Display(Name = "PatientID")]
        [Remote("VerifyUniqueID", "Helpers")]
        public string PatientID { get; set; }

        public string DrugName { get; set; }

        [Range(1, 6), Required(ErrorMessage = "Kindly Indicate the {0} for this drug")]
        public double Frequency { get; set; }

        [Range(1, 120), Required(ErrorMessage = "Kindly Indicate the {0} for this drug")]
        [Display(Name = "Number of Days")]
        public double NumberOfDays { get; set; }

        [Display(Name = "Date served")]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(DataFormatString = "{0:D}")]
        public DateTime? DateServed { get; set; }

        [Required, Display(Name = "User Name"), MaxLength(30)]
        [Column(TypeName = "varchar")]
        public string ServingOficcer { get; set; }

        [Range(0, float.MaxValue, ErrorMessage = "{0} should be greater than {0}")]
        [Column(TypeName = "smallmoney")]
        [Display(Name = "Cost")]
        public decimal Cost { get; set; }

        public Guid ID { get; set; }
    }

    public class PatientDrugHistory
    {
        public string PatientID { get; set; }

        [Display(Name = "Drug")]
        public string DrugName { get; set; }

        [Display(Name = "Status")]
        public bool ServedStatus { get; set; }

        [Display(Name = "Date"), DisplayFormat(DataFormatString = "{0:D}")]
        public Nullable<DateTime> DateServed { get; set; }

        public string Physician { get; set; }

        public byte Days { get; set; }

        [Display(Name = "FRQ")]
        public byte Frequency { get; set; }
    }

    public class DrugsVm
    {
        [Key]
        [Column(TypeName = "varchar")]
        [StringLength(100, ErrorMessage = "{0} should not exceed {1} characters")]
        [Display(Name = "Drug")]
        public string DrugName { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(20, ErrorMessage = "{0} should be less than {1} characters")]
        [Display(Name = "Desc")]
        public string Description { get; set; }

        [Range(0, float.MaxValue, ErrorMessage = "{0} should be greater than {0}")]
        [Column(TypeName = "smallmoney")]
        [Display(Name = "Cost")]
        public decimal UnitCost { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(5, ErrorMessage = "{0} should be less than {1} characters")]
        [Required(ErrorMessage = "Indicate the {0} of this drug")]
        [Display(Name = "Units")]
        public string MeasurementUnit { get; set; }
    }

    public class DrugQuantityVm
    {
        public Guid ID { get; set; }

        public byte QuantityRequested { get; set; }

        public string PatientID { get; set; }

        public int QuantityIssued { get; set; }
    }

    public class DispenseVm
    {
        public Guid ID { get; set; }

        public string PatientID { get; set; }
    }
}
