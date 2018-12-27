using System;
using System.ComponentModel.DataAnnotations;

namespace WinClinic.Model.NursingCare
{
    public class PatientMedVm
    {
        [Key]
        public Guid PatientMedVmID { get; set; }

        public string PatientsID { get; set; }

        public string DrugName { get; set; }
    }
}
