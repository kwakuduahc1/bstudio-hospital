 using bStudioHospital.Model.Records;
using System;
using System.ComponentModel.DataAnnotations;

namespace bStudioHospital.Model.OPD
{
    public class OPD
    {
        [Key]
        public Guid ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} is required")]
        [StringLength(20, MinimumLength = 15)]
        public string PatientsID { get; set; }

        [StringLength(500, ErrorMessage = "{0} should not exceed {1} characters")]
        public string History { get; set; }

        [StringLength(500)]
        public string FirstAid { get; set; }

        [Range(60.0, 250.0, ErrorMessage = "Allowed values ranges from {0} to {1}")]
        public double Systolic { get; set; }

        [Range(40, 160, ErrorMessage = "Allowed values ranges from {0} to {1}")]
        public double Diastolic { get; set; }

        [Range(33.0, 45.0, ErrorMessage = "Allowed values ranges from {0} to {1}")]
        [Required(ErrorMessage = "{0} is required")]
        public double Temperature { get; set; }

        [Range(2.0, 200, ErrorMessage = "Allowed values ranges from {0} to {1} kg")]
        [Required(ErrorMessage = "Weight is required")]
        public double Weight { get; set; }

        [Range(30, 150, ErrorMessage = "Allowed values ranges from {0} to {1}")]
        public double Pulse { get; set; }

        [Range(12, 40, ErrorMessage = "Allowed values ranges from {0} to {1}")]
        public double Respiration { get; set; }

        public DateTime DateSeen { get; set; }

        [MaxLength(50)]
        public string UserName { get; set; }

        [ConcurrencyCheck, Timestamp]
        public byte[] Concurrency { get; set; }

        public virtual Patients Patients { get; set; }
    }
}
