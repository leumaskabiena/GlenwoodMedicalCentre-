using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.Data
{
    public class DbInitialize<T> : DropCreateDatabaseIfModelChanges<IdentityDbContext>
    {
        protected override void Seed(IdentityDbContext context)
        {
            var userManager = new UserManager<ApplicationUser>(new
                                            UserStore<ApplicationUser>(context));

            var roleManager = new RoleManager<ApplicationRole>(new
                                      RoleStore<ApplicationRole>(context));

            string[] name = { "Doctor", "Receptionist", "Pharmacist" };
            string password = "password";

            foreach( var i in name)
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

            //const string name1 = "Doctor";
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
        }
    }
}
