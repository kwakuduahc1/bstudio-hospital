namespace WinClinic.Model.Pharmacy
{
    using Accounts;
    using Pharmacy;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class DrugCodes
    {
        [Key]
        public int DrugCodesID { get; set; }

        [Required]
        public int DrugsID { get; set; }

        [StringLength(150)]
        [Required]
        public string DrugCode { get; set; }

        [Required]
        public int SchemesID { get; set; }

        [Required]
        [Range(0.01, 500.00)]
        [Column(TypeName = "smallmoney")]
        public decimal Cost { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        [Timestamp, ConcurrencyCheck]
        public byte[] Concurrency { get; set; }

        public virtual Drugs Drugs { get; set; }

        public virtual Schemes Schemes { get; set; }
    }
}
