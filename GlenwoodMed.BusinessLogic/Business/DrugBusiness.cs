using System.Collections.Generic;
using System.Linq;
using GlenwoodMed.Data.Tables;
using GlenwoodMed.Model.ViewModels;
using GlenwoodMed.Service.RepositoryClass;
using System;
using System.Text;
using System.Threading.Tasks;
using GlenwoodMed.BusinessLogic.IBusiness;
using GlenwoodMed.Data;


namespace GlenwoodMed.BusinessLogic.Business
{
    public class DrugBusiness : IDrugBusiness
    {
        #region Getting all the drugs
        public List<DrugModel> GetAll()
        {
            using (var drgR = new DrugRespo())
            {
                return drgR.GetAll().Select(x => new DrugModel()
                {
                    DrugId = x.DrugId,
                    DrugCode = x.DrugCode,
                    DrugName = x.DrugName,
                    DrugCategory = x.DrugCategory,
                    DrugDescription = x.DrugDescription,
                    DrugQuantity = x.DrugQuantity,
                    Status = x.Status,
                    DrugType = x.DrugType,
                    DrugPrice = x.DrugPrice
                }).ToList();         
            }
        }
        #endregion

        #region Getting drug by ID
        public DrugModel GetDrugId(int? id)
        {
            //var dr=new DrugModel();
            DrugModel dr = new DrugModel();
            using (var drugr = new DrugRespo())
            {
                if (id != null)
                {
                    var _drug = drugr.GetById(id.Value);
                    // Drug _drug = drugr.GetById(id.Value);
                    dr.DrugId = _drug.DrugId;
                }

                return dr;
            }
        
        }
        #endregion

        #region DetailsMethod
        public DrugModel DetailsMethod(int? id)
        {
            //var dr=new DrugModel();
            DrugModel dr = new DrugModel();
            using (var drugr = new DrugRespo())
            {
                if (id.HasValue && id != 0)
                {
                    Drug _drug = drugr.GetById(id.Value);

                    dr.DrugId = _drug.DrugId;

                    dr.DrugCode = _drug.DrugCode;
                    dr.DrugName = _drug.DrugName;
                    dr.DrugCategory = _drug.DrugCategory;
                    dr.DrugDescription = _drug.DrugDescription;
                    dr.DrugQuantity = _drug.DrugQuantity;
                    dr.Status = _drug.Status;
                    dr.DrugType = _drug.DrugType;
                    dr.DrugPrice = _drug.DrugPrice;
                }
                return dr;
            }
        }
        #endregion

        public bool nameexists(string name, string type)
        {
            DataContext da = new DataContext();

            var e = da.Drugs.ToList().Find(x => x.DrugCode == name);

            if(e.DrugCode.Equals(name) && e.DrugType.Equals(type))
            {
                return true;
            }

            return false;
        }
        #region CreatingMethod
        public void CreateMethod(DrugModel model, string DrugType)
        {
            DrugpropRepository dp = new DrugpropRepository();

            using (var drugr = new DrugRespo())
            {
                if (model.DrugId == 0)
                {
                    Drug _drug = new Drug();
                    //_drug.DrugId = model.DrugId;
                    _drug.DrugCode = model.DrugCode;
                    _drug.DrugName = dp.GetById(model.DrugCode).DrugName + " (" + DrugType + ")";
                    _drug.DrugCategory = dp.GetById(model.DrugCode).DrugCategory;
                    _drug.DrugDescription = dp.GetById(model.DrugCode).DrugDescription;
                    _drug.DrugQuantity = model.DrugQuantity;
                    _drug.Status = "Available";
                    _drug.DrugPrice = model.DrugPrice;
                    _drug.DrugType = DrugType;
                    _drug.DateCreated = DateTime.Now;

                    drugr.Insert(_drug);
                }
            }   
        }
        #endregion

        #region GetReviewMethod/Edit
        public DrugModel GetReviewMethod(int? id)
        {
            //var dr=new DrugModel();
            DrugModel dr = new DrugModel();
            using (var drugr = new DrugRespo())
            {
                if (id.HasValue && id != 0)
                {
                    Drug _drug = drugr.GetById(id.Value);
                    dr.DrugId = _drug.DrugId;
                    dr.DrugCode = _drug.DrugCode;
                    dr.DrugName = _drug.DrugName;
                    dr.DrugCategory = _drug.DrugCategory;
                    dr.DrugDescription = _drug.DrugDescription;
                    dr.DrugQuantity = _drug.DrugQuantity;
                    dr.Status = _drug.Status;
                    dr.DrugPrice = _drug.DrugPrice;
                    dr.DrugType = _drug.DrugType;
                }
                return dr;
            }
        }
        #endregion

        #region PostReviewMethod/Edit
        public DrugModel PostReviewMethod(DrugModel model)
        {
            using (var drugr = new DrugRespo())
            {
                if (model.DrugId == 0)
                {
                    Drug _drug = new Drug
                    {
                        DrugId = model.DrugId,
                        DrugCode = model.DrugCode,
                        DrugName = model.DrugName,
                        DrugCategory = model.DrugCategory,
                        DrugDescription = model.DrugDescription,
                        DrugQuantity = model.DrugQuantity,
                        Status = model.Status,
                        DrugPrice = model.DrugPrice,
                        DrugType = model.DrugType,
                    };
                    drugr.Insert(_drug);
                }
                else
                {
                    //var _drug = drugr.GetById(dr.DrugId);
                    Drug _drug = drugr.GetById(model.DrugId);
                    _drug.DrugId = model.DrugId;
                    _drug.DrugCode = model.DrugCode;
                    _drug.DrugName = model.DrugName;
                    _drug.DrugCategory = model.DrugCategory;
                    _drug.DrugDescription = model.DrugDescription;
                    _drug.DrugQuantity = model.DrugQuantity;
                    _drug.Status = model.Status;
                    _drug.DrugPrice = model.DrugPrice;
                    _drug.DrugType = model.DrugType;

                    drugr.Update(_drug);
                }
                return model;
            }
        }
        #endregion

        #region GetDeleteMethod
        public DrugModel GetDeleteMethod(int id)
        {
            DrugModel dr = new DrugModel();
            using (var drugr = new DrugRespo())
            {
                if (id != 0)
                {
                    Drug _drug = drugr.GetById(id);
                    dr.DrugId = _drug.DrugId;
                    dr.DrugCode = _drug.DrugCode;
                    dr.DrugName = _drug.DrugName;
                    dr.DrugCategory = _drug.DrugCategory;
                    dr.DrugDescription = _drug.DrugDescription;
                    dr.DrugQuantity = _drug.DrugQuantity;
                    dr.Status = _drug.Status;
                    dr.DrugPrice = _drug.DrugPrice;
                    dr.DrugType = _drug.DrugType;
                }
                return dr;
            }
        }
        #endregion

        #region PostDeleteMethod
        public void PostDeleteMethod(int id)
        {
            using (var drugr = new DrugRespo())
            {
                if (id != 0)
                {
                    // var _drug = drugr.GetById(id);
                    Drug _drug = drugr.GetById(id);
                    drugr.Delete(_drug);
                }
            }
        }
        #endregion


        public void Save()
        {
        }

    }
}