using System.ComponentModel.DataAnnotations;

namespace WinClinic.Model.NursingCare
{
    public class DrugAdministrations
    {
        [Key]
        public long DrugAdministrationsID { get; set; }

        public long PatientMedicationsID { get; set; }

        [StringLength(30)]
        public string UserName { get; set; }

        [Timestamp]
        public byte[] Concurrency { get; set; }

        public virtual PatientMedications PatientMedications { get; set; }
    }
}
