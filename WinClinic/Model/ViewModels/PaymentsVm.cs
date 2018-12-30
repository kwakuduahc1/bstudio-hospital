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
        public IList<DrugsVm> Drugs { get; set; }

        [Required]
        public IList<ServicesVm> Services { get; set; }

        public IList<Groups> Groups { get; set; }

        public string Receipt { get; set; }

        public Guid PaymentMethod { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public Guid PatientAttendanceID { get; set; }
    }

    public class LabsVm
    {
        public Guid LabsID { get; set; }

        public string Lab { get; set; }

        public decimal Amount { get; set; }

        public long LabGroupsID { get; set; }

        [Required]
        public Guid AttendanceID { get; set; }

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

    }
}
