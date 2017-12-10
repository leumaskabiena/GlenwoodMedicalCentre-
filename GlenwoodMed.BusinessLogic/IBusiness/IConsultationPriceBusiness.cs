using System.Collections.Generic;
using GlenwoodMed.Model.ViewModels;

namespace GlenwoodMed.BusinessLogic.IBusiness
{
    public interface IConsultationPriceBusiness
    {
        List<ConsultationPriceView> GetAllPrice();
        ConsultationPriceView GETeditMethod(int? id);
        ConsultationPriceView DetailsMethod(int? id);
        ConsultationPriceView PostEditMethod(ConsultationPriceView cv);
        void CreateMethod(ConsultationPriceView cv);
        decimal Price();
    }
}
