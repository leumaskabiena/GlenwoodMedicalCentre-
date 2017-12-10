using GlenwoodMed.Data.Tables;
using GlenwoodMed.Model;
using GlenwoodMed.Model.ViewModels;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.Data
{
    //public class DataContext : DbContext, IDbContext
    //{
    //    public DataContext()
    //        : base("Conn")
    //    {
    //    }

    //    //#region Properties

    //    public DbSet<Clinic> Clinic { get; set; }

    //    public DbSet<Booking> Bookings { get; set; }
    //    public DbSet<Consultation> Consultations { get; set; }
    //    public DbSet<ConsultationPrice> ConsultationPrices { get; set; }
    //    public DbSet<Drug> Drugs { get; set; }
    //    public DbSet<Patient> Patients { get; set; }
    //    public DbSet<CollectionDrugs> CollectionDrugs { get; set; }
    //    public DbSet<GlenwoodMed.Data.Tables.PatientModelDetails> PatientModelDetails { get; set; }
    //    //[NotMappedAttribute]
    //    //public DbSet<GlenwoodMed.Model.ViewModels.PatientModelDetails> VPatientModelDetails { get; set; }
    //    public DbSet<PatientFile> PatientFiles { get; set; }
    //    public DbSet<FileUploadDBModel> FileUploadDBModels { get; set; }
    //    public DbSet<Prescription> Prescriptions { get; set; }
    //    public DbSet<TestResult> TestResults { get; set; }
    //    public DbSet<Dependent> Dependents { get; set; }
    //    public DbSet<Email_services> email_services { get; set; }
    //    public DbSet<ConsultationDrug> ConsultationDrugs { get; set; }
    //    public DbSet<WorkingTime> WorkingTimes { get; set; }
    //    //public DbSet<ClinicView> ClinicViews { get; set; }
    //    //public DbSet<DependentModel> DependentModels { get; set; }
    //    //#endregion

    //    public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
    //    {
    //        return base.Set<TEntity>();
    //    }

    //    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    //    {
    //        modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

    //        modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
    //        modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
    //        modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
    //    }

    //    public System.Data.Entity.DbSet<GlenwoodMed.Model.ViewModels.DrugModel> DrugModels { get; set; }

    //    //public System.Data.Entity.DbSet<GlenwoodMed.Model.RegisterModel> RegisterModels { get; set; }

    //    //public System.Data.Entity.DbSet<GlenwoodMed.Model.ViewModels.EditProfileModel> EditProfileModels { get; set; }
    //    //public System.Data.Entity.DbSet<GlenwoodMed.Model.ViewModels.PatientModelDetails> PatientModelDetails { get; set; }

    //    //public System.Data.Entity.DbSet<GlenwoodMed.Data.ApplicationUser> ApplicationUsers { get; set; }
       
    //}

    public class DataContext : IdentityDbContext, IDbContext
    {
        public DataContext()
            : base("Conn")
        {

        }

        //#region Properties

        public DbSet<Clinic> Clinic { get; set; }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Consultation> Consultations { get; set; }
        public DbSet<ConsultationPrice> ConsultationPrices { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<CollectionDrugs> CollectionDrugs { get; set; }
        public DbSet<Symptoms> Symptomses { get; set; }
        public DbSet<HIVPatientFile> HIVPatientFiles { get; set; }
        //public DbSet<GlenwoodMed.Data.Tables.PatientModelDetails> PatientModelDetails { get; set; }
        //[NotMappedAttribute]
        //public DbSet<GlenwoodMed.Model.ViewModels.PatientModelDetails> VPatientModelDetails { get; set; }
        public DbSet<PatientFile> PatientFiles { get; set; }
        public DbSet<Cust> Custs { get; set; }
        public DbSet<FileUploadDBModel> FileUploadDBModels { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<MedicalCertificate> MedicalCertificates { get; set; }
        public DbSet<Result> Results { get; set; }
        //public DbSet<User> Users { get; set; }
        public DbSet<HIVTestResult> HIVTestResults { get; set; }
        public DbSet<PatientAddress> PatientAddresses { get; set; }
        public DbSet<Dependent> Dependents { get; set; }
        public DbSet<Email_services> email_services { get; set; }
        public DbSet<ConsultationDrug> ConsultationDrugs { get; set; }
        public DbSet<WorkingTime> WorkingTimes { get; set; }
        public DbSet<FeedBack> FeedBacks { get; set; }
        public DbSet<Referral> Referrals { get; set; }
        //public DbSet<ClinicView> ClinicViews { get; set; }
        //public DbSet<DependentModel> DependentModels { get; set; }

        public DbSet<Illness> Illness { get; set; }

        public DbSet<TestType> TestTypes { get; set; }
        public DbSet<Procedure> Procedures { get; set; }
        public DbSet<ProcedureItem> ProcedureItem { get; set; }
        public DbSet<Drug_Properties> Drug_Properties { get; set; }
        //#endregion

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Consultation>()
                 .HasMany(c => c.Symptomses).WithMany(i => i.Consultations)
                 .Map(t => t.MapLeftKey("ConsultId")
                     .MapRightKey("Symptomsid")
                     .ToTable("ConsultationSymptoms"));

            modelBuilder.Entity<Consultation>()
               .HasMany(c => c.Illness).WithMany(i => i.Consultations)
               .Map(t => t.MapLeftKey("ConsultId")
                   .MapRightKey("IllnessId")
                   .ToTable("ConsultationIllness"));

            modelBuilder.Entity<Consultation>()
               .HasMany(c => c.CustLis).WithMany(i => i.consultation)
               .Map(t => t.MapLeftKey("ConsultId")
                   .MapRightKey("custId")
                   .ToTable("ConsultationMedicine"));

            modelBuilder.Entity<Consultation>()
              .HasMany(c => c.TestTypes).WithMany(i => i.Consultations)
              .Map(t => t.MapLeftKey("ConsultId")
                  .MapRightKey("TestTypeID")
                  .ToTable("ConsultTests"));

            modelBuilder.Entity<Consultation>()
               .HasMany(c => c.Drugs).WithMany(i => i.Consultations)
               .Map(t => t.MapLeftKey("ConsultId")
                   .MapRightKey("DrugId")
                   .ToTable("ConsultDrugs"));


            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<IdentityUser>().ToTable("AspNetUsers");

            EntityTypeConfiguration<ApplicationUser> table =
                modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUsers");

            table.Property((ApplicationUser u) => u.UserName).IsRequired();

            //EntityTypeConfiguration<Patient> patient_table =
            //    modelBuilder.Entity<Patient>().ToTable("AspNetUsers");

            //patient_table.Property((Patient u) => u.UserName).IsRequired();

            modelBuilder.Entity<ApplicationUser>().HasMany<IdentityUserRole>((ApplicationUser u) => u.Roles);
            //modelBuilder.Entity<Patient>().HasMany<IdentityUserRole>((Patient u) => u.Roles);

            modelBuilder.Entity<IdentityUserRole>().HasKey((IdentityUserRole r) =>
                new { UserId = r.UserId, RoleId = r.RoleId }).ToTable("AspNetUserRoles");

            EntityTypeConfiguration<IdentityUserLogin> entityTypeConfiguration =
                modelBuilder.Entity<IdentityUserLogin>().HasKey((IdentityUserLogin l) =>
                    new
                    {
                        UserId = l.UserId,
                        LoginProvider = l.LoginProvider,
                        ProviderKey
                            = l.ProviderKey
                    }).ToTable("AspNetUserLogins");

            modelBuilder.Entity<IdentityRole>().ToTable("AspNetRoles");

            EntityTypeConfiguration<ApplicationRole> entityTypeConfiguration1 = modelBuilder.Entity<ApplicationRole>().ToTable("AspNetRoles");

            entityTypeConfiguration1.Property((ApplicationRole r) => r.Name).IsRequired();

        }
    }
}
