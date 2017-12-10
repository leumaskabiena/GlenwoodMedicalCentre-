using GlenwoodMed.Model.ViewModels;
using GlenwoodMed.Service;
using GlenwoodMed.Service.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlenwoodMed.BusinessLogic.IBusiness;
using GlenwoodMed.Data;
using GlenwoodMed.Data.Tables;
using GlenwoodMed.Service.RepositoryClass;

namespace GlenwoodMed.BusinessLogic.Business
{
    public class ConsultationPriceBusiness : IConsultationPriceBusiness
    {
        DataContext dc=new DataContext();
        #region All Consultation Drugs
        public List<ConsultationPriceView> GetAllPrice()
        {
            using (var clinicrepo = new ConsultationPriceRepository())
            {
                return clinicrepo.Getall().Select(x => new ConsultationPriceView() { PriceId = x.PriceId, PriceCost = x.PriceCost,DateEdited = x.DateEdited,DateCreated = x.DateCreated}).ToList();
            }
        }
        #endregion


        #region GETeditMethod...
        public ConsultationPriceView GETeditMethod(int? id)
        {
            ConsultationPriceView cv = new ConsultationPriceView();

            using (var deprepo = new ConsultationPriceRepository())
            {
                if (id.HasValue && id != 0)
                {
                    ConsultationPrice _consultPrice = deprepo.FindbyId(id.Value);

                    cv.PriceCost = _consultPrice.PriceCost;
                    cv.PriceId = _consultPrice.PriceId;
                }

                return cv;
            }
        }
        #endregion

        #region PostEditMethod...
        public ConsultationPriceView PostEditMethod(ConsultationPriceView cv)
        {

            using (var deprepo = new ConsultationPriceRepository())
            {
                var date = DateTime.Now;
                string dateeditted = date.ToString("U");
                if (cv.PriceId == 0)
                {
                    ConsultationPrice _ConsultPrice = new ConsultationPrice()
                    {
                        PriceId = cv.PriceId,
                        PriceCost = cv.PriceCost,
                       
                    };

                    deprepo.Create(_ConsultPrice);
                }

                else
                {
                    ConsultationPrice _consultprice = deprepo.FindbyId(cv.PriceId);

                    _consultprice.PriceId = cv.PriceId;
                    _consultprice.PriceCost = cv.PriceCost;
                    _consultprice.DateEdited = dateeditted;
                    deprepo.Update(_consultprice);
                }

                return cv;
            }
        }
        #endregion

        #region Details Method...
        public ConsultationPriceView DetailsMethod(int? id)
        {
            ConsultationPriceView cv = new ConsultationPriceView();

            using (var deprepo = new ConsultationPriceRepository())
            {
                if (id.HasValue && id != 0)
                {
                    ConsultationPrice _consultprice = deprepo.FindbyId(id.Value);

                    cv.PriceId = _consultprice.PriceId;
                    cv.PriceCost = _consultprice.PriceCost;
                    cv.DateCreated = _consultprice.DateCreated;
                    cv.DateEdited = _consultprice.DateCreated;
                }

                return cv;
            }
        }
        #endregion

        

        #region CreateMethod...
        public void CreateMethod(ConsultationPriceView cv)
        {
            var date = DateTime.Now;
            string datecreated = date.ToString("d");
            string dateeditted = date.ToString("U");
            using (var deprepo = new ConsultationPriceRepository())
            {
                if (cv.PriceId == 0)
                {
                    ConsultationPrice _consultprice = new ConsultationPrice
                    {
                        PriceId = cv.PriceId,
                        PriceCost = cv.PriceCost,
                        DateCreated = datecreated,
                        DateEdited = dateeditted,
                    };

                    deprepo.Create(_consultprice);
                }
            }
        }
        #endregion

        #region Get the Last Price
        public decimal Price()
        {
            try
            {
                var price = dc.ConsultationPrices.ToList().Last();
                return price.PriceCost;
            }
            catch (Exception)
            {
                return 0;
            }
           

        }
        #endregion
    }
}
