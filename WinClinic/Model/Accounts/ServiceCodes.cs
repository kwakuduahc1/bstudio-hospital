namespace WinClinic.Model.Accounts
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class ServiceCodes
    {
        [Key]
        public Guid ServiceCodesID { get; set; }

        [Required]
        [StringLength(50)]
        public string ServiceCode { get; set; }

        [Required]
        public Guid SchemesID { get; set; }

        [Required]
        public Guid ServicesID { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Cost { get; set; }

        [DefaultValue(true)]
        public bool Status { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        [Timestamp, ConcurrencyCheck]
        public byte[] Concurrency { get; set; }

        public virtual Schemes Schemes { get; set; }

        public virtual Services Services { get; set; }
    }
}
