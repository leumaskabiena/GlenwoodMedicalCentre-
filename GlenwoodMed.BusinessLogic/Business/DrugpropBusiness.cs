using GlenwoodMed.BusinessLogic.IBusiness;
using GlenwoodMed.Data.Tables;
using GlenwoodMed.Model.ViewModels;
using GlenwoodMed.Service.RepositoryClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.BusinessLogic.Business
{
    public class DrugpropBusiness : IDrugpropBusiness
    {
        public List<Drug_PropertiesModel> GetAllDrugprop()
        {
            using (var drugp = new DrugpropRepository())
            {
                return drugp.GetAll().Select(x => new Drug_PropertiesModel()
                 {
                     DrugCode = x.DrugCode,
                     DrugName = x.DrugName,
                     DrugCategory = x.DrugCategory,
                     DrugDescription = x.DrugDescription,
                 }).ToList();
            }
        }

        public Drug_PropertiesModel GetDrugpropId(string id)
        {
            Drug_PropertiesModel dr = new Drug_PropertiesModel();
            using (var drugp = new DrugpropRepository())
            {
                if (id != null)
                {
                    var _drug = drugp.GetById(id);
                    dr.DrugCode = _drug.DrugCode;
                }
                return dr;
            }

        }

        public Drug_PropertiesModel DetailsMethod(string id)
        {
            Drug_PropertiesModel dr = new Drug_PropertiesModel();
            using (var drugr = new DrugpropRepository())
            {
                if (id != null)
                {
                    var _drug = drugr.GetById(id);

                    dr.DrugCode = _drug.DrugCode;
                    dr.DrugName = _drug.DrugName;
                    dr.DrugCategory = _drug.DrugCategory;
                    dr.DrugDescription = _drug.DrugDescription;
                }
                return dr;
            }
        }

        public void CreateMethod(Drug_PropertiesModel model)
        {
            using (var drugr = new DrugpropRepository())
            {
                Drug_Properties _drug = new Drug_Properties
                {
                    DrugCode = model.DrugCode,
                    DrugName = model.DrugName,
                    DrugCategory = model.DrugCategory,
                    DrugDescription = model.DrugDescription
                };
                drugr.Insert(_drug);
            }
        }

        public Drug_PropertiesModel GETeditMethod(string id)
        {
            Drug_PropertiesModel dr = new Drug_PropertiesModel();
            using (var drugr = new DrugpropRepository())
            {
                if (id != null)
                {
                    Drug_Properties _drug = drugr.GetById(id);
                    dr.DrugCode = _drug.DrugCode;
                    dr.DrugName = _drug.DrugName;
                    dr.DrugCategory = _drug.DrugCategory;
                    dr.DrugDescription = _drug.DrugDescription;
                }
                return dr;
            }
        }

        public Drug_PropertiesModel PostEditMethod(Drug_PropertiesModel model)
        {
            using (var drugr = new DrugpropRepository())
            {
                if (model.DrugCode == null)
                {
                    Drug_Properties _drug = new Drug_Properties
                    {
                        DrugCode = model.DrugCode,
                        DrugName = model.DrugName,
                        DrugCategory = model.DrugCategory,
                        DrugDescription = model.DrugDescription
                    };
                    drugr.Insert(_drug);
                }
                else
                {
                    //var _drug = drugr.GetById(dr.DrugId);
                    Drug_Properties _drug = drugr.GetById(model.DrugCode);
                    _drug.DrugCode = model.DrugCode;
                    _drug.DrugName = model.DrugName;
                    _drug.DrugCategory = model.DrugCategory;
                    _drug.DrugDescription = model.DrugDescription;

                    drugr.Update(_drug);
                }
                return model;
            }
        }

        public Drug_PropertiesModel GETdeleteMethod(string id)
        {
            Drug_PropertiesModel dr = new Drug_PropertiesModel();
            using (var drugr = new DrugpropRepository())
            {
                if (id != null)
                {
                    Drug_Properties _drug = drugr.GetById(id);
                    dr.DrugCode = _drug.DrugCode;
                    dr.DrugName = _drug.DrugName;
                    dr.DrugCategory = _drug.DrugCategory;
                    dr.DrugDescription = _drug.DrugDescription;
                }
                return dr;
            }
        }

        public void PostDeleteMethod(string id)
        {
            using (var drugr = new DrugpropRepository())
            {
                if (id != null)
                {
                    Drug_Properties _drug = drugr.GetById(id);
                    drugr.Delete(_drug);
                }
            }
        }
    }
}
