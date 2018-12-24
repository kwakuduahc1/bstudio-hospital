using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace bStudioHospital.Model.Records
{
    public class PatientAttendance
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 15)]
        public string PatientsID { get; set; }

        [Required]
        [StringLength(15)]
        [DefaultValue("Acute")]
        public string VisitType { get; set; }

        public DateTime DateSeen { get; set; }

        [MaxLength(50)]
        public string UserName { get; set; }

        [ConcurrencyCheck, Timestamp]
        public byte[] Concurrency { get; set; }

        public virtual Patients Patients { get; set; }
    }
}
