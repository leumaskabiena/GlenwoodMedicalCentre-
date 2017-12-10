using GlenwoodMed.Data;
using GlenwoodMed.Model;
using GlenwoodMed.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.BusinessLogic.IBusiness
{
    public interface IRegisterBusiness
    {
        List<RegisterModel> GetAllPatients();
        EditProfileModel GETeditUserMethod(string id);
        EditProfileModel PostEditUserMethod(EditProfileModel _registerModel, string id);
        EditProfileModel GETAlleditUserMethod(string id);
        List<ApplicationUser> GetUsers();
    }
}
