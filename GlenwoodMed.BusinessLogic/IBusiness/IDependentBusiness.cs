using GlenwoodMed.Data.Tables;
using GlenwoodMed.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GlenwoodMed.BusinessLogic.IBusiness
{
    public interface IDependentBusiness
    {
        List<DependentModel> GetAllDependents(int Id);
        //List<DependentModel> GetAllStaffDependents(int Id);
        DependentModel GetDependentId(int? id);
        DependentModel DetailsMethod(int? id);
        void CreateMethod(DependentModel cv, int patientid, string Gender, string Role, string Title);
        IEnumerable<SelectListItem> DDPatient();
        void AdditionalCreateMethod(DependentModel cv, int patientid, string Gender, string Role, string Title);
        DependentModel GETeditMethod(int? id);
        DependentModel PostEditMethod(DependentModel dep);
        DependentModel GETdeleteMethod(int id);
        void PostDeleteMethod(int id);
        List<Dependent> GetDependents();
    }
}
