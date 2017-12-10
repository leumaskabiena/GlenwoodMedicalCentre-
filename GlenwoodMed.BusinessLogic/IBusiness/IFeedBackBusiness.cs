using GlenwoodMed.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.BusinessLogic.IBusiness
{
   public interface IFeedBackBusiness
    {
       List<FeedBackViewModel> GetAll();
       FeedBackViewModel GetById(int? id);
       void CreateMethod(FeedBackViewModel model, string feedback);
       FeedBackViewModel DetailsMethod(int? id);
       FeedBackViewModel GetDeleteMethod(int id);
       void PostDeleteMethod(int id);
        
    }
}
