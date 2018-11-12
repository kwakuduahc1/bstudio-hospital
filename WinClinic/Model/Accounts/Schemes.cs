namespace bStudioHospital.Model.Accounts
{
    using Model;
    using Model.ConsultingRoom;
    using Records;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class Schemes
    {
        [Key]
        public Guid SchemesID { get; set; }

        [StringLength(100)]
        [Required]
        public string Scheme { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        [DefaultValue(true)]
        public bool Status { get; set; }

        [Timestamp]
        public byte[] Concurrency { get; set; }

        public virtual ICollection<DrugCodes> DrugCodes { get; set; }

        public virtual ICollection<ServiceCodes> ServiceCodes { get; set; }

        public ICollection<DiagnosticCodes> DiagnosticCodes { get; set; }

        public ICollection<Patients> Patients { get; set; }
    }
}
