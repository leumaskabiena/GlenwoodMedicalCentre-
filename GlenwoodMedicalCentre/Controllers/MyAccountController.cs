using GlenwoodMed.BusinessLogic;
using GlenwoodMed.BusinessLogic.Business;
using GlenwoodMed.Data;
using GlenwoodMed.Data.Tables;
using GlenwoodMed.Model;
using GlenwoodMed.Model.ViewModels;
using GlenwoodMed.Service.RepositoryClass;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GlenwoodMedicalCentre.Controllers
{
    [RequireHttps]
    public class MyAccountController : Controller
    {
        RegisterBusiness rg = new RegisterBusiness();
        DataContext da = new DataContext();

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }


        DataContext dcon = new DataContext();

        Dependent d = new Dependent();
        // GET: MyAccount/Register
        //[Authorize]
        public ActionResult Register()
        {
            var model = new RegisterModel
            {
                DDLName = rg.DDRoles()
            };
            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        //[Authorize]
        public async Task<ActionResult> Register(RegisterModel objRegisterModel, string Gender, string Status, string Id, string Title)
        {
            var registerbusiness = new RegisterBusiness();
            var rol = new RolesBusiness();
            //string userName = objRegisterModel.Email.ToString();

            if (registerbusiness.FindUser(objRegisterModel.Email, AuthenticationManager))
            {
                ModelState.AddModelError("", "User already exists");
                return View(objRegisterModel);
            }

            var result = await registerbusiness.RegisterUser(objRegisterModel, AuthenticationManager, Gender, Status, Id, Title);

            if (result)
            {
                //string error = "";
                //rol.AddRoleToUser(Id, userName, error);
                //System.Web.HttpContext.Current.Session["PatientId"] = objRegisterModel.Email.ToString();
                //return RedirectToAction("Create", "StaffDependent");
                return RedirectToAction("Index", "Patient");
            }
            else
            {
                ModelState.AddModelError("", result.ToString());
            }

            return View(objRegisterModel);
        }


        // GET: MyAccount/Login
        [AllowAnonymous]
        public ActionResult Login()
        {
            var loginview = new LoginModel();
            return View(loginview);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var loginbusiness = new LoginBusiness();
                var result = await loginbusiness.LogUserIn(model, AuthenticationManager);
                
                if (result)
                {
                    return RedirectToLocal(returnUrl, model);
                }
                    
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> LayoutLogin(FormCollection form, string returnUrl)
        {
            //if (ModelState.IsValid)
            //{
                LoginModel model = new LoginModel();
                model.UserName = form["username"].ToString();
                model.Password = form["password"].ToString(); ;

                var loginbusiness = new LoginBusiness();
                var result = await loginbusiness.LogUserIn(model, AuthenticationManager);

                if (result)
                    return RedirectToLocal(returnUrl, model);
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            //}

            return View(model);
        }

        //
        // POST: /MyAccount/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Login", "MyAccount");
        }

        private ActionResult RedirectToLocal(string returnUrl, LoginModel model)
        {
            var context = new DataContext();

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            var user = userManager.FindByName(model.UserName);

            if (userManager.IsInRole(user.Id, "Receptionist"))
            {
                if (Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "BooKing");
                }

            }

            if (userManager.IsInRole(user.Id, "Doctor"))
            {
                if (Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Patient");
                }
            }

            if (userManager.IsInRole(user.Id, "Patient"))
            {
                if (Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "PatientView");
                }
            }

            if (userManager.IsInRole(user.Id, "Pharmacist"))
            {
                if (Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("ViewDrugsConsultation", "Consultations");
                }
            }

            else
            {
                if (Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("GeneralSearch", "Search");
                }
            }
        }
        
        [Authorize]
        // GET: MyAccount/Register
        public ActionResult EditProfile()
        { 
            var user = System.Web.HttpContext.Current.User.Identity.GetUserId();

            return View(rg.GETeditUserMethod(user.ToString()));
        }

        [HttpPost]
        [Authorize]
        public ActionResult EditProfile(EditProfileModel objRegisterModel)
        {
            try
            {
                // TODO: Add update logic here

                var user = System.Web.HttpContext.Current.User.Identity.GetUserId();

                rg.PostEditUserMethod(objRegisterModel, user);
                return RedirectToAction("Index", "Patient");
            }
            catch
            {
                return View();
            }
        }
    }
}