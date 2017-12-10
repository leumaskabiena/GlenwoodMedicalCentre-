//using GlenwoodMed.Data.Tables;
//using Microsoft.AspNet.Identity.EntityFramework;
//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace GlenwoodMed.Data
//{
//    public class IdentityDataContext : IdentityDbContext<ApplicationUser>
//    {
//        public IdentityDataContext()
//            : base("Conn")
//        {
//        }

//        //public DbSet<Dependent> Dependents { get; set; }
//        //public DbSet<GlenwoodMed.Data.ApplicationUser> ApplicationUsers { get; set; }
//        // public System.Data.Entity.DbSet<GlenwoodMed.Data.ApplicationUser> ApplicationUsers { get; set; }

//        protected override void OnModelCreating(DbModelBuilder modelBuilder)
//        {
//            base.OnModelCreating(modelBuilder);

//            // Change the name of the table to be Users instead of AspNetUsers
//            modelBuilder.Entity<IdentityUser>()
//                .ToTable("Users");
//            modelBuilder.Entity<ApplicationUser>()
//                .ToTable("Users");
//        }

//        public System.Data.Entity.DbSet<GlenwoodMed.Model.RegisterModel> RegisterModels { get; set; }
//    }
//}
