using bStudioHospital.Model.Records;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace bStudioHospital.Model.NursingCare
{
    /// <summary>
    /// Nurse enters the medications which have been prescribed by the
    /// medical officer using this template
    /// </summary>
    public class PatientMedications
    {
        public PatientMedications() { }

        [Key]
        [Required]
       public Guid PatientMedicationsID { get; set; }

        [Required]
        public string PatientsID { get; set; }

        [StringLength(500)]
        [Required]
        public string DrugName { get; set; }

        [Range(0,6)]
        [Required]
        public byte Frequency { get; set; }

        [Range(0, 90)]
        [Required]
        public byte NumberOfDays { get; set; }

        [DefaultValue(false)]
        public bool Completed { get; set; }

        [StringLength(30)]
        public string UserName { get; set; }

        public DateTime DateAdded { get; set; }

        [Timestamp]
        public byte[] Concurrency { get; set; }

        public virtual ICollection<DrugAdministrations> DrugAdministration { get; set; }

        public virtual Patients Patients { get; set; }
    }
}