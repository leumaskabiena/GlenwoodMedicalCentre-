using GlenwoodMed.Data.Tables;
using GlenwoodMed.Model;
using GlenwoodMed.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GlenwoodMed.BusinessLogic.IBusiness
{
    public interface IPatientBusiness
    {
        List<PatientModel> GetAllPatients();
        PatientModel GetPatientId(int? id);
        PatientModel DetailsMethod(int? id);
        void CreateMethod(PatientModel rm, string Gender, string Status, string Title, string Patient_No);
        IEnumerable<SelectListItem> PatientDDL();
        PatientModel GETeditMethod(int? id);
        PatientModel PostEditMethod(PatientModel dep);
        PatientModel GETdeleteMethod(int id);
        void PostDeleteMethod(int id);
        int CountMethod();
        List<Patient> GetPatients();
    }
}
