using GlenwoodMed.Data.Tables;
using GlenwoodMed.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GlenwoodMed.BusinessLogic.IBusiness
{
    public interface IEmail_serviceBusiness
    {
        List<Email_serviceViewModel>GetallEmail();
        void createemail(Email_serviceViewModel emails);//, HttpPostedFileBase fileUploader);
        void deletemail(Email_services emails);
       // void updateemails(Email_services emails);
        Email_serviceViewModel GETdeleteMethod(int id);
        Email_serviceViewModel EmailDetails(int? id);
        //void PostDeleteMethod(int id);
        // Email_serviceViewModel GETeditemail(int? id);
        // Email_serviceViewModel PostEditemail(Email_services em);
    }
}
 