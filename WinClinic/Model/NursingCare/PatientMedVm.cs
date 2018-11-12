using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bStudioHospital.Model.NursingCare
{
    public class PatientMedVm
    {
        [Key]
        public Guid PatientMedVmID { get; set; }

        public string PatientID { get; set; }

        public string DrugName { get; set; }
    }
}
