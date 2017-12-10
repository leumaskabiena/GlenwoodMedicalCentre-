namespace GlenwoodMed.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingId = c.Int(nullable: false, identity: true),
                        PatientFullName = c.String(),
                        PatientID = c.String(),
                        Telephone = c.String(),
                        Email = c.String(),
                        reason = c.String(),
                        Date = c.String(),
                        Time = c.String(),
                        Time_start = c.String(),
                        Time_end = c.String(),
                    })
                .PrimaryKey(t => t.BookingId);
            
            CreateTable(
                "dbo.Clinics",
                c => new
                    {
                        ClinicId = c.Int(nullable: false, identity: true),
                        ClinicName = c.String(),
                    })
                .PrimaryKey(t => t.ClinicId);
            
            CreateTable(
                "dbo.CollectionDrugs",
                c => new
                    {
                        collectionID = c.Int(nullable: false, identity: true),
                        PatientID = c.Int(nullable: false),
                        Prescription = c.String(),
                        PatientName = c.String(),
                        Collected = c.Boolean(nullable: false),
                        PaymentType = c.String(),
                        Dosage = c.String(),
                    })
                .PrimaryKey(t => t.collectionID);
            
            CreateTable(
                "dbo.Drugs",
                c => new
                    {
                        DrugId = c.Int(nullable: false, identity: true),
                        DrugCode = c.String(),
                        DrugName = c.String(),
                        DrugCategory = c.String(),
                        DrugDescription = c.String(),
                        Quantity = c.Int(nullable: false),
                        Supplier = c.String(),
                        ExpiryDate = c.DateTime(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.DrugId);
            
            CreateTable(
                "dbo.Consultations",
                c => new
                    {
                        ConsultId = c.Int(nullable: false, identity: true),
                        U_Id = c.Int(nullable: false),
                        DrugId = c.Int(nullable: false),
                        PriceId = c.Int(nullable: false),
                        illness = c.String(),
                        ConsultTime = c.String(),
                        ConsultDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentType = c.String(),
                        patientfullname = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ConsultId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false),
                        FullName = c.String(),
                        Surname = c.String(),
                        Title = c.String(),
                        Age = c.String(),
                        Password = c.String(),
                        MaritalStatus = c.String(),
                        DOB = c.String(),
                        Sex = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        Address3 = c.String(),
                        PostalCode = c.Int(),
                        Telephone = c.String(),
                        Employer = c.String(),
                        EmployerTelephone = c.String(),
                        Occupation = c.String(),
                        NationalId = c.String(),
                        Status = c.String(),
                        PatientAllergy = c.String(),
                        MedicalAidName = c.String(),
                        MedicalAidNo = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey })
                .ForeignKey("dbo.AspNetUsers", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.IdentityRole_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.IdentityUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.Symptoms",
                c => new
                    {
                        Symptomsid = c.Int(nullable: false, identity: true),
                        symptomsname = c.String(),
                    })
                .PrimaryKey(t => t.Symptomsid);
            
            CreateTable(
                "dbo.ConsultationDrugs",
                c => new
                    {
                        DrugToConsultId = c.Int(nullable: false, identity: true),
                        PrescriptionId = c.Int(nullable: false),
                        DrugId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        DrugName = c.String(),
                    })
                .PrimaryKey(t => t.DrugToConsultId);
            
            CreateTable(
                "dbo.ConsultationPrices",
                c => new
                    {
                        PriceId = c.Int(nullable: false, identity: true),
                        PriceCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateEdited = c.String(),
                        DateCreated = c.String(),
                    })
                .PrimaryKey(t => t.PriceId);
            
            CreateTable(
                "dbo.Dependents",
                c => new
                    {
                        DependentId = c.Int(nullable: false, identity: true),
                        PatientId = c.String(),
                        Age = c.String(),
                        Title = c.String(),
                        IdentityNo = c.String(),
                        DependentFname = c.String(),
                        DependentSname = c.String(),
                        DependentRole = c.String(),
                        DependentAllergy = c.String(),
                        DOB_Dependent = c.String(),
                        Sex = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.DependentId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.DrugModels",
                c => new
                    {
                        DrugId = c.Int(nullable: false, identity: true),
                        DrugCode = c.String(nullable: false),
                        DrugName = c.String(nullable: false),
                        DrugCategory = c.String(nullable: false),
                        DrugDescription = c.String(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Supplier = c.String(nullable: false),
                        ExpiryDate = c.DateTime(nullable: false),
                        Status = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DrugId);
            
            CreateTable(
                "dbo.Email_services",
                c => new
                    {
                        emailID = c.Int(nullable: false, identity: true),
                        To = c.String(nullable: false),
                        Cc = c.String(),
                        Bcc = c.String(),
                        Subject = c.String(),
                        Body = c.String(nullable: false),
                        StaffName = c.String(),
                    })
                .PrimaryKey(t => t.emailID);
            
            CreateTable(
                "dbo.FeedBacks",
                c => new
                    {
                        PatientId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Comment = c.String(),
                        Votes = c.String(),
                    })
                .PrimaryKey(t => t.PatientId);
            
            CreateTable(
                "dbo.FileUploadDBModels",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        ModelFile = c.Binary(),
                        PatientId = c.Int(nullable: false),
                        patientName = c.String(),
                    })
                .PrimaryKey(t => t.FileId);
            
            CreateTable(
                "dbo.HIVTestResults",
                c => new
                    {
                        TestId = c.Int(nullable: false, identity: true),
                        PatientName = c.String(),
                        Date = c.DateTime(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        TestigLocation = c.String(),
                        Gender = c.String(),
                        NextAppointment = c.DateTime(nullable: false),
                        HIVtestType = c.String(),
                        Status = c.String(),
                        PatientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TestId);
            
            CreateTable(
                "dbo.PatientFiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        File = c.Binary(),
                        PatientId = c.Int(nullable: false),
                        patientName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientId = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Surname = c.String(),
                        Title = c.String(),
                        Email = c.String(),
                        MaritalStatus = c.String(),
                        Age = c.String(),
                        DOB = c.String(),
                        Sex = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        Address3 = c.String(),
                        PostalCode = c.Int(nullable: false),
                        Telephone = c.String(),
                        Employer = c.String(),
                        EmployerTelephone = c.String(),
                        Occupation = c.String(),
                        NationalId = c.String(),
                        Status = c.String(),
                        PatientAllergy = c.String(),
                        MedicalAidName = c.String(),
                        MedicalAidNo = c.String(),
                    })
                .PrimaryKey(t => t.PatientId);
            
            CreateTable(
                "dbo.Prescriptions",
                c => new
                    {
                        p_MedicineId = c.Int(nullable: false, identity: true),
                        p_Medicine = c.String(),
                        p_PatientName = c.String(),
                        p_Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.p_MedicineId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TestResults",
                c => new
                    {
                        ResultId = c.Int(nullable: false, identity: true),
                        Test = c.String(nullable: false),
                        TestType = c.String(nullable: false),
                        place = c.String(nullable: false),
                        ray1 = c.String(),
                        ray2 = c.String(),
                        ray3 = c.String(),
                        ray4 = c.String(),
                        ray5 = c.String(),
                        name1 = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        postalAddress = c.String(nullable: false),
                        telephoneNo = c.String(),
                        emailAddress = c.String(nullable: false),
                        PatientName = c.String(),
                        A_Patient = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ResultId);
            
            CreateTable(
                "dbo.WorkingTimes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        hour_start = c.String(),
                        hour_end = c.String(),
                        text = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ConsultDrugs",
                c => new
                    {
                        ConsultId = c.Int(nullable: false),
                        DrugId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ConsultId, t.DrugId })
                .ForeignKey("dbo.Consultations", t => t.ConsultId, cascadeDelete: true)
                .ForeignKey("dbo.Drugs", t => t.DrugId, cascadeDelete: true)
                .Index(t => t.ConsultId)
                .Index(t => t.DrugId);
            
            CreateTable(
                "dbo.ConsultationSymptoms",
                c => new
                    {
                        ConsultId = c.Int(nullable: false),
                        Symptomsid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ConsultId, t.Symptomsid })
                .ForeignKey("dbo.Consultations", t => t.ConsultId, cascadeDelete: true)
                .ForeignKey("dbo.Symptoms", t => t.Symptomsid, cascadeDelete: true)
                .Index(t => t.ConsultId)
                .Index(t => t.Symptomsid);
            
            CreateTable(
                "dbo.Collection_Drugs",
                c => new
                    {
                        CollectionId = c.Int(nullable: false),
                        DrugId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CollectionId, t.DrugId })
                .ForeignKey("dbo.CollectionDrugs", t => t.CollectionId, cascadeDelete: true)
                .ForeignKey("dbo.Drugs", t => t.DrugId, cascadeDelete: true)
                .Index(t => t.CollectionId)
                .Index(t => t.DrugId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "IdentityUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "IdentityUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.IdentityUserClaims", "IdentityUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "IdentityRole_Id", "dbo.AspNetRoles");
            DropForeignKey("dbo.Dependents", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Collection_Drugs", "DrugId", "dbo.Drugs");
            DropForeignKey("dbo.Collection_Drugs", "CollectionId", "dbo.CollectionDrugs");
            DropForeignKey("dbo.ConsultationSymptoms", "Symptomsid", "dbo.Symptoms");
            DropForeignKey("dbo.ConsultationSymptoms", "ConsultId", "dbo.Consultations");
            DropForeignKey("dbo.ConsultDrugs", "DrugId", "dbo.Drugs");
            DropForeignKey("dbo.ConsultDrugs", "ConsultId", "dbo.Consultations");
            DropForeignKey("dbo.Consultations", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Collection_Drugs", new[] { "DrugId" });
            DropIndex("dbo.Collection_Drugs", new[] { "CollectionId" });
            DropIndex("dbo.ConsultationSymptoms", new[] { "Symptomsid" });
            DropIndex("dbo.ConsultationSymptoms", new[] { "ConsultId" });
            DropIndex("dbo.ConsultDrugs", new[] { "DrugId" });
            DropIndex("dbo.ConsultDrugs", new[] { "ConsultId" });
            DropIndex("dbo.Dependents", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "IdentityUser_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "IdentityUser_Id" });
            DropIndex("dbo.IdentityUserClaims", new[] { "IdentityUser_Id" });
            DropIndex("dbo.Consultations", new[] { "ApplicationUser_Id" });
            DropTable("dbo.Collection_Drugs");
            DropTable("dbo.ConsultationSymptoms");
            DropTable("dbo.ConsultDrugs");
            DropTable("dbo.WorkingTimes");
            DropTable("dbo.TestResults");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Prescriptions");
            DropTable("dbo.Patients");
            DropTable("dbo.PatientFiles");
            DropTable("dbo.HIVTestResults");
            DropTable("dbo.FileUploadDBModels");
            DropTable("dbo.FeedBacks");
            DropTable("dbo.Email_services");
            DropTable("dbo.DrugModels");
            DropTable("dbo.Dependents");
            DropTable("dbo.ConsultationPrices");
            DropTable("dbo.ConsultationDrugs");
            DropTable("dbo.Symptoms");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.IdentityUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Consultations");
            DropTable("dbo.Drugs");
            DropTable("dbo.CollectionDrugs");
            DropTable("dbo.Clinics");
            DropTable("dbo.Bookings");
        }
    }
}
