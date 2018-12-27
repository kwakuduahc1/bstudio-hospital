using WinClinic.Model.Records;
using System;
using System.ComponentModel.DataAnnotations;

namespace WinClinic.Model.ConsultingRoom
{
    public class PatientDiagnosis
    {
        [Key]
        public Guid PatientDiagnosisID { get; set; }

        [Required]
        public Guid PatientAttendanceID { get; set; }

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

        public virtual PatientAttendance PatientAttendance { get; set; }
    }
}
