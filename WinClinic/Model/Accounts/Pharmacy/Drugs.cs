namespace WinClinic.Model.Pharmacy
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Drugs
    {
        [Key]
        public Guid DrugsID { get; set; }

        [StringLength(150)]
        [Required(AllowEmptyStrings = false)]
        public string DrugName { get; set; }

        [StringLength(100)]
        [DefaultValue("General")]
        public string GroupName { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Timestamp, ConcurrencyCheck]
        public byte[] Concurrency { get; set; }

        public DateTime DateAdded { get; set; }

        public virtual ICollection<DrugCodes> DrugCodes { get; set; }
    }
}
