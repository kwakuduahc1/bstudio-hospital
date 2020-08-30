using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WinClinic.Model.Accounts;

namespace WinClinic.Model.Records
{
    public class Patients
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PatientsID { get; set; }

        [StringLength(20, MinimumLength = 6)]
        public string FolderID { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "{0} should be between {1} and {2} characters")]
        public string Surname { get; set; }

        [StringLength(50, ErrorMessage = "{0} should be between less than {1} characters")]
        public string OtherNames { get; set; }

        [Required]
        [StringLength(6, MinimumLength = 4)]
        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Range(0, 180)]
        public byte Age { get; set; }

        public string AgeTyepe { get; set; }

        [Phone(ErrorMessage = "Provide a valid phone number")]
        [StringLength(20, MinimumLength = 10, ErrorMessage = "Mobile number should be 10 numbers long")]
        [Required]
        public string MobileNumber { get; set; }

        [DisplayFormat(DataFormatString = "{0:D}")]
        public DateTime DateAdded { get; set; }

        [StringLength(50, MinimumLength = 10)]
        public string UserName { get; set; }

        [Required]
        public int SchemesID { get; set; }

        [ConcurrencyCheck, Timestamp]
        public byte[] Concurrency { get; set; }

        [ScaffoldColumn(false), NotMapped]
        public string FullName => $"{Surname} {OtherNames}";

        public virtual PatientDetails PatientDetails { get; set; }

        public virtual ICollection<PatientAttendance> PatientAttendance { get; set; }

        public virtual Schemes Schemes { get; set; }
    }
}
