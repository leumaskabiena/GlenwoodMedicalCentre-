using GlenwoodMed.BusinessLogic.IBusiness;
using GlenwoodMed.Data;
using GlenwoodMed.Data.Tables;
using GlenwoodMed.Model.ViewModels;
using GlenwoodMed.Service.RepositoryClass;
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Web.WebPages.Html;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GlenwoodMed.BusinessLogic.Business
{
    public class DependentBusiness : IDependentBusiness
    {
        DataContext da = new DataContext();
        public UserManager<GlenwoodMed.Data.ApplicationUser> UserManager { get; set; }

        public DependentBusiness()
        {
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new DataContext()));
        }
        #region GetAllDependents...
        public List<DependentModel> GetAllDependents(int Id)
        {
            using (var deprepo = new DependentRepository())
            {
                int MyId = Convert.ToInt32(Id);

                var name = da.Patients.ToList().Find(x => x.PatientId == MyId);

                var user = deprepo.GetAll().FindAll(x => x.PatientId == Id).ToList();

                return user.Select(x => new DependentModel() 
                {
                    DependentId = x.DependentId,
                    IdentityNo = x.IdentityNo,
                    DependentFname = x.DependentFname,
                    DependentSname = x.DependentSname,
                    DependentRole = x.DependentRole,
                    DOB_Dependent = x.DOB_Dependent,
                    Sex = x.Sex,
                    Title = x.Title,
                    Age = x.Age,
                    DependentAllergy = x.DependentAllergy,
                    patientName = name.FullName,
                    PatientId = name.PatientId
                }).ToList();
            }
        }
        #endregion

        //#region GetAllDependents...
        //public List<DependentModel> GetAllStaffDependents(int Id)
        //{
        //    RegisterRepository rp = new RegisterRepository();
        //    using (var deprepo = new DependentRepository())
        //    {
        //        var name = rp.GetAll().ToList().Find(x => x.Id == Id);

        //        var user = deprepo.GetAll().FindAll(x => x.PatientId == Id).ToList();

        //        return user.Select(x => new DependentModel()
        //        {
        //            DependentId = x.DependentId,
        //            IdentityNo = x.IdentityNo,
        //            DependentFname = x.DependentFname,
        //            DependentSname = x.DependentSname,
        //            DependentRole = x.DependentRole,
        //            DOB_Dependent = x.DOB_Dependent,
        //            Sex = x.Sex,
        //            Title = x.Title,
        //            Age = x.Age,
        //            DependentAllergy = x.DependentAllergy,
        //            patientName = name.FullName
        //        }).ToList();
        //    }
        //}
        //#endregion

        #region GetDependentId...
        public DependentModel GetDependentId(int? id)
        {
            DependentModel cv = new DependentModel();

            using (var deprepo = new DependentRepository())
            {
                Dependent _dep = deprepo.GetById(id.Value);

                cv.DependentId = _dep.DependentId;

                return cv;
            }
        }
        #endregion

        #region Details Method...
        public DependentModel DetailsMethod(int? id)
        {
            DependentModel cv = new DependentModel();

            using (var deprepo = new DependentRepository())
            {
                if (id.HasValue && id != 0)
                {
                    Dependent _dep = deprepo.GetById(id.Value);

                    cv.DependentId = _dep.DependentId;
                    cv.IdentityNo = _dep.IdentityNo;
                    cv.DependentFname = _dep.DependentFname;
                    cv.DependentSname = _dep.DependentSname;
                    cv.Title = _dep.Title;
                    cv.Age = _dep.Age;
                    cv.DependentRole = _dep.DependentRole;
                    cv.DOB_Dependent = _dep.DOB_Dependent;
                    cv.Sex = _dep.Sex;
                    cv.DependentAllergy = _dep.DependentAllergy;
                    cv.patientName = _dep.PatientId.ToString();
                }

                return cv;
            }
        }
        #endregion

        #region CreateMethod...
        public void CreateMethod(DependentModel cv, int patientid, string Gender, string Role, string Title)
        {
            using (var deprepo = new DependentRepository())
            {
                //if (cv.DependentId == 0)
                //{
                    //string date = cv.DOB_Dependent.ToString("d");
                    string result = cv.DOB_Dependent.Substring(6);
                    int currentyear = DateTime.Now.Year;

                    int age = currentyear - Convert.ToInt32(result);
                    Dependent _dependent = new Dependent
                    {
                        DependentId = cv.DependentId,
                        IdentityNo = cv.IdentityNo,
                        DependentFname = cv.DependentFname,
                        DependentSname = cv.DependentSname,
                        DependentRole = Role,
                        DOB_Dependent = cv.DOB_Dependent, //date,
                        Sex = Gender,
                        Title = Title,
                        Age = Convert.ToString(age),
                        DependentAllergy = cv.DependentAllergy,
                        PatientId = patientid
                    };

                    deprepo.Insert(_dependent);
                //}
            }
        }
        #endregion

        public IEnumerable<SelectListItem> DDPatient()
        {
            PatientRepository parepo = new PatientRepository();

            var patient = parepo
                        .GetAll()
                        .Select(x =>
                                new SelectListItem
                                {
                                    Value = x.PatientId.ToString(),
                                    Text = x.FullName + " " + x.Surname
                                });

            return new SelectList(patient, "Value", "Text");
        }

        #region AdditionalCreateMethod...
        public void AdditionalCreateMethod(DependentModel cv, int patientid, string Gender, string Role, string Title)
        {

            using (var deprepo = new DependentRepository())
            {
                if (cv.DependentId == 0)
                {
                    //int paid = Convert.ToInt32(patientid);
                    //var patientemailKey = da.Patients.ToList().Find(x => x.PatientId == paid);

                    //string date = cv.DOB_Dependent.ToString("d");
                    string result = cv.DOB_Dependent.Substring(6);
                    int currentyear = DateTime.Now.Year;

                    int age = currentyear - Convert.ToInt32(result);

                    Dependent _dependent = new Dependent
                    {
                        DependentId = cv.DependentId,
                        IdentityNo = cv.IdentityNo,
                        DependentFname = cv.DependentFname,
                        DependentSname = cv.DependentSname,
                        DependentRole = Role,
                        Title = cv.Title,
                        DOB_Dependent = cv.DOB_Dependent, //date,
                        Sex = Gender,
                        Age = Convert.ToString(age),
                        DependentAllergy = cv.DependentAllergy,
                        PatientId = patientid
                    };

                    deprepo.Insert(_dependent);
                }
            }
        }
        #endregion

        #region GETeditMethod...
        public DependentModel GETeditMethod(int? id)
        {
            DependentModel cv = new DependentModel();

            using (var deprepo = new DependentRepository())
            {
                if (id.HasValue && id != 0)
                {
                    Dependent _dependent = deprepo.GetById(id.Value);

                    cv.DependentId = _dependent.DependentId;
                    cv.IdentityNo = _dependent.IdentityNo;
                    cv.DependentFname = _dependent.DependentFname;
                    cv.DependentSname = _dependent.DependentSname;
                    cv.DependentRole = _dependent.DependentRole;
                    cv.DOB_Dependent = _dependent.DOB_Dependent;
                    cv.Sex = _dependent.Sex;
                    cv.Title = _dependent.Title;
                    cv.Age = _dependent.Age;
                    cv.DependentAllergy = _dependent.DependentAllergy;
                }

                return cv;
            }
        }
        #endregion

        #region PostEditMethod...
        public DependentModel PostEditMethod(DependentModel cv)
        {
            //string date = cv.DOB_Dependent.ToString("d");
            string result = cv.DOB_Dependent.Substring(6);
            int currentyear = DateTime.Now.Year;

            int age = currentyear - Convert.ToInt32(result);

            using (var deprepo = new DependentRepository())
            {
                if (cv.DependentId == 0)
                {
                    Dependent _dependent = new Dependent
                    {
                        DependentId = cv.DependentId,
                        IdentityNo = cv.IdentityNo,
                        DependentFname = cv.DependentFname,
                        DependentSname = cv.DependentSname,
                        DependentRole = cv.DependentRole,
                        DOB_Dependent = cv.DOB_Dependent, //date,
                        Sex = cv.Sex,
                        Title = cv.Title,
                        Age = Convert.ToString(age),
                        DependentAllergy = cv.DependentAllergy,
                    };

                    deprepo.Insert(_dependent);
                }

                else
                {
                    Dependent _dependent = deprepo.GetById(cv.DependentId);

                    _dependent.DependentId = cv.DependentId;
                    _dependent.IdentityNo = cv.IdentityNo;
                    _dependent.DependentFname = cv.DependentFname;
                    _dependent.DependentSname = cv.DependentSname;
                    _dependent.DependentRole = cv.DependentRole;
                    _dependent.DOB_Dependent = cv.DOB_Dependent;// date;
                    _dependent.Sex = cv.Sex;
                    _dependent.Age = Convert.ToString(age);
                    _dependent.Title = cv.Title;
                    _dependent.DependentAllergy = cv.DependentAllergy;

                    deprepo.Update(_dependent);
                }

                return cv;
            }
        }
        #endregion

        #region GETdeleteMethod...
        public DependentModel GETdeleteMethod(int id)
        {
            DependentModel cv = new DependentModel();

            using (var deprepo = new DependentRepository())
            {
                if (id != 0)
                {
                    Dependent _dependent = deprepo.GetById(id);

                    cv.DependentId = _dependent.DependentId;
                    cv.IdentityNo = _dependent.IdentityNo;
                    cv.DependentFname = _dependent.DependentFname;
                    cv.DependentSname = _dependent.DependentSname;
                    cv.DependentRole = _dependent.DependentRole;
                    cv.DOB_Dependent = _dependent.DOB_Dependent;
                    cv.Sex = _dependent.Sex;
                    cv.Title = _dependent.Title;
                    cv.Age = _dependent.Age;
                    cv.DependentAllergy = _dependent.DependentAllergy;
                    cv.patientName = _dependent.PatientId.ToString();
                }

                return cv;
            }
        }
        #endregion

        #region PostDeleteMethod...
        public void PostDeleteMethod(int id)
        {
            using (var deprepo = new DependentRepository())
            {
                if (id != 0)
                {
                    Dependent _dependent = deprepo.GetById(id);
                    deprepo.Delete(_dependent);
                }
            }
        }
        #endregion

        #region GetDependents...
        public List<Dependent> GetDependents()
        {
            return da.Dependents.ToList();
        }
        #endregion

        #region GetDependentId...
        public Dependent GetDependentId(int id)
        {
            return GetDependents().Find(x => x.DependentId == id);
        }
        #endregion
    }
}
