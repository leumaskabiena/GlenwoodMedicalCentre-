using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using GlenwoodMed.Data;
using System.Threading.Tasks;
using GlenwoodMed.Data.Tables;
using GlenwoodMed.Model.ViewModels;
using GlenwoodMed.Service.RepositoryClass;
using GlenwoodMed.BusinessLogic.IBusiness;

namespace GlenwoodMed.BusinessLogic.Business
{
    public class ReferalBus : IReferalBus
    {
        DataContext da = new DataContext();
        #region Getting all the Letters
        public List<ReferralModel> GetAll()
        {
            using (var refL = new ReferalRepository())
            {
                // PatientRepository pt = new PatientRepository();
                //var reff = pt.GetAll().Find(x => x.PatientId == id);
                return refL.GetAll().Select(x => new ReferralModel()
                {
                    Ref_Id = x.Ref_Id,
                    Ref_date = x.Ref_date,
                    //Doctor_name = x.Doctor_name,
                    //Doc_Number = x.Doc_Number,
                    Referred_Doctor = x.Referred_Doctor,
                    Patient_name = x.Patient_name,
                    Patient_age = x.Patient_age,
                    Patient_number = x.Patient_number,
                    Reason = x.Reason,
                    PatientId = x.PatientId
                }).ToList();
            }
        #endregion
        }
        #region Getting Test by ID
        public ReferralModel GetTestById(int? id)
        {
            ReferralModel rl = new ReferralModel();
            using (var drugr = new ReferalRepository())
            {
                if (id != null)
                {
                    var _ref = drugr.GetById(id.Value);
                    rl.Ref_Id = _ref.Ref_Id;
                }

                return rl;
            }
        #endregion
        }
        #region CreatingMethod
        public void CreateMethod(ReferralModel model)
        {
            PatientRepository pt = new PatientRepository();
            //var name = pt.GetAll().ToList().Find(x => x.PatientId == PatientId);
            using (var refL = new ReferalRepository())
            {
                //if (model.Ref_Id == 0)
                // {
                Referral _ref = new Referral
                {
                    Ref_Id = model.Ref_Id,
                    Ref_date = model.Ref_date,
                    //Doctor_name = model.Doctor_name,
                    //Doc_Number = model.Doc_Number,
                    Referred_Doctor = model.Referred_Doctor,
                    Patient_name = model.Patient_name,
                    Patient_age = model.Patient_age,
                    Patient_number = model.Patient_number,
                    Reason = model.Reason,
                    PatientId = model.PatientId


                };
                refL.Insert(_ref);
                //}
            }

        }
        #endregion
    }
}
