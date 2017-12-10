namespace GlenwoodMed.Data.Migrations
{
    using GlenwoodMed.Data.Tables;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GlenwoodMed.Data.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        //protected override void Seed(GlenwoodMed.Data.DataContext context)
        //{
        //    //  This method will be called after migrating to the latest version.

        //    //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
        //    //  to avoid creating duplicate seed data. E.g.
        //    //
        //    //    context.People.AddOrUpdate(
        //    //      p => p.FullName,
        //    //      new Person { FullName = "Andrew Peters" },
        //    //      new Person { FullName = "Brice Lambson" },
        //    //      new Person { FullName = "Rowan Miller" }
        //    //    );
        //    //
        //}

        protected override void Seed(GlenwoodMed.Data.DataContext context)
        {
            //this.Hours();

            var userManager = new UserManager<ApplicationUser>(new
                                            UserStore<ApplicationUser>(context));

            var roleManager = new RoleManager<ApplicationRole>(new
                                      RoleStore<ApplicationRole>(context));

            string[] name = { "Doctor", "Receptionist", "Pharmacist" };
            string password = "password";

            foreach (var i in name)
            {
                if (!roleManager.RoleExists(i))
                {
                    var roleresult = roleManager.Create(new ApplicationRole(i));
                }
            }


            foreach (var i in name)
            {
                var user = new ApplicationUser();
                user.UserName = i;
                user.DOB = "06/06/1990";
                user.Email = "ologbesei@gmail.com";
                user.EmployerTelephone = "0730864922";
                user.FullName = "Ayomide";
                user.Surname = "Fajobi";
                user.NationalId = "A01850833";
                user.PhoneNumber = "0730864922";
                user.PostalCode = 4001;
                user.Sex = "Male";
                user.Telephone = "0730864922";
                user.Title = "Mr";
                user.Password = "password";

                var adminresult = userManager.Create(user, password);

                if (adminresult.Succeeded)
                {
                    var result = userManager.AddToRole(user.Id, i);
                }
            }

            //const string name = "Doctor";
            //const string password = "password";

            //if (!roleManager.RoleExists(name))
            //{
            //    var roleresult = roleManager.Create(new ApplicationRole(name));
            //}

            //var user = new ApplicationUser();
            //user.UserName = name;
            //user.DOB = "06/06/1990";
            //user.Email = "ologbesei@gmail.com";
            //user.EmployerTelephone = "0730864922";
            //user.FullName = "Ayomide";
            //user.Surname = "Fajobi";
            //user.NationalId = "A01850833";
            //user.PhoneNumber = "0730864922";
            //user.PostalCode = 4001;
            //user.Sex = "Male";
            //user.Telephone = "0730864922";
            //user.Title = "Mr";
            //user.Password = "password";

            //var adminresult = userManager.Create(user, password);

            //if (adminresult.Succeeded)
            //{
            //    var result = userManager.AddToRole(user.Id, name);
            //}
            base.Seed(context);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }

        void Hours()
        {
            DataContext db = new DataContext();
            var hr1 = new WorkingTime()
            {
                Id = 1,
                hour_start = " 8,00,00",
                hour_end = " 8,20,00",
                text = "8:00 Am"
            };
            db.WorkingTimes.Add(hr1);
            db.SaveChanges();
            var hr2 = new WorkingTime()
            {
                Id = 2,
                hour_start = " 8,20,00",
                hour_end = " 8,40,00",
                text = "8:20 Am"
            };
            db.WorkingTimes.Add(hr2);
            db.SaveChanges();
            var hr3 = new WorkingTime()
            {
                Id = 3,
                hour_start = " 8,40,00",
                hour_end = " 9,00,00",
                text = "8:40 Am"
            };

            db.WorkingTimes.Add(hr3);
            db.SaveChanges();
            var hr4 = new WorkingTime()
            {
                Id = 4,
                hour_start = " 9,00,00",
                hour_end = " 9,20,00",
                text = "9:00 Am"
            };
            db.WorkingTimes.Add(hr4);
            db.SaveChanges();
            var hr5 = new WorkingTime()
            {
                Id = 5,
                hour_start = " 9,20,00",
                hour_end = " 9,40,00",
                text = "9:20 Am"
            };
            db.WorkingTimes.Add(hr5);
            db.SaveChanges();

            var hr6 = new WorkingTime()
            {
                Id = 6,
                hour_start = " 9,40,00",
                hour_end = " 10,00,00",
                text = "9:40 Am"
            };
            db.WorkingTimes.Add(hr6);
            db.SaveChanges();
            var hr7 = new WorkingTime()
            {
                Id = 7,
                hour_start = " 10,00,00",
                hour_end = " 10,20,00",
                text = "10:00 Am"
            };
            db.WorkingTimes.Add(hr7);
            db.SaveChanges();

            var hr8 = new WorkingTime()
            {
                Id = 8,
                hour_start = " 10,20,00",
                hour_end = " 10,40,00",
                text = "10:20 Am"
            };
            db.WorkingTimes.Add(hr8);
            db.SaveChanges();

            var hr9 = new WorkingTime()
            {
                Id = 9,
                hour_start = " 10,40,00",
                hour_end = " 11,00,00",
                text = "10:40 Am"
            };
            db.WorkingTimes.Add(hr9);
            db.SaveChanges();
            var hr10 = new WorkingTime()
            {
                Id = 10,
                hour_start = "11,00,00",
                hour_end = "11,20,00",
                text = "11:00 Am"
            };
            db.WorkingTimes.Add(hr10);
            db.SaveChanges();

            var hr11 = new WorkingTime()
            {
                Id = 11,
                hour_start = " 11,20,00",
                hour_end = " 11,40,00",
                text = "11:20 Am"
            };
            db.WorkingTimes.Add(hr11);
            db.SaveChanges();

            var hr12 = new WorkingTime()
            {
                Id = 12,
                hour_start = " 11,40,00",
                hour_end = " 12,00,00",
                text = "11:40 Am"
            };
            db.WorkingTimes.Add(hr12);
            db.SaveChanges();

            var hr13 = new WorkingTime()
            {
                Id = 13,
                hour_start = " 13,00,00",
                hour_end = " 13,20,00",
                text = "1:00 Pm"
            };
            db.WorkingTimes.Add(hr13);
            db.SaveChanges();

            var hr14 = new WorkingTime()
            {
                Id = 14,
                hour_start = " 13,20,00",
                hour_end = " 13,40,00",
                text = "1:20 Pm"
            };
            db.WorkingTimes.Add(hr14);
            db.SaveChanges();

            var hr15 = new WorkingTime()
            {
                Id = 15,
                hour_start = " 13,40,00",
                hour_end = " 14,00,00",
                text = "1:40 Pm"
            };
            db.WorkingTimes.Add(hr15);
            db.SaveChanges();

            var hr16 = new WorkingTime()
            {
                Id = 16,
                hour_start = " 14,00,00",
                hour_end = " 14,20,00",
                text = "2:00Pm"
            };
            db.WorkingTimes.Add(hr16);
            db.SaveChanges();

            var hr17 = new WorkingTime()
            {
                Id = 17,
                hour_start = " 14,20,00",
                hour_end = " 14,40,00",
                text = "2:20 Pm"
            };
            db.WorkingTimes.Add(hr17);
            db.SaveChanges();

            var hr18 = new WorkingTime()
            {
                Id = 18,
                hour_start = " 14,40,00",
                hour_end = " 15,00,00",
                text = "2:40 Pm"
            };
            db.WorkingTimes.Add(hr18);
            db.SaveChanges();

            var hr19 = new WorkingTime()
            {
                Id = 19,
                hour_start = " 15,00,00",
                hour_end = " 15,20,00",
                text = "3:00 Pm"
            };
            db.WorkingTimes.Add(hr19);
            db.SaveChanges();

            var hr20 = new WorkingTime()
            {
                Id = 20,
                hour_start = " 15,20,00",
                hour_end = " 15,40,00",
                text = "3:20 Pm"
            };
            db.WorkingTimes.Add(hr20);
            db.SaveChanges();

            var hr21 = new WorkingTime()
            {
                Id = 21,
                hour_start = " 15,40,00",
                hour_end = " 16,00,00",
                text = "3:40 Pm"
            };
            db.WorkingTimes.Add(hr21);
            db.SaveChanges();

            var hr22 = new WorkingTime()
            {
                Id = 22,
                hour_start = " 16,00,00",
                hour_end = " 16,20,00",
                text = "4:00 Pm"
            };
            db.WorkingTimes.Add(hr22);
            db.SaveChanges();

            var hr23 = new WorkingTime()
            {
                Id = 23,
                hour_start = " 16,20,00",
                hour_end = " 16,40,00",
                text = "4:20 Pm"
            };
            db.WorkingTimes.Add(hr23);
            db.SaveChanges();

            var hr24 = new WorkingTime()
            {
                Id = 24,
                hour_start = " 16,40,00",
                hour_end = " 17,00,00",
                text = "4:40 Pm"
            };
            db.WorkingTimes.Add(hr24);
            db.SaveChanges();

            var hr25 = new WorkingTime()
            {
                Id = 25,
                hour_start = " 17,00,00",
                hour_end = " 17,20,00",
                text = "5:00 Pm"
            };
            db.WorkingTimes.Add(hr25);
            db.SaveChanges();

            var hr26 = new WorkingTime()
            {
                Id = 26,
                hour_start = " 17,20,00",
                hour_end = " 17,40,00",
                text = "5:20 Pm"
            };
            db.WorkingTimes.Add(hr26);
            db.SaveChanges();

            var hr27 = new WorkingTime()
            {
                Id = 27,
                hour_start = " 17,40,00",
                hour_end = " 18,00,00",
                text = "5:40 Pm"
            };
            db.WorkingTimes.Add(hr27);
            db.SaveChanges();
        }
    }
}
