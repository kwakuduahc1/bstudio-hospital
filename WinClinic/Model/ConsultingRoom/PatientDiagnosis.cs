using bStudioHospital.Model.Records;
using System;
using System.ComponentModel.DataAnnotations;

namespace bStudioHospital.Model.ConsultingRoom
{
    public class PatientDiagnosis
    {
        [Key]
        public Guid ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} is required"), MaxLength(20)]
        [StringLength(20, MinimumLength = 15)]
        public string PatientID { get; set; }

        [Required]
        public Guid DiagnosticCodesID { get; set; }

        [StringLength(200, ErrorMessage = "{0} should be less than {1} characters")]
        public string Description { get; set; }

        [ConcurrencyCheck, Timestamp]
        public byte[] Concurrency { get; set; }

        public DateTime DateAdded { get; set; }

        [MaxLength(30)]
        public string UserName { get; set; }

        public virtual DiagnosticCodes DiagnosticCodes { get; set; }

        public virtual Patients Patients { get; set; }
    }
}
