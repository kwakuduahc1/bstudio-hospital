using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WinClinic.Model.Accounts
{
    public partial class ServiceCodes
    {
        [Key]
        public int ServiceCodesID { get; set; }

        [Required]
        [StringLength(50)]
        public string ServiceCode { get; set; }

        [Required]
        public int SchemesID { get; set; }

        [Required]
        public int ServicesID { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        [Column(TypeName = "smallmoney")]
        public decimal Cost { get; set; }

        [DefaultValue(true)]
        public bool Status { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        [Timestamp, ConcurrencyCheck]
#pragma warning disable CA1819 // Properties should not return arrays
        public byte[] Concurrency { get; set; }
#pragma warning restore CA1819 // Properties should not return arrays

        public virtual Schemes Schemes { get; set; }

        public virtual Services Services { get; set; }
    }
}
