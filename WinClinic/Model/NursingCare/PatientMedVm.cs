using System;
using System.ComponentModel.DataAnnotations;

namespace bStudioHospital.Model.NursingCare
{
    public class PatientMedVm
    {
        [Key]
        public Guid PatientMedVmID { get; set; }

        public string PatientsID { get; set; }

        public string DrugName { get; set; }
    }
}
