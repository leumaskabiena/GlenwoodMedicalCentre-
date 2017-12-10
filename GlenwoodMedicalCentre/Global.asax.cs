using GlenwoodMed.BusinessLogic.Business;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using GlenwoodMed.Data.Tables;

//using TwitterBootstrapMVC;

namespace GlenwoodMedicalCentre
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
           // ModelBinders.Binders.Add(typeof (Consultation), new DebugModelBinder());
            //Bootstrap.Configure();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            InitializeBusiness.Initilize();
            var send = new NotificationBusiness();
            var sendSMS = new SMSBusiness();
            send.sendNotification();
            sendSMS.sendSMS();
            //throw new Exception(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString);
        }

        protected void Session_End(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Session_End");

            FormsAuthentication.SignOut();
        }
    }
}
