using System.ComponentModel.DataAnnotations;

namespace KingsMedicalVillage.Controllers
{
    public class LabResults
    {
        [Required(AllowEmptyStrings = false)]
        [StringLength(200, MinimumLength = 1)]
        public string Results { get; set; }

        [Required]
        public long PatientLaboratoryServicesID { get; set; }

        [Required]
        public string LaboratoryProcedure { get; set; }

        [Required]
        public string PatientID { get; set; }
    }
}