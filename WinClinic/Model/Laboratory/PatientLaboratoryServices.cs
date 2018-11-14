﻿using bStudioHospital.Model.Records;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace bStudioHospital.Model.Laboratory
{
    public class PatientLaboratoryServices
    {
        [Key]
        public long PatientLaboratoryServicesID { get; set; }

        [StringLength(20, MinimumLength = 15)]
        public string PatientsID { get; set; }

        [Required]
        public Guid LaboratoryServicesID { get; set; }

        [StringLength(200)]
        [DefaultValue("")]
        public string Results { get; set; }

        [StringLength(30)]
        public string RequestingOfficer { get; set; }

        public DateTime DateRequested { get; set; }

        [DefaultValue(false)]
        public bool IsServed { get; set; }

        [StringLength(100)]
        public string Notes { get; set; }

        [StringLength(30)]
        public string AccountsOfficer { get; set; }

        [DefaultValue(0)]
        public decimal Amount { get; set; }

        [DefaultValue(false)]
        public bool IsPaid { get; set; }

        public DateTime? DatePaid { get; set; }

        [StringLength(30)]
        public string LabOfficer { get; set; }

        public DateTime DateServed { get; set; }

        [Timestamp, ConcurrencyCheck]
        public byte[] Concurrency { get; set; }

        public virtual Patients Patients { get; set; }

        public virtual LaboratoryServices LaboratoryService { get; set; }

    }
}