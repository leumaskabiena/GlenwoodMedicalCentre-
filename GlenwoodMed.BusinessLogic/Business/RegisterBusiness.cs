using GlenwoodMed.Data;
using GlenwoodMed.Data.Tables;
using GlenwoodMed.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlenwoodMed.BusinessLogic.IBusiness;
using GlenwoodMed.Service.RepositoryClass;
using GlenwoodMed.Model.ViewModels;

namespace GlenwoodMed.BusinessLogic
{
    public class RegisterBusiness : IRegisterBusiness
    {
        DataContext ida = new DataContext();
        RegisterRepository rp = new RegisterRepository();
        RolesBusiness rol = new RolesBusiness();

        public UserManager<GlenwoodMed.Data.ApplicationUser> UserManager { get; set; }

        public RegisterBusiness()
        {
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new DataContext()));
        }

        public bool FindUser(string userId, IAuthenticationManager authenticationManager)
        {
            var user = UserManager.FindByName(userId);

            if (user != null)
            {
                return true;
            }
            return false;
        }

        public bool FindUserId(string userId)
        {
            var user = rp.GetAll().Find(x => x.NationalId == userId);

            if (user != null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> RegisterUser(RegisterModel objRegisterModel, IAuthenticationManager authenticationManager, string Gender, string Status, string Id, string Title)
        {
            //string re = objRegisterModel.DOB.Substring(6);
            int birthyear = Convert.ToDateTime(objRegisterModel.DOB).Year;
            int currentyear = DateTime.Now.Year;

            //int age = currentyear - Convert.ToInt32(re);
            int Yourage = currentyear - birthyear;
            var newuser = new ApplicationUser()
            {
                UserName = objRegisterModel.Email,
                Email = objRegisterModel.Email,
                Age = Convert.ToString(Yourage),
                Password = objRegisterModel.Password,
                FullName = objRegisterModel.FullName,
                Surname = objRegisterModel.Surname,
                Title = objRegisterModel.Title,
                MaritalStatus = Status,
                DOB = objRegisterModel.DOB,
                Sex = Gender,
                Address1 = objRegisterModel.Address1,
                Address2 = objRegisterModel.Address2,
                Address3 = objRegisterModel.Address3,
                PostalCode = objRegisterModel.PostalCode,
                Telephone = objRegisterModel.Telephone,
                Employer = objRegisterModel.Employer,
                EmployerTelephone = objRegisterModel.EmployerTelephone,
                Occupation = objRegisterModel.Occupation,
                NationalId = objRegisterModel.NationalId,
                Status = "Alive",
                PatientAllergy = objRegisterModel.PatientAllergy,
                MedicalAidName = objRegisterModel.MedicalAidName,
                MedicalAidNo = objRegisterModel.MedicalAidNo,
                Role = "Staff"
            };

            var result = await UserManager.CreateAsync(
               newuser, objRegisterModel.Password);

            string error = "";
            rol.AddRoleToUser(Id, newuser.Id, error);

            if (result.Succeeded)
            {
                System.Web.HttpContext.Current.Session["PatientId"] = newuser.Id.ToString();
                //await SignInAsync(newuser, false, authenticationManager);
                return true;
            }
            return false;
        }

        public async Task<bool> RegisterPa(PatientModel objRegisterModel, IAuthenticationManager authenticationManager, string Gender, string Status, string Title, string Patient_No)
        {
            //string re = objRegisterModel.DOB.Substring(6);
            int birthyear = Convert.ToDateTime(objRegisterModel.DOB).Year;
            int currentyear = DateTime.Now.Year;

            //int age = currentyear - Convert.ToInt32(re);
            int Yourage = currentyear - birthyear;
            ApplicationUser newuser = new ApplicationUser();
        ////{    
            newuser.UserName = objRegisterModel.Email;
                newuser.Email = objRegisterModel.Email;
                newuser.Age = Convert.ToString(Yourage);
                newuser.Password = objRegisterModel.NationalId;
                newuser.FullName = objRegisterModel.FullName;
                newuser.Surname = objRegisterModel.Surname;
                newuser.Title = objRegisterModel.Title;
                newuser.MaritalStatus = Status;
                newuser.DOB = objRegisterModel.DOB;
                newuser.Sex = Gender;
                foreach (PatientAddressModel pa in objRegisterModel.PatientAddresses.ToList())
                {
                    if (pa.DeleteAddress == true)
                    {
                        // Delete address which is marked to remove
                        objRegisterModel.PatientAddresses.Remove(pa);
                    }
                }

                foreach (var item in objRegisterModel.PatientAddresses.ToList())
                {
                    UserAddress padd = new UserAddress();
                    padd.Address = item.Address;
                    newuser.UserAddresses.Add(padd);
                }

                newuser.Address1 = objRegisterModel.Address1;
                newuser.Address2 = objRegisterModel.Address2;
                newuser.Address3 = objRegisterModel.Address3;
                newuser.PostalCode = objRegisterModel.PostalCode;
                newuser.Telephone = objRegisterModel.Telephone;
                newuser.Employer = objRegisterModel.Employer;
                newuser.EmployerTelephone = objRegisterModel.EmployerTelephone;
                newuser.Occupation = objRegisterModel.Occupation;
                newuser.NationalId = objRegisterModel.NationalId;
                newuser.Status = "Alive";
                newuser.PatientAllergy = objRegisterModel.PatientAllergy;
                newuser.MedicalAidName = objRegisterModel.MedicalAidName;
                newuser.MedicalAidNo = objRegisterModel.MedicalAidNo;
                newuser.Role = "Patient";
                newuser.PatientNo = Patient_No;
            //};

            var result = await UserManager.CreateAsync(
               newuser, objRegisterModel.NationalId);

            string error = "";
            string myrole = "Patient";

            rol.AddPatientToRole(myrole, newuser.Id, error);

            if (result.Succeeded)
            {
                //System.Web.HttpContext.Current.Session["PatientId"] = newuser.Id.ToString();
                //await SignInAsync(newuser, false, authenticationManager);
                return true;
            }
            return false;
        }

        public void RegisterPatient(PatientModel objRegisterModel, IAuthenticationManager authenticationManager, string Gender, string Status, string Title)
        {
            //string re = objRegisterModel.DOB.Substring(6);
            int birthyear = Convert.ToDateTime(objRegisterModel.DOB).Year;
            int currentyear = DateTime.Now.Year;

            //int age = currentyear - Convert.ToInt32(re);
            int Yourage = currentyear - birthyear;
            var newuser = new ApplicationUser()
            {
                UserName = objRegisterModel.Email,
                Email = objRegisterModel.Email,
                Age = Convert.ToString(Yourage),
                Password = objRegisterModel.NationalId,
                FullName = objRegisterModel.FullName,
                Surname = objRegisterModel.Surname,
                Title = objRegisterModel.Title,
                MaritalStatus = Status,
                DOB = objRegisterModel.DOB,
                Sex = Gender,
                Address1 = objRegisterModel.Address1,
                Address2 = objRegisterModel.Address2,
                Address3 = objRegisterModel.Address3,
                PostalCode = objRegisterModel.PostalCode,
                Telephone = objRegisterModel.Telephone,
                Employer = objRegisterModel.Employer,
                EmployerTelephone = objRegisterModel.EmployerTelephone,
                Occupation = objRegisterModel.Occupation,
                NationalId = objRegisterModel.NationalId,
                Status = "Alive",
                PatientAllergy = objRegisterModel.PatientAllergy,
                MedicalAidName = objRegisterModel.MedicalAidName,
                MedicalAidNo = objRegisterModel.MedicalAidNo,
                Role = "Patient"
            };

            var result = UserManager.CreateAsync(
               newuser, objRegisterModel.NationalId);

            string error = "";
            string myrole = "Patient";

            rol.AddPatientToRole(myrole, newuser.Id, error);
            //if (result.Succeeded)
            //{
            //    return true;
            //}
            //return false;
        }

        private async Task SignInAsync(ApplicationUser user, bool isPersistent, IAuthenticationManager authenticationManager)
        {
            authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }

        #region GetAllPatients...
        public List<RegisterModel> GetAllPatients()
        {
            using (var deprepo = new RegisterRepository())
            {
                return deprepo.GetAll().Where(x => x.Role == "Staff").Select(x => new RegisterModel()
                {
                    Email = x.Email,
                    FullName = x.FullName,
                    Surname = x.Surname,
                    Title = x.Title,
                    MaritalStatus = x.MaritalStatus,
                    DOB = x.DOB,
                    Age = x.Age,
                    Sex = x.Sex,
                    Address1 = x.Address1,
                    Address2 = x.Address2,
                    Address3 = x.Address3,
                    PostalCode = x.PostalCode,
                    Telephone = x.Telephone,
                    Employer = x.Employer,
                    EmployerTelephone = x.EmployerTelephone,
                    Occupation = x.Occupation,
                    NationalId = x.NationalId,
                    Status = x.Status,
                    MedicalAidName = x.MedicalAidName,
                    MedicalAidNo = x.MedicalAidNo
                }).ToList();
            }
        }
        #endregion

        #region GETeditUserMethod...
        public EditProfileModel GETeditUserMethod(string id)
        {
            EditProfileModel _registerModel = new EditProfileModel();

            using (var reg_repo = new RegisterRepository())
            {
                if (id != null)
                {
                    ApplicationUser _user = reg_repo.GetById(id);

                    _registerModel.UserName = _user.UserName;
                    _registerModel.Email = _user.Email;
                    _registerModel.FullName = _user.FullName;
                    _registerModel.Surname = _user.Surname;
                    _registerModel.Title = _user.Title;
                    _registerModel.Age = _user.Age;
                    _registerModel.Password = _user.Password;
                    _registerModel.MaritalStatus = _user.MaritalStatus;
                    _registerModel.DOB = _user.DOB;
                    _registerModel.Sex = _user.Sex;
                    _registerModel.Address1 = _user.Address1;
                    _registerModel.Address2 = _user.Address2;
                    _registerModel.Address3 = _user.Address3;
                    _registerModel.PostalCode = _user.PostalCode;
                    _registerModel.Telephone = _user.Telephone;
                    _registerModel.Employer = _user.Employer;
                    _registerModel.EmployerTelephone = _user.EmployerTelephone;
                    _registerModel.Occupation = _user.Occupation;
                    _registerModel.NationalId = _user.NationalId;
                    _registerModel.Status = _user.Status;
                    _registerModel.PatientAllergy = _user.PatientAllergy;
                    _registerModel.MedicalAidName = _user.MedicalAidName;
                    _registerModel.MedicalAidNo = _user.MedicalAidNo;
                }

                return _registerModel;
            }
        }
        #endregion

        #region GETAlleditUserMethod...
        public EditProfileModel GETAlleditUserMethod(string id)
        {
            EditProfileModel _registerModel = new EditProfileModel();

            using (var reg_repo = new RegisterRepository())
            {
                if (id != null)
                {
                    ApplicationUser _user = reg_repo.GetById(id);

                    _registerModel.UserName = _user.UserName;
                    _registerModel.Email = _user.Email;
                    _registerModel.FullName = _user.FullName;
                    _registerModel.Surname = _user.Surname;
                    _registerModel.Title = _user.Title;
                    _registerModel.Age = _user.Age;
                    _registerModel.Password = _user.Password;
                    _registerModel.MaritalStatus = _user.MaritalStatus;
                    _registerModel.DOB = _user.DOB;
                    _registerModel.Sex = _user.Sex;
                    _registerModel.Address1 = _user.Address1;
                    _registerModel.Address2 = _user.Address2;
                    _registerModel.Address3 = _user.Address3;
                    _registerModel.PostalCode = _user.PostalCode;
                    _registerModel.Telephone = _user.Telephone;
                    _registerModel.Employer = _user.Employer;
                    _registerModel.EmployerTelephone = _user.EmployerTelephone;
                    _registerModel.Occupation = _user.Occupation;
                    _registerModel.NationalId = _user.NationalId;
                    _registerModel.Status = _user.Status;
                    _registerModel.PatientAllergy = _user.PatientAllergy;
                    _registerModel.MedicalAidName = _user.MedicalAidName;
                    _registerModel.MedicalAidNo = _user.MedicalAidNo;
                }

                return _registerModel;
            }
        }
        #endregion

        #region PostEditUserMethod...
        public EditProfileModel PostEditUserMethod(EditProfileModel objRegisterModel, string id)
        {
            //string result = objRegisterModel.DOB.Substring(6);
            int birthyear = Convert.ToDateTime(objRegisterModel.DOB).Year;
            int currentyear = DateTime.Now.Year;

            //int age = currentyear - Convert.ToInt32(result);
            int Yourage = currentyear - birthyear;
            using (var reg_repo = new RegisterRepository())
            {
                ApplicationUser _user = reg_repo.GetById(id);

                _user.UserName = objRegisterModel.UserName;
                _user.Email = objRegisterModel.Email;
                _user.FullName = objRegisterModel.FullName;
                _user.Surname = objRegisterModel.Surname;
                _user.Title = objRegisterModel.Title;
                _user.Password = objRegisterModel.Password;
                _user.MaritalStatus = objRegisterModel.MaritalStatus;
                _user.DOB = objRegisterModel.DOB;
                _user.Age = Convert.ToString(Yourage);
                _user.Sex = objRegisterModel.Sex;
                _user.Address1 = objRegisterModel.Address1;
                _user.Address2 = objRegisterModel.Address2;
                _user.Address3 = objRegisterModel.Address3;
                _user.PostalCode = objRegisterModel.PostalCode;
                _user.Telephone = objRegisterModel.Telephone;
                _user.Employer = objRegisterModel.Employer;
                _user.EmployerTelephone = objRegisterModel.EmployerTelephone;
                _user.Occupation = objRegisterModel.Occupation;
                _user.NationalId = objRegisterModel.NationalId;
                _user.Status = objRegisterModel.Status;
                _user.PatientAllergy = objRegisterModel.PatientAllergy;
                _user.MedicalAidName = objRegisterModel.MedicalAidName;
                _user.MedicalAidNo = objRegisterModel.MedicalAidNo;

                reg_repo.Update(_user);

                return objRegisterModel;
            }
        }
        #endregion

        #region GetUsers...
        public List<ApplicationUser> GetUsers()
        {
            return rp.GetAll().ToList();
        }
        #endregion

        #region DropDown...
        public IEnumerable<SelectListItem> DDRoles()
        {
            RolesBusiness rb = new RolesBusiness();
            PatientRepository parepo = new PatientRepository();

            var role = rb.GetMyRoles().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            });

            return new SelectList(role, "Value", "Text");
        }
        #endregion

    }
}
