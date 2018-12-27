using WinClinic.Model.Records;
using System;
using System.ComponentModel.DataAnnotations;

namespace WinClinic.Model.ConsultingRoom
{
    public class PatientConsultation
    {
        [Key]
        public Guid PatientConsultationID { get; set; }

        [Required]
        public Guid PatientAttendanceID { get; set; }

        [StringLength(500, ErrorMessage = "{0} should be below {1} characters")]
        [Required(AllowEmptyStrings = false)]
        public string Complaints { get; set; }

        [StringLength(500)]
        public string Examination { get; set; }

        [StringLength(500, ErrorMessage = "{0} should be below {1} characters")]
        public string PhysicianNotes { get; set; }

        public DateTime DateAdded { get; set; }

        public string UserName { get; set; }

        [ConcurrencyCheck, Timestamp]
        public byte[] Concurrency { get; set; }

        public virtual PatientAttendance PatientAttendance { get; set; }
    }
}
