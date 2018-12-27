namespace WinClinic.Model
{
    using Accounts;
    using WinClinic.Model.Laboratory;
    using ConsultingRoom;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using NursingCare;
    using Pharmacy;
    using Records;
    using Services;
    using System;

    public partial class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
          : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Schemes>(x => x.HasData(new Schemes { Description = "National Health Insurance", Scheme = "NHIS", Status = true, SchemesID = Guid.Parse("7A45E43C-138F-4D59-8FD8-561DA7862834") }));
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }


        public virtual DbSet<DrugCodes> DrugCodes { get; set; }

        public virtual DbSet<Drugs> Drugs { get; set; }

        public virtual DbSet<Schemes> Schemes { get; set; }

        public virtual DbSet<ServiceCodes> ServiceCodes { get; set; }

        public virtual DbSet<Accounts.Services> Services { get; set; }

        public virtual DbSet<DiagnosticCodes> DiagnosticCodes { get; set; }

        public virtual DbSet<Patients> Patients { get; set; }

        public virtual DbSet<PatientAttendance> PatientAttendance { get; set; }

        public virtual DbSet<OPD.OPD> OpdHistory { get; set; }

        public virtual DbSet<PatientServices> PatientServices { get; set; }

        public virtual DbSet<PatientDrugs> PatientDrugs { get; set; }

        public virtual DbSet<PatientDiagnosis> PatientDiagnosis { get; set; }

        public virtual DbSet<Diagnoses> Diagnoses { get; set; }

        public virtual DbSet<PatientConsultation> PatientConsultations { get; set; }

        public virtual DbSet<Staff.Staff> Staff { get; set; }

        public virtual DbSet<ServiceTypes> ServiceTypes { get; set; }

        public virtual DbSet<Wards> Wards { get; set; }

        public virtual DbSet<PatientMedications> PatientMedications { get; set; }

        public virtual DbSet<DrugAdministrations> DrugAdministrations { get; set; }

        public virtual DbSet<PatientAdmissions> PatientAdmissions { get; set; }

        public virtual DbSet<AdmissionInstructions> AdmissionInstructions { get; set; }

        public virtual DbSet<NursesWards> NursesWards { get; set; }

        public virtual DbSet<PatientLaboratoryServices> PatientLaboratoryServices { get; set; }

        public virtual DbSet<LaboratoryServices> LaboratoryServices { get; set; }

        public virtual DbSet<LabGroups> LabGroups { get; set; }

    }
}