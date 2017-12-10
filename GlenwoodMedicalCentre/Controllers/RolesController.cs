using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GlenwoodMed.Data;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using GlenwoodMed.BusinessLogic;

namespace GlenwoodMedicalCentre.Controllers
{
    [RequireHttps]
    public class RolesController : Controller
    {
       // public IdentityDbContext db = new IdentityDbContext();

        //
        // GET: /Roles/
       // string rolename = "";
        public ActionResult RoleCreate()
        {
            return View();
        }
        //public ActionResult RoleCreate1()
        //{
        //    return View();
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RoleCreate(string roleName)
        {
            var rol = new RolesBusiness();
            //using (var context = new IdentityDataContext())
            //{
            //    var roleStore = new RoleStore<IdentityRole>(context);
            //    var roleManager = new RoleManager<IdentityRole>(roleStore);

            //    roleManager.Create(new IdentityRole(roleName));
            //    context.SaveChanges();
            //}

            rol.RoleCreate(roleName);
            ViewBag.ResultMessage = "Role created successfully !";
            return RedirectToAction("RoleAddToUser", "Roles");
            //return RedirectToAction("RoleIndex", "Roles");
        }


        public ActionResult RoleIndex()
        {

            var rol = new RolesBusiness();
           // List<string> roles;
            //using (var context = new IdentityDataContext())
            //{
            //    var roleStore = new RoleStore<IdentityRole>(context);
            //    var roleManager = new RoleManager<IdentityRole>(roleStore);

            //    roles = (from r in roleManager.Roles select r.Name).ToList();
            //}

           List<string> role= rol.RoleIndex();
            return View(role.ToList());
        }


        public ActionResult RoleDelete(string roleName)
        {
            var rol = new RolesBusiness();
            //using (var context = new IdentityDataContext())
            //{
            //    var roleStore = new RoleStore<IdentityRole>(context);
            //    var roleManager = new RoleManager<IdentityRole>(roleStore);
            //    var role = roleManager.FindByName(roleName);

            //    roleManager.Delete(role);
            //    context.SaveChanges();

            //}

            rol.RoleDelete(roleName);
           
            ViewBag.ResultMessage = "Role deleted succesfully !";
            return RedirectToAction("RoleIndex", "Roles");
        }


        public ActionResult RoleAddToUser()
        {
            
            var rol = new RolesBusiness();
            List<string> roles=new List<string>();
            List<string> users=new List<string>();
          List<string> user= rol.GetallUsers( users);
          List<string> role = rol.GetallRoles(roles);
          #region

          //using (var context = new IdentityDataContext())
            //{
            //    var roleStore = new RoleStore<IdentityRole>(context);
            //    var roleManager = new RoleManager<IdentityRole>(roleStore);

            //    var userStore = new UserStore<ApplicationUser>(context);
            //    var userManager = new UserManager<ApplicationUser>(userStore);

            //    users = (from u in userManager.Users select u.UserName).ToList();
            //    roles = (from r in roleManager.Roles select r.Name).ToList();
          //}
          #endregion
          ViewBag.Roles = new SelectList(role);
            ViewBag.Users = new SelectList(user);
            return View("RoleAddToUser");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RoleAddToUser(string RoleName, string UserName)
        {
      
            var rol = new RolesBusiness();
            List<string> roles = new List<string>();
            List<string> users = new List<string>();
            List<string> user = rol.GetallUsers(users);
            List<string> role = rol.GetallRoles(roles);
            #region
            //List<string> roles;
            //List<string> users;
            //using (var context = new IdentityDataContext())
            //{
            //    var roleStore = new RoleStore<IdentityRole>(context);
            //    var roleManager = new RoleManager<IdentityRole>(roleStore);

            //    var userStore = new UserStore<ApplicationUser>(context);
            //    var userManager = new UserManager<ApplicationUser>(userStore);

            //    users = (from u in userManager.Users select u.UserName).ToList();
            //    var user = userManager.FindByName(userName);
            //    if (user == null)
            //        throw new Exception("User not found!");

            //    var role = roleManager.FindByName(roleName);
            //    if (role == null)
            //        throw new Exception("Role not found!");

            //    if (userManager.IsInRole(user.Id, role.Name))
            //    {
            //        ViewBag.ResultMessage = "This user already has the role specified !";
            //    }
            //    else
            //    {
            //        userManager.AddToRole(user.Id, role.Name);
            //        context.SaveChanges();

            //        ViewBag.ResultMessage = "Username added to the role succesfully !";
            //    }
            
            //    roles = (from r in roleManager.Roles select r.Name).ToList();
            //}
            #endregion
            ViewBag.Roles = new SelectList(role);
            ViewBag.Users = new SelectList(user);
            string error="";
            rol.RoleAddToUser(RoleName, UserName,error);
            ViewBag.Error = error;
            return View("RoleAddToUser");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetRoles(string UserName)
        {
            var rol = new RolesBusiness();
            List<string> roles = new List<string>();
            List<string> users = new List<string>();
            List<string> user = rol.GetallUsers(users);
            List<string> role = rol.GetallRoles(roles);
            #region
            //List<string> userRole = rol.GetUserRoles(UserName);
            //if (!string.IsNullOrWhiteSpace(userName))
            //{
            //    List<string> userRoles;
            //    List<string> roles;
            //    List<string> users;
            //    using (var context = new IdentityDataContext())
            //    {
            //        var roleStore = new RoleStore<IdentityRole>(context);
            //        var roleManager = new RoleManager<IdentityRole>(roleStore);

            //        roles = (from r in roleManager.Roles select r.Name).ToList();

            //        var userStore = new UserStore<ApplicationUser>(context);
            //        var userManager = new UserManager<ApplicationUser>(userStore);

            //        users = (from u in userManager.Users select u.UserName).ToList();

            //        var user = userManager.FindByName(userName);
            //        if (user == null)
            //            throw new Exception("User not found!");

            //        var userRoleIds = (from r in user.Roles select r.RoleId);
            //        userRoles = (from id in userRoleIds
            //                     let r = roleManager.FindById(id)
            //                     select r.Name).ToList();
            //    }

            //    ViewBag.Roles = new SelectList(roles);
            //    ViewBag.Users = new SelectList(users);
            //    ViewBag.RolesForThisUser = userRoles;
            //}
            #endregion
            ViewBag.Roles = new SelectList(role);
             ViewBag.Users = new SelectList(user);
             var userroles = rol.GetRoles(UserName);
             ViewBag.RolesForThisUser = new SelectList(userroles.ToList());
             //ViewBag.RolesForThisUser = new SelectList(rol.GetgRoles(UserName).ToList());
             ViewBag.Rol = rol.identityRole();
            return View("RoleAddToUser");
        }

        [HttpPost]

        [ValidateAntiForgeryToken]
        public ActionResult DeleteRoleForUser(string UserName, string RoleName)
        {
            var rol = new RolesBusiness();
            List<string> roles = new List<string>();
            List<string> users = new List<string>();
            List<string> user = rol.GetallUsers(users);
            List<string> role = rol.GetallRoles(roles);
            List<string> userRole=rol.GetUserRoles(UserName);
            //List<string> userRoles;
            //List<string> roles;
            //List<string> users;
            //using (var context = new IdentityDataContext())
            //{
            //    var roleStore = new RoleStore<IdentityRole>(context);
            //    var roleManager = new RoleManager<IdentityRole>(roleStore);

            //    roles = (from r in roleManager.Roles select r.Name).ToList();

            //    var userStore = new UserStore<ApplicationUser>(context);
            //    var userManager = new UserManager<ApplicationUser>(userStore);

            //    users = (from u in userManager.Users select u.UserName).ToList();

            //    var user = userManager.FindByName(userName);
            //    if (user == null)
            //        throw new Exception("User not found!");

            //    if (userManager.IsInRole(user.Id, roleName))
            //    {
            //        userManager.RemoveFromRole(user.Id, roleName);
            //        context.SaveChanges();

            //        ViewBag.ResultMessage = "Role removed from this user successfully !";
            //    }
            //    else
            //    {
            //        ViewBag.ResultMessage = "This user doesn't belong to selected role.";
            //    }

            //    var userRoleIds = (from r in user.Roles select r.RoleId);
            //    userRoles = (from id in userRoleIds
            //                 let r = roleManager.FindById(id)
            //                 select r.Name).ToList();
            //}

            ViewBag.RolesForThisUser = userRole;
            ViewBag.Roles = new SelectList(role);
            ViewBag.Users = new SelectList(user);
            rol.DeleteRoleForUser(UserName, RoleName);
            return View("RoleAddToUser");
        }

	}
}