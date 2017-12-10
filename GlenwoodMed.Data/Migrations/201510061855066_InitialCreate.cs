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
                        Physician = c.String(),
                        Date = c.String(),
                        Time = c.String(),
                        Time_start = c.String(),
                        Time_end = c.String(),
                        Status = c.Int(nullable: false),
                        PatientIdKey = c.Int(nullable: false),
                        bookingStatus = c.String(),
                        notificationStatus = c.Boolean(nullable: false),
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
                        DrugQuantity = c.Int(nullable: false),
                        Status = c.String(),
                        DrugPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CollectionDrugs_collectionID = c.Int(),
                    })
                .PrimaryKey(t => t.DrugId)
                .ForeignKey("dbo.CollectionDrugs", t => t.CollectionDrugs_collectionID)
                .Index(t => t.CollectionDrugs_collectionID);
            
            CreateTable(
                "dbo.Consultations",
                c => new
                    {
                        ConsultId = c.String(nullable: false, maxLength: 128),
                        PatientId = c.Int(nullable: false),
                        ConsultTime = c.String(),
                        ConsultDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Notes = c.String(),
                        collected = c.Boolean(nullable: false),
                        patientfullname = c.String(),
                        Amountpaid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TestTypePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProcedurePricee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ConsultId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Patients", t => t.PatientId)
                .Index(t => t.PatientId)
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
                        PatientNo = c.String(),
                        PatientAllergy = c.String(),
                        MedicalAidName = c.String(),
                        MedicalAidNo = c.String(),
                        Role = c.String(),
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
                "dbo.Custs",
                c => new
                    {
                        custId = c.String(nullable: false, maxLength: 128),
                        DrugId = c.String(),
                        Dosage = c.String(),
                        Quantity = c.Int(nullable: false),
                        ConsultationDrugs_collectionID = c.Int(),
                    })
                .PrimaryKey(t => t.custId)
                .ForeignKey("dbo.CollectionDrugs", t => t.ConsultationDrugs_collectionID)
                .Index(t => t.ConsultationDrugs_collectionID);
            
            CreateTable(
                "dbo.Illnesses",
                c => new
                    {
                        Illnessid = c.Int(nullable: false, identity: true),
                        Illnessname = c.String(),
                    })
                .PrimaryKey(t => t.Illnessid);
            
            CreateTable(
                "dbo.Procedures",
                c => new
                    {
                        procedureId = c.Int(nullable: false, identity: true),
                        procedureName = c.String(),
                        procedurePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.procedureId);
            
            CreateTable(
                "dbo.ProcedureItems",
                c => new
                    {
                        ProcedureitemID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Procedures_procedureId = c.Int(),
                    })
                .PrimaryKey(t => t.ProcedureitemID)
                .ForeignKey("dbo.Procedures", t => t.Procedures_procedureId)
                .Index(t => t.Procedures_procedureId);
            
            CreateTable(
                "dbo.Symptoms",
                c => new
                    {
                        Symptomsid = c.Int(nullable: false, identity: true),
                        symptomsname = c.String(),
                    })
                .PrimaryKey(t => t.Symptomsid);
            
            CreateTable(
                "dbo.TestTypes",
                c => new
                    {
                        TestTypeID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.TestTypeID);
            
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
                        PatientId = c.Int(nullable: false),
                        Age = c.String(),
                        Title = c.String(),
                        IdentityNo = c.String(),
                        DependentFname = c.String(),
                        DependentSname = c.String(),
                        DependentRole = c.String(),
                        DependentAllergy = c.String(),
                        DOB_Dependent = c.String(),
                        Sex = c.String(),
                    })
                .PrimaryKey(t => t.DependentId)
                .ForeignKey("dbo.Patients", t => t.PatientId)
                .Index(t => t.PatientId);
            
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
                        PatientNo = c.String(),
                        Role = c.String(),
                        ContentType = c.String(),
                        FileName = c.String(),
                        File = c.Binary(),
                        FileType = c.Int(nullable: false),
                        registeredDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PatientId);
            
            CreateTable(
                "dbo.PatientAddresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        PatientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AddressId)
                .ForeignKey("dbo.Patients", t => t.PatientId)
                .Index(t => t.PatientId);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.PatientId)
                .Index(t => t.PatientId);
            
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        File = c.Binary(),
                        PatientId = c.Int(nullable: false),
                        PatientName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.PatientId)
                .Index(t => t.PatientId);
            
            CreateTable(
                "dbo.DrugModels",
                c => new
                    {
                        DrugId = c.Int(nullable: false, identity: true),
                        DrugCode = c.String(nullable: false),
                        DrugName = c.String(nullable: false),
                        DrugCategory = c.String(nullable: false),
                        DrugDescription = c.String(nullable: false),
                        DrugQuantity = c.Int(nullable: false),
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
                .PrimaryKey(t => t.FileId)
                .ForeignKey("dbo.Patients", t => t.PatientId)
                .Index(t => t.PatientId);
            
            CreateTable(
                "dbo.HIVPatientFiles",
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
                "dbo.MedicalCertificates",
                c => new
                    {
                        MedcertificateId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        PatintName = c.String(nullable: false),
                        OpinonIllness = c.String(nullable: false),
                        Fitnessproblem = c.String(nullable: false),
                        StartingDate = c.String(nullable: false),
                        Enddate = c.String(nullable: false),
                        Comment = c.String(),
                        PatientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MedcertificateId);
            
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
                "dbo.Referrals",
                c => new
                    {
                        Ref_Id = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        Ref_date = c.DateTime(nullable: false),
                        Referred_Doctor = c.String(),
                        Patient_name = c.String(),
                        Patient_age = c.String(),
                        Patient_number = c.String(),
                        Reason = c.String(),
                    })
                .PrimaryKey(t => t.Ref_Id);
            
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
                "dbo.ConsultationMedicine",
                c => new
                    {
                        ConsultId = c.String(nullable: false, maxLength: 128),
                        custId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ConsultId, t.custId })
                .ForeignKey("dbo.Consultations", t => t.ConsultId, cascadeDelete: true)
                .ForeignKey("dbo.Custs", t => t.custId, cascadeDelete: true)
                .Index(t => t.ConsultId)
                .Index(t => t.custId);
            
            CreateTable(
                "dbo.ConsultDrugs",
                c => new
                    {
                        ConsultId = c.String(nullable: false, maxLength: 128),
                        DrugId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ConsultId, t.DrugId })
                .ForeignKey("dbo.Consultations", t => t.ConsultId, cascadeDelete: true)
                .ForeignKey("dbo.Drugs", t => t.DrugId, cascadeDelete: true)
                .Index(t => t.ConsultId)
                .Index(t => t.DrugId);
            
            CreateTable(
                "dbo.ConsultationIllness",
                c => new
                    {
                        ConsultId = c.String(nullable: false, maxLength: 128),
                        IllnessId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ConsultId, t.IllnessId })
                .ForeignKey("dbo.Consultations", t => t.ConsultId, cascadeDelete: true)
                .ForeignKey("dbo.Illnesses", t => t.IllnessId, cascadeDelete: true)
                .Index(t => t.ConsultId)
                .Index(t => t.IllnessId);
            
            CreateTable(
                "dbo.ProcedureConsultations",
                c => new
                    {
                        Procedure_procedureId = c.Int(nullable: false),
                        Consultation_ConsultId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Procedure_procedureId, t.Consultation_ConsultId })
                .ForeignKey("dbo.Procedures", t => t.Procedure_procedureId, cascadeDelete: true)
                .ForeignKey("dbo.Consultations", t => t.Consultation_ConsultId, cascadeDelete: true)
                .Index(t => t.Procedure_procedureId)
                .Index(t => t.Consultation_ConsultId);
            
            CreateTable(
                "dbo.ConsultationSymptoms",
                c => new
                    {
                        ConsultId = c.String(nullable: false, maxLength: 128),
                        Symptomsid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ConsultId, t.Symptomsid })
                .ForeignKey("dbo.Consultations", t => t.ConsultId, cascadeDelete: true)
                .ForeignKey("dbo.Symptoms", t => t.Symptomsid, cascadeDelete: true)
                .Index(t => t.ConsultId)
                .Index(t => t.Symptomsid);
            
            CreateTable(
                "dbo.ConsultTests",
                c => new
                    {
                        ConsultId = c.String(nullable: false, maxLength: 128),
                        TestTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ConsultId, t.TestTypeID })
                .ForeignKey("dbo.Consultations", t => t.ConsultId, cascadeDelete: true)
                .ForeignKey("dbo.TestTypes", t => t.TestTypeID, cascadeDelete: true)
                .Index(t => t.ConsultId)
                .Index(t => t.TestTypeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "IdentityUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "IdentityUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.IdentityUserClaims", "IdentityUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "IdentityRole_Id", "dbo.AspNetRoles");
            DropForeignKey("dbo.FileUploadDBModels", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Dependents", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Results", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.PatientFiles", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.PatientAddresses", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Consultations", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.ConsultTests", "TestTypeID", "dbo.TestTypes");
            DropForeignKey("dbo.ConsultTests", "ConsultId", "dbo.Consultations");
            DropForeignKey("dbo.ConsultationSymptoms", "Symptomsid", "dbo.Symptoms");
            DropForeignKey("dbo.ConsultationSymptoms", "ConsultId", "dbo.Consultations");
            DropForeignKey("dbo.ProcedureItems", "Procedures_procedureId", "dbo.Procedures");
            DropForeignKey("dbo.ProcedureConsultations", "Consultation_ConsultId", "dbo.Consultations");
            DropForeignKey("dbo.ProcedureConsultations", "Procedure_procedureId", "dbo.Procedures");
            DropForeignKey("dbo.ConsultationIllness", "IllnessId", "dbo.Illnesses");
            DropForeignKey("dbo.ConsultationIllness", "ConsultId", "dbo.Consultations");
            DropForeignKey("dbo.ConsultDrugs", "DrugId", "dbo.Drugs");
            DropForeignKey("dbo.ConsultDrugs", "ConsultId", "dbo.Consultations");
            DropForeignKey("dbo.ConsultationMedicine", "custId", "dbo.Custs");
            DropForeignKey("dbo.ConsultationMedicine", "ConsultId", "dbo.Consultations");
            DropForeignKey("dbo.Custs", "ConsultationDrugs_collectionID", "dbo.CollectionDrugs");
            DropForeignKey("dbo.Consultations", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Drugs", "CollectionDrugs_collectionID", "dbo.CollectionDrugs");
            DropIndex("dbo.ConsultTests", new[] { "TestTypeID" });
            DropIndex("dbo.ConsultTests", new[] { "ConsultId" });
            DropIndex("dbo.ConsultationSymptoms", new[] { "Symptomsid" });
            DropIndex("dbo.ConsultationSymptoms", new[] { "ConsultId" });
            DropIndex("dbo.ProcedureConsultations", new[] { "Consultation_ConsultId" });
            DropIndex("dbo.ProcedureConsultations", new[] { "Procedure_procedureId" });
            DropIndex("dbo.ConsultationIllness", new[] { "IllnessId" });
            DropIndex("dbo.ConsultationIllness", new[] { "ConsultId" });
            DropIndex("dbo.ConsultDrugs", new[] { "DrugId" });
            DropIndex("dbo.ConsultDrugs", new[] { "ConsultId" });
            DropIndex("dbo.ConsultationMedicine", new[] { "custId" });
            DropIndex("dbo.ConsultationMedicine", new[] { "ConsultId" });
            DropIndex("dbo.FileUploadDBModels", new[] { "PatientId" });
            DropIndex("dbo.Results", new[] { "PatientId" });
            DropIndex("dbo.PatientFiles", new[] { "PatientId" });
            DropIndex("dbo.PatientAddresses", new[] { "PatientId" });
            DropIndex("dbo.Dependents", new[] { "PatientId" });
            DropIndex("dbo.ProcedureItems", new[] { "Procedures_procedureId" });
            DropIndex("dbo.Custs", new[] { "ConsultationDrugs_collectionID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "IdentityUser_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "IdentityUser_Id" });
            DropIndex("dbo.IdentityUserClaims", new[] { "IdentityUser_Id" });
            DropIndex("dbo.Consultations", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Consultations", new[] { "PatientId" });
            DropIndex("dbo.Drugs", new[] { "CollectionDrugs_collectionID" });
            DropTable("dbo.ConsultTests");
            DropTable("dbo.ConsultationSymptoms");
            DropTable("dbo.ProcedureConsultations");
            DropTable("dbo.ConsultationIllness");
            DropTable("dbo.ConsultDrugs");
            DropTable("dbo.ConsultationMedicine");
            DropTable("dbo.WorkingTimes");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Referrals");
            DropTable("dbo.Prescriptions");
            DropTable("dbo.MedicalCertificates");
            DropTable("dbo.HIVTestResults");
            DropTable("dbo.HIVPatientFiles");
            DropTable("dbo.FileUploadDBModels");
            DropTable("dbo.FeedBacks");
            DropTable("dbo.Email_services");
            DropTable("dbo.DrugModels");
            DropTable("dbo.Results");
            DropTable("dbo.PatientFiles");
            DropTable("dbo.PatientAddresses");
            DropTable("dbo.Patients");
            DropTable("dbo.Dependents");
            DropTable("dbo.ConsultationPrices");
            DropTable("dbo.ConsultationDrugs");
            DropTable("dbo.TestTypes");
            DropTable("dbo.Symptoms");
            DropTable("dbo.ProcedureItems");
            DropTable("dbo.Procedures");
            DropTable("dbo.Illnesses");
            DropTable("dbo.Custs");
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
