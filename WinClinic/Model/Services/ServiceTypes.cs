using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WinClinic.Model.Services
{
    public class ServiceTypes
    {
        [Key]
        public int ServiceTypesID { get; set; }

        [StringLength(30)]
        [Required(AllowEmptyStrings = false)]
        public string ServiceType { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        [DefaultValue(true)]
        public bool Status { get; set; }

        [Timestamp, ConcurrencyCheck]
        public byte[] Concurrency { get; set; }

        public virtual ICollection<Accounts.Services> Services { get; set; }
    }
}
