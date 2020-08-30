using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WinClinic.Model.ViewModels;

namespace WinClinic.Models.ViewModels
{
    public class PaymentsVm
    {
        public PatientsVm Patient { get; set; }

        [Required]
        public List<DrugsVm> Drugs { get; set; }

        [Required]
        public List<ServicesVm> Services { get; set; }

        public List<Groups> Groups { get; set; }

        public string Receipt { get; set; }

        public int PaymentMethod { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public int PatientAttendanceID { get; set; }

        public string UserName { get; set; }
    }

    public class LabsVm
    {
        public int LabsID { get; set; }

        public string Lab { get; set; }

        public decimal Amount { get; set; }

        public long LabGroupsID { get; set; }

        [Required]
        public int AttendanceID { get; set; }

        [Required]
        public long PatLabID { get; set; }
    }

    public class Groups
    {
        public long LabGroupsID { get; set; }

        public string GroupName { get; set; }

        public decimal Cost { get; set; }

        [Required]
        public List<LabsVm> Labs { get; set; }
        public int LaboratoryServicesID { get; set; }
    }
}
