using bStudioHospital.Model.ConsultingRoom;
using bStudioHospital.Model.Records;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bStudioHospital.Model.NursingCare
{
    public class PatientAdmissions
    {
        public long PatientAdmissionsID { get; set; }

        [Required]
        public string PatientID { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string WardName { get; set; }

        public DateTime DateAdmitted { get; set; }
        
        [StringLength(30)]
        public string UserName { get; set; }

        [DefaultValue(false)]
        public bool Discharged { get; set; }

        public DateTime? DateDischarged { get; set; }

        [Timestamp]
        public byte[] Concurrency { get; set; }

        public virtual Patients Patients { get; set; }

        public virtual Wards Wards { get; set; }

        public virtual ICollection<AdmissionInstructions> AdmissionInstructions { get; set; }
    }
}
