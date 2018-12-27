using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WinClinic.Model.Laboratory
{
    public class LaboratoryServices
    {
        [Key]
        public Guid LaboratoryServicesID { get; set; }

        [StringLength(100, MinimumLength = 2)]
        [Required(AllowEmptyStrings = false)]
        public string LaboratoryProcedure { get; set; }

        [Required]
        public short LabGroupsID { get; set; }

        [Timestamp]
        public byte[] Concurrency { get; set; }

        public virtual ICollection<PatientLaboratoryServices> PatientLaboratoryServices { get; set; }

        public virtual LabGroups LabGroup { get; set; }
    }
}
