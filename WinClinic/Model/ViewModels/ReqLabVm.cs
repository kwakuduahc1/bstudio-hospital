﻿using System.ComponentModel.DataAnnotations;

namespace WinClinic
{
    public class ReqLabVm
    {
        [Required]
        [StringLength(20, MinimumLength = 15)]
        public string PatientsID { get; set; }

        [Required]
        public short LabGroupsID { get; set; }

        [Required]
        public string GroupName { get; set; }
    }
}