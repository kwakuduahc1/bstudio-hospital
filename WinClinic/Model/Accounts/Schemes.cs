using WinClinic.Model.ConsultingRoom;
using WinClinic.Model.Records;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WinClinic.Model.Pharmacy;
using System.ComponentModel.DataAnnotations.Schema;

namespace WinClinic.Model.Accounts
{
    public class Schemes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SchemesID { get; set; }

        [StringLength(100, MinimumLength = 3)]
        [Required(AllowEmptyStrings =false)]
        public string Scheme { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        [DefaultValue(true)]
        public bool Status { get; set; }

        [Timestamp]
        public byte[] Concurrency { get; set; }

        public virtual ICollection<Patients> Patients { get; set; }

        public virtual ICollection<DrugCodes> DrugCodes { get; set; }

        public virtual ICollection<ServiceCodes> ServiceCodes { get; set; }

        public virtual ICollection<DiagnosticCodes> DiagnosticCodes { get; set; }

    }
}
