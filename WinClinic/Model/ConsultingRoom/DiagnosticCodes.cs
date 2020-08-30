using WinClinic.Model.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WinClinic.Model.ConsultingRoom
{
    public class DiagnosticCodes
    {
        [Key]
        public int DiagnosticCodesID { get; set; }

        [StringLength(20)]
        [Required]
        public string GDRG { get; set; }

        [StringLength(15, MinimumLength = 3)]
        public string ICDCode { get; set; }

        public string Description { get; set; }

        [Required]
        public int SchemesID { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public int DiagnosesID { get; set; }

        [Required]
        [Range(0.0, double.MaxValue)]
        [Column(TypeName = "smallmoney")]
        public double Tariff { get; set; }

        public virtual ICollection<PatientDiagnosis> PatientDiagnoses { get; set; }

        public virtual Schemes Schemes { get; set; }

        public virtual Diagnoses Diagnoses { get; set; }
    }
}
