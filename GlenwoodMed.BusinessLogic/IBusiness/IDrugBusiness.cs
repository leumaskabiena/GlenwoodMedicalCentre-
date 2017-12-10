using System.Collections.Generic;
using GlenwoodMed.Model;
using GlenwoodMed.Model.ViewModels;

namespace GlenwoodMed.BusinessLogic.IBusiness
{
   public interface IDrugBusiness
   {
        List<DrugModel> GetAll();
        DrugModel GetDrugId(int? id);
        DrugModel DetailsMethod(int? id);
        void CreateMethod(DrugModel model, string DrugType);
        DrugModel GetReviewMethod(int? id);
        DrugModel PostReviewMethod(DrugModel model);
        DrugModel GetDeleteMethod(int id);
        void PostDeleteMethod(int id);
    }
}
