﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinClinic.Model.Laboratory
{
    public class LabGroups
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short LabGroupsID { get; set; }

        [StringLength(50)]
        [Required]
        public string GroupName { get; set; }

        [Range(0.1, 1000)]
        [Required]
        public decimal Cost { get; set; }

        [Timestamp]
        public byte[] Concurrency { get; set; }

        public ICollection<LaboratoryServices> LaboratoryServices { get; set; }
    }
}
