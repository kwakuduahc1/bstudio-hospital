using System;
using System.ComponentModel.DataAnnotations;

namespace bStudioHospital.Model.ViewModels
{
    public class PhysicianDrugRequisition
    {
        public int ID { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 15)]
        public string PatientsID { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public int DrugCodesID { get; set; }

        public string Description { get; set; }

        public string MeasurementUnit { get; set; }

        [Required(ErrorMessage = "Kindly Indicate the {0} for this drug")]
        public byte? Frequency { get; set; }

        [Range(1, 100, ErrorMessage = "{0} is invalid")]
        [Required(ErrorMessage = "Kindly Indicate the {0} for this drug")]
        public byte? NumberOfDays { get; set; }

        public bool IsServed { get; set; }

        public DateTime DateRequested { get; set; }

        [MaxLength(30)]
        public string RequestingOficcer { get; set; }

        public decimal Cost { get; set; }

        public double Dose { get; set; }
    }

    public class PharmacyPayments
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} is required")]
        [StringLength(20, MinimumLength = 15)]
        public string PatientsID { get; set; }

        public byte QuantityIssued { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "{0} must be {1} to {2} long")]
        public string Receipt { get; set; }

        public Guid ID { get; set; }
    }

    public class Dispensary
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} is required")]
        [StringLength(20, MinimumLength = 15)]
        public string PatientsID { get; set; }

        public string DrugName { get; set; }

        [Range(1, 6), Required(ErrorMessage = "Kindly Indicate the {0} for this drug")]
        public double Frequency { get; set; }

        [Range(1, 120), Required(ErrorMessage = "Kindly Indicate the {0} for this drug")]
        public double NumberOfDays { get; set; }

        public DateTime DateServed { get; set; }

        [Required, Display(Name = "User Name")]
        [MaxLength(30)]
        public string ServingOficcer { get; set; }

        [Range(0, float.MaxValue, ErrorMessage = "{0} should be greater than {0}")]
        public decimal Cost { get; set; }

        public Guid ID { get; set; }
    }

    public class PatientDrugHistory
    {
        [StringLength(20, MinimumLength = 15)]
        public string PatientsID { get; set; }

        public string DrugName { get; set; }

        public bool IsServed { get; set; }

        [Display(Name = "Date"), DisplayFormat(DataFormatString = "{0:D}")]
        public DateTime DateServed { get; set; }

        public string Physician { get; set; }

        public byte Days { get; set; }

        public byte Frequency { get; set; }
    }

    public class DrugsVm
    {
        [Key]
        [StringLength(100, ErrorMessage = "{0} should not exceed {1} characters")]
        public string DrugName { get; set; }

        [StringLength(20, ErrorMessage = "{0} should be less than {1} characters")]
        public string Description { get; set; }

        [Range(0, float.MaxValue, ErrorMessage = "{0} should be greater than {0}")]
        public decimal UnitCost { get; set; }

        [StringLength(5, ErrorMessage = "{0} should be less than {1} characters")]
        [Required(ErrorMessage = "Indicate the {0} of this drug")]
        public string MeasurementUnit { get; set; }
    }

    public class DrugQuantityVm
    {
        public Guid ID { get; set; }

        public byte QuantityRequested { get; set; }

        public string PatientsID { get; set; }

        public int QuantityIssued { get; set; }
    }

    public class DispenseVm
    {
        public Guid ID { get; set; }

        public string PatientsID { get; set; }
    }
}
