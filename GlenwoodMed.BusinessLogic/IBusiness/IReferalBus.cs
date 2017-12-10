using GlenwoodMed.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.BusinessLogic.IBusiness
{
    public interface IReferalBus
    {
        List<ReferralModel> GetAll();
        ReferralModel GetTestById(int? id);
        //void DeleteMethod(int id);
        void CreateMethod(ReferralModel model);
    }
}
