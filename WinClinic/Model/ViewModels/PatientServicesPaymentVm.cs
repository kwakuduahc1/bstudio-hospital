using System;
using System.ComponentModel.DataAnnotations;

namespace WinClinic
{
    public class PatientServicesPaymentVm
    {
        [Required]
        public string PatientsID { get; set; }

        [Required]
        public Guid ID { get; set; }

        [StringLength(10,MinimumLength =3)]
        [Required]
        public string Receipt { get; set; }

        [StringLength(100)]
        [Required]
        public string Service { get; set; }
    }
}