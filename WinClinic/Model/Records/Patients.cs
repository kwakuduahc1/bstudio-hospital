using bStudioHospital.Model.Accounts;
using bStudioHospital.Model.ConsultingRoom;
using bStudioHospital.Model.NursingCare;
using bStudioHospital.Model.Pharmacy;
using bStudioHospital.Model.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bStudioHospital.Model.Records
{
    public class Patients
    {
        [Key]
        [StringLength(20, MinimumLength = 15)]
        public string PatientID { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "{0} should be between {1} and {2} characters")]
        public string Surname { get; set; }

        [StringLength(50, ErrorMessage = "{0} should be between less than {1} characters")]
        public string OtherNames { get; set; }

        [Required]
        [StringLength(6, MinimumLength = 4)]
        public string Gender { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "{0} is required"), MaxLength(100)]
        public string Address { get; set; }

        [Phone(ErrorMessage = "Provide a valid phone number")]
        [StringLength(20, MinimumLength = 10, ErrorMessage = "Mobile number should be 10 numbers long")]
        [Required]
        public string MobileNumber { get; set; }

        [StringLength(200, ErrorMessage = "{0} must not exceed {1} characters")]
        [Required]
        public string Town { get; set; }

        [Required, MaxLength(100)]
        public string Kin { get; set; }

        [Phone(ErrorMessage = "You must supply a valid phone number")]
        [StringLength(20, MinimumLength = 10, ErrorMessage = "Mobile number should be 10 characters long")]
        public string KinContact { get; set; }

        [DisplayFormat(DataFormatString = "{0:D}")]
        public DateTime DateAdded { get; set; }

        [StringLength(50, MinimumLength = 10)]
        public string UserName { get; set; }

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

        [ConcurrencyCheck, Timestamp]
        public byte[] Concurrency { get; set; }

        [ScaffoldColumn(false), NotMapped]
        public string FullName => $"{Surname} {OtherNames}";


        public virtual ICollection<PatientAttendance> PatientAttendance { get; set; }

        public virtual ICollection<OPD.OPD> OpdHistory { get; set; }

        public virtual ICollection<PatientServices> PatientServices { get; set; }

        public virtual ICollection<PatientDrugs> PatientDrugs { get; set; }

        public virtual ICollection<PatientConsultation> PatientConsultation { get; set; }

        public virtual Schemes Schemes { get; set; }

        public virtual ICollection<PatientMedications> PatientMedications { get; set; }

        public virtual ICollection<PatientAdmissions> PatientAdmissions { get; set; }
    }
}
