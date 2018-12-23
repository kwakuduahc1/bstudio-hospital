using bStudioHospital.Model.Records;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WinClinic.Model.Records
{
    public class PatientDetails
    {
        [Key]
        [ForeignKey("Patients")]
        public string PatientsID { get; set; }

        [Required(ErrorMessage = "{0} is required"), MaxLength(100)]
        public string Address { get; set; }

        [Required, MaxLength(100)]
        public string Kin { get; set; }

        [Phone(ErrorMessage = "You must supply a valid phone number")]
        [StringLength(20, MinimumLength = 10, ErrorMessage = "Mobile number should be 10 characters long")]
        public string KinContact { get; set; }

        [DefaultValue(false)]
        public bool IsDependent { get; set; }

        [StringLength(20, MinimumLength = 15)]
        public string DependentID { get; set; }

        [DefaultValue(true)]
        public bool Status { get; set; }

        [DefaultValue(false)]
        public bool IsCapitated { get; set; }

        [Required]
        public Guid SchemesID { get; set; }

        [StringLength(20, MinimumLength = 5)]
        public string SchemeNumber { get; set; }

        [StringLength(200, ErrorMessage = "{0} must not exceed {1} characters")]
        [Required]
        public string Town { get; set; }

        public virtual Patients Patients { get; set; }
    }
}
