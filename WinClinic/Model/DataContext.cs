namespace bStudioHospital.Model
{
    using System.Data.Entity;
    using Accounts;
    using Pharmacy;
    using Records;
    using Services;
    using ConsultingRoom;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using NursingCare;
    using bStudioHospital.Model.Laboratory;

    public partial class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataContext")
        {
            
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

        public virtual DbSet<Branches> Branches { get; set; }

        public virtual DbSet<PatientConsultation> PatientConsultations { get; set; }

        public virtual DbSet<Staff.Staff> Staff { get; set; }

        public virtual DbSet<AccountTokens> AccountTokens { get; set; }

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

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<DrugCodes>()
        //        .Property(e => e.DrugName)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<DrugCodes>()
        //        .Property(e => e.Scheme)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<DrugCodes>()
        //        .Property(e => e.DrugCode)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<DrugCodes>()
        //        .Property(e => e.Concurrency)
        //        .IsFixedLength();

        //    modelBuilder.Entity<Drugs>()
        //        .Property(e => e.DrugName)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Drugs>()
        //        .Property(e => e.GroupName)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Drugs>()
        //        .Property(e => e.Description)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Drugs>()
        //        .Property(e => e.Concurrency)
        //        .IsFixedLength();

        //    modelBuilder.Entity<Drugs>()
        //        .HasMany(e => e.DrugCodes)
        //        .WithRequired(e => e.Drugs)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<Schemes>()
        //        .Property(e => e.Scheme)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Schemes>()
        //        .Property(e => e.Description)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Schemes>()
        //        .Property(e => e.Concurrency)
        //        .IsFixedLength();

        //    modelBuilder.Entity<Schemes>()
        //        .HasMany(e => e.DrugCodes)
        //        .WithRequired(e => e.Schemes)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<Schemes>()
        //        .HasMany(e => e.ServiceCodes)
        //        .WithRequired(e => e.Schemes)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<ServiceCodes>()
        //        .Property(e => e.SchemesID)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<ServiceCodes>()
        //        .Property(e => e.Service)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<ServiceCodes>()
        //        .Property(e => e.ServiceCode)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<ServiceCodes>()
        //        .Property(e => e.Concurrency)
        //        .IsFixedLength();

        //    modelBuilder.Entity<Accounts.Services>()
        //        .Property(e => e.Service)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Accounts.Services>()
        //        .Property(e => e.ServiceTypesID)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Accounts.Services>()
        //        .Property(e => e.ServiceGroup)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Accounts.Services>()
        //        .Property(e => e.Concurrency)
        //        .IsFixedLength();

        //    modelBuilder.Entity<Accounts.Services>()
        //        .HasMany(e => e.ServiceCodes)
        //        .WithRequired(e => e.Services)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //}
    }
}