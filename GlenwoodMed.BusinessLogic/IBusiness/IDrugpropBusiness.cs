using GlenwoodMed.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.BusinessLogic.IBusiness
{
    public interface IDrugpropBusiness
    {
        List<Drug_PropertiesModel> GetAllDrugprop();
        Drug_PropertiesModel GetDrugpropId(string id);
        Drug_PropertiesModel DetailsMethod(string id);
        void CreateMethod(Drug_PropertiesModel dp);
        Drug_PropertiesModel GETeditMethod(string id);
        Drug_PropertiesModel PostEditMethod(Drug_PropertiesModel dp);
        Drug_PropertiesModel GETdeleteMethod(string id);
        void PostDeleteMethod(string id);
    }
}
