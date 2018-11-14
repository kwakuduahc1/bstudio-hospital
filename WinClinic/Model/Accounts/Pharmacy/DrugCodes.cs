namespace bStudioHospital.Model
{
    using Accounts;
    using Pharmacy;
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class DrugCodes
    {
        [Key]
        public Guid DrugCodesID { get; set; }

        [Required]
        public Guid DrugsID { get; set; }

        [StringLength(150)]
        [Required]
        public string DrugCode { get; set; }

        [Required]
        public Guid SchemesID { get; set; }

        [Required]
        [Range(0.01, 500.00)]
        public decimal Cost { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        [Timestamp]
        public byte[] Concurrency { get; set; }

        public virtual Drugs Drugs { get; set; }

        public virtual Schemes Schemes { get; set; }
    }
}
