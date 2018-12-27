using WinClinic.Model.NursingCare;
using System;
using System.ComponentModel.DataAnnotations;

namespace WinClinic.Model.ConsultingRoom
{
    public class AdmissionInstructions
    {
        public long AdmissionInstructionsID { get; set; }

        public long PatientAdmissionsID { get; set; }

        [StringLength(200)]
        public string Instructions { get; set; }

        public DateTime DateAdded { get; set; }

        [Timestamp]
        public byte[] Concurrency { get; set; }

        public virtual PatientAdmissions PatientAdmissions { get; set; }
    }
}
