using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using GlenwoodMed.Data;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GlenwoodMedicalCentre
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Search", action = "GeneralSearch", id = UrlParameter.Optional }
            );
            //if(System.Web.HttpContext.Current.Request.IsAuthenticated)
            //{
            //    var context = new DataContext();

            //    var userStore = new UserStore<ApplicationUser>(context);
            //    var userManager = new UserManager<ApplicationUser>(userStore);

            //    var user = System.Web.HttpContext.Current.User.Identity.GetUserId();

            //    if (user != null)
            //    {
            //        var userm = userManager.FindById(user);

            //        if (userManager.IsInRole(userm.Id, "Receptionist"))
            //        {
            //            routes.MapRoute(
            //            name: "Default",
            //            url: "{controller}/{action}/{id}",
            //            defaults: new { controller = "Index", action = "BooKing", id = UrlParameter.Optional }
            //        );
            //        }

            //        else if (userManager.IsInRole(userm.Id, "Doctor"))
            //        {
            //            routes.MapRoute(
            //            name: "Default",
            //            url: "{controller}/{action}/{id}",
            //            defaults: new { controller = "Index", action = "Patient", id = UrlParameter.Optional }
            //        );
            //        }

            //        else if (userManager.IsInRole(userm.Id, "Pharmacist"))
            //        {
            //            routes.MapRoute(
            //            name: "Default",
            //            url: "{controller}/{action}/{id}",
            //            defaults: new { controller = "ViewDrugsConsultation", action = "Consultations", id = UrlParameter.Optional }
            //        );
            //        }
            //    }
            //}

            //else
            //{
            //    routes.MapRoute(
            //        name: "Default",
            //        url: "{controller}/{action}/{id}",
            //        defaults: new { controller = "Search", action = "GeneralSearch", id = UrlParameter.Optional }
            //    );
            //}
            
        }
    }
}
