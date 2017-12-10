using GlenwoodMed.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

using System.Threading.Tasks;

namespace GlenwoodMed.BusinessLogic
{
    public class RolesBusiness : IRolesBusiness
    {
        public void RoleCreate(string roleName)
        {
            using (var context = new DataContext())
            {
                var roleStore = new RoleStore<ApplicationRole>(context);
                var roleManager = new RoleManager<ApplicationRole>(roleStore);

                roleManager.Create(new ApplicationRole(roleName));
                //roleManager.Create(new ApplicationRole(roleName));
                context.SaveChanges();
            }
        }
        public List<string> RoleIndex()
        {
            List<string> roles;
            using (var context = new DataContext())
            {
                var roleStore = new RoleStore<ApplicationRole>(context);
                var roleManager = new RoleManager<ApplicationRole>(roleStore);

                roles = (from r in roleManager.Roles select r.Name).ToList();

            }

            return (roles.ToList());
        }

        public void RoleDelete(string roleName)
        {
            using (var context = new DataContext())
            {
                var roleStore = new RoleStore<ApplicationRole>(context);
                var roleManager = new RoleManager<ApplicationRole>(roleStore);
                var role = roleManager.FindByName(roleName);

                roleManager.Delete(role);
                // context.SaveChanges();

            }
        }
        #region

        //public void RoleAddToUser()
        //{
        //    List<string> roles;
        //    List<string> users;
        //    using (var context = new IdentityDataContext())
        //    {
        //        var roleStore = new RoleStore<IdentityRole>(context);
        //        var roleManager = new RoleManager<IdentityRole>(roleStore);

        //        var userStore = new UserStore<ApplicationUser>(context);
        //        var userManager = new UserManager<ApplicationUser>(userStore);

        //        users = (from u in userManager.Users select u.UserName).ToList();
        //        roles = (from r in roleManager.Roles select r.Name).ToList();
        //    }
        //}
        #endregion

        public void AddRoleToUser(string Id, string userName, string error)
        {
            using (var context = new DataContext())
            {
                var roleStore = new RoleStore<ApplicationRole>(context);
                var roleManager = new RoleManager<ApplicationRole>(roleStore);

                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                var role = roleManager.FindById(Id);
                if (role == null)
                    throw new Exception("Role not found!");

                if (userManager.IsInRole(userName, role.Name))
                {
                    error = "This user already has the role specified !";
                }
                else
                {
                    userManager.AddToRole(userName, role.Name);
                    context.SaveChanges();

                    error = "Username added to the role succesfully !";
                }
            }
        }

        public void RoleAddToUser(string roleName, string userName, string error)
        {
            List<string> roles;
            List<string> users;
            using (var context = new DataContext())
            {
                var roleStore = new RoleStore<ApplicationRole>(context);
                var roleManager = new RoleManager<ApplicationRole>(roleStore);

                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                users = (from u in userManager.Users select u.UserName).ToList();
                var user = userManager.FindByName(userName);
                if (user == null)
                    throw new Exception("User not found!");

                var role = roleManager.FindByName(roleName);
                if (role == null)
                    throw new Exception("Role not found!");

                if (userManager.IsInRole(user.Id, role.Name))
                {

                    error = "This user already has the role specified !";
                }
                else
                {
                    userManager.AddToRole(user.Id, role.Name);
                    context.SaveChanges();

                    error = "Username added to the role succesfully !";
                }


            }
        }

        public void AddPatientToRole(string roleName, string userName, string error)
        {
            using (var context = new DataContext())
            {
                var roleStore = new RoleStore<ApplicationRole>(context);
                var roleManager = new RoleManager<ApplicationRole>(roleStore);

                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                var role = roleManager.FindByName(roleName);
                if (role == null)
                    throw new Exception("Role not found!");

                if (userManager.IsInRole(userName, role.Name))
                {
                    error = "This user already has the role specified !";
                }
                else
                {
                    userManager.AddToRole(userName, role.Name);
                    context.SaveChanges();

                    error = "Username added to the role succesfully !";
                }
            }
        }

        public List<string> GetgRoles(string userName)
        {
            List<string> userRole = GetUserRoles(userName);
            List<string> userRoles = null;
            if (!string.IsNullOrWhiteSpace(userName))
            {
                List<string> roles;
                List<string> users;
                var context = new DataContext();

                var roleStore = new RoleStore<ApplicationRole>(context);
                var roleManager = new RoleManager<ApplicationRole>(roleStore);

                roles = (from r in roleManager.Roles select r.Name).ToList();

                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                users = (from u in userManager.Users select u.UserName).ToList();

                var user = userManager.FindByName(userName);
                if (user == null)
                    throw new Exception("User not found!");

                var userRoleIds = (from r in user.Roles select r.RoleId);
                userRoles = (from id in userRoleIds
                             let r = roleManager.FindById(id)
                             select r.Name).ToList();
            }
            return userRoles.ToList();
        }

        public List<IdentityRole> identityRole()
        {
            var context = new DataContext();

            return context.Roles.ToList();
        }

        public List<IdentityUserRole> GetRoles(string userName)
        {
            var context = new DataContext();

            context.Roles.ToList();


            //List<IdentityUserRole> userRoles;
            List<string> roles;
            List<string> users;

            var roleStore = new RoleStore<ApplicationRole>(context);
            var roleManager = new RoleManager<ApplicationRole>(roleStore);

            roles = (from r in roleManager.Roles select r.Name).ToList();

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            users = (from u in userManager.Users select u.UserName).ToList();

            var user = userManager.FindByName(userName);


            if (user == null)
                throw new Exception("User not found!");

            //var userRoleIds = (from r in user.Roles select r.RoleId);
            //userRoles = (from id in userRoleIds
            //             let r = roleManager.FindById(id)
            //             select r.Name).ToList();
            var userrole = user.Roles.ToList();

            return userrole.ToList();
            //return userRoles.ToList();
        }

        public List<string> GetallUsers(List<string> users)
        {
            DataContext con = new DataContext();
            var app = new RegisterBusiness();

            var user = app.GetUsers().Where(x => x.Role != "Patient").Select(x => x.UserName).ToList();
            //var use = (from u in con.Users.Where(x => x.r select u.UserName).ToList();

            users = user;

            return users;

        }
        public List<string> GetallRoles(List<string> roles)
        {
            DataContext con = new DataContext();
            var role = (from u in con.Roles select u.Name).ToList();

            roles = role;

            return role;

        }

        public List<IdentityRole> GetMyRoles()
        {
            var context = new DataContext();

            return context.Roles.ToList();
        }
        public List<string> GetUserRoles(string username)
        {
            List<string> userRoles = new List<string>();
            DataContext con = new DataContext();
            var userStore = new UserStore<ApplicationUser>(con);
            var userManager = new UserManager<ApplicationUser>(userStore);

            var roleStore = new RoleStore<ApplicationRole>(con);
            var roleManager = new RoleManager<ApplicationRole>(roleStore);


            var user = userManager.FindByName(username);
            var userRoleIds = (from r in user.Roles select r.RoleId);
            userRoles = (from id in userRoleIds
                         let r = roleManager.FindById(id)
                         select r.Name).ToList();

            return userRoles;
        }
        public void DeleteRoleForUser(string userName, string roleName)
        {
            List<string> userRoles;
            List<string> roles;
            List<string> users;
            using (var context = new DataContext())
            {
                var roleStore = new RoleStore<ApplicationRole>(context);
                var roleManager = new RoleManager<ApplicationRole>(roleStore);

                roles = (from r in roleManager.Roles select r.Name).ToList();

                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                users = (from u in userManager.Users select u.UserName).ToList();

                var user = userManager.FindByName(userName);
                if (user == null)
                    throw new Exception("User not found!");

                if (userManager.IsInRole(user.Id, roleName))
                {
                    userManager.RemoveFromRole(user.Id, roleName);
                    // context.SaveChanges();

                    string error = "Role removed from this user successfully !";
                }
                else
                {
                    string error = "This user doesn't belong to selected role.";
                }

                var userRoleIds = (from r in user.Roles select r.RoleId);
                userRoles = (from id in userRoleIds
                             let r = roleManager.FindById(id)
                             select r.Name).ToList();
            }
        }
    }
}


