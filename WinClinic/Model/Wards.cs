using WinClinic.Model.NursingCare;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WinClinic.Model
{
    public class Wards
    {
        [Key]
        [StringLength(50)]
        public string WardName { get; set; }

        [Range(1, byte.MaxValue)]
        public byte Capacity { get; set; }

        [StringLength(30)]
        public string PatientType { get; set; }

        [DefaultValue(true)]
        public bool Status { get; set; }

        [Timestamp]
        public byte[] Concurrency { get; set; }

        public virtual ICollection<PatientAdmissions> PatientAdmissioins { get; set; }

        public virtual ICollection<NursesWards> NursesWards { get; set; }
    }
}
