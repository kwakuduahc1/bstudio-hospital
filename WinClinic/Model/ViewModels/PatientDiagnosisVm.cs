using WinClinic.Model.ConsultingRoom;
using System;
using System.ComponentModel.DataAnnotations;

namespace WinClinic
{
    public class PatientDiagnosisVm
    {
        [Required(AllowEmptyStrings = false)]
        [StringLength(20, MinimumLength = 8)]
        public string PatientsID { get; set; }

        [Required]
        public int DiagnosticCodesID { get; set; }

        [StringLength(50)]
        [Required(AllowEmptyStrings = false)]
        public string Diagnosis { get; set; }

        [StringLength(200, ErrorMessage = "{0} should be less than {1} characters")]
        public string Description { get; set; }

        public PatientDiagnosis Convert()
        {
            return new PatientDiagnosis
            {
                DateAdded = DateTime.Now,
                DiagnosticCodesID = DiagnosticCodesID,
         //       PatientsID = PatientsID
            };
        }
    }
}