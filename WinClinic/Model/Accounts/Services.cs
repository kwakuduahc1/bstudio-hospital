using WinClinic.Model.Services;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WinClinic.Model.Accounts
{
    public partial class Services
    {
        [Key]
        public int ServicesID { get; set; }

        [StringLength(200)]
        [Required]
        public string Service { get; set; }

        [Required]
        public int ServiceTypesID { get; set; }

        [Required]
        [StringLength(50)]
        // Type of service within the type. e.g. some services can have sub groups
        public string ServiceGroup { get; set; }

        [DefaultValue(true)]
        public bool Status { get; set; }

        [Timestamp]
        public byte[] Concurrency { get; set; }

        public virtual ICollection<ServiceCodes> ServiceCodes { get; set; }

        public virtual ServiceTypes ServiceTypes { get; set; }
    }
}
