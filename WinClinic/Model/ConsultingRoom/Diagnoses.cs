using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WinClinic.Model.ConsultingRoom
{
    public class Diagnoses
    {
        [Key]
        public Guid DiagnosesID { get; set; }

        [StringLength(100, ErrorMessage = "{0} should be less than {1} characters")]
        [Required(ErrorMessage = "{0} is required", AllowEmptyStrings = false)]
        public string Diagnosis { get; set; }

        [StringLength(250, ErrorMessage = "{0} should not exceed {1} characters")]
        public string Description { get; set; }

        [ConcurrencyCheck, Timestamp]
        public byte[] Concurrency { get; set; }

        public DateTime DateAdded { get; set; }

        [MaxLength(30)]
        public string UserName { get; set; }

        public virtual ICollection<DiagnosticCodes> DiagnosticCodes { get; set; }
    }
}
