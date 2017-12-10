using GlenwoodMed.BusinessLogic.IBusiness;
using GlenwoodMed.Data;
using GlenwoodMed.Data.Tables;
using GlenwoodMed.Model;
using GlenwoodMed.Model.ViewModels;
using GlenwoodMed.Service.RepositoryClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GlenwoodMed.BusinessLogic.Business
{
    public class PatientBusiness : IPatientBusiness
    {
        PatientRepository da = new PatientRepository();

        public IEnumerable<SelectListItem> PatientDDL()
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

        #region GetAllPatients...
        public List<PatientModel> GetAllPatients()
        {
            List<PatientModel> pmlist = new List<PatientModel>();
            using (var parepo = new PatientRepository())
            {
                var patients = parepo.GetAll().ToList();
                
                foreach(var patient in patients)
                {
                    PatientModel pm = new PatientModel();

                    pm.userId = patient.PatientId;
                    pm.Email = patient.Email;
                    pm.FullName = patient.FullName;
                    pm.Surname = patient.Surname;
                    pm.MaritalStatus = patient.MaritalStatus;
                    pm.DOB = patient.DOB;
                    pm.Sex = patient.Sex;
                    pm.Title = patient.Title;
                    pm.Age = patient.Age;
                    //DDLName = PatientDDL(),
                    pm.Address1 = patient.Address1;
                    pm.Address2 = patient.Address2;
                    pm.Address3 = patient.Address3;
                    pm.PostalCode = patient.PostalCode;
                    pm.Telephone = patient.Telephone;
                    pm.Employer = patient.Employer;
                    pm.EmployerTelephone = patient.EmployerTelephone;
                    pm.Occupation = patient.Occupation;
                    pm.NationalId = patient.NationalId;
                    pm.Status = patient.Status;
                    pm.PatientAllergy = patient.PatientAllergy;
                    pm.MedicalAidName = patient.MedicalAidName;
                    pm.MedicalAidNo = patient.MedicalAidNo;
                    pm.resultFile = patient.File;
                    pm.FileName = patient.FileName;
                    pm.FileType = patient.FileType;
                    pm.registeredDate = patient.registeredDate;

                    foreach (var item in patient.PatientAddresses.ToList())
                    {
                        PatientAddressModel padd = new PatientAddressModel();
                        padd.Address = item.Address;
                        pm.PatientAddresses.Add(padd);
                    }

                    pmlist.Add(pm);
                }

                return pmlist;

                #region
                //return parepo.GetAll().Select(x => new PatientModel()
                //{
                //    userId = x.PatientId,
                //    Email = x.Email,
                //    FullName = x.FullName,
                //    Surname = x.Surname,
                //    MaritalStatus = x.MaritalStatus,
                //    DOB = x.DOB,
                //    Sex = x.Sex,
                //    Title = x.Title,
                //    Age = x.Age,
                //    //DDLName = PatientDDL(),
                //    Address1 = x.Address1,
                //    Address2 = x.Address2,
                //    Address3 = x.Address3,
                //    PostalCode = x.PostalCode,
                //    Telephone = x.Telephone,
                //    Employer = x.Employer,
                //    EmployerTelephone = x.EmployerTelephone,
                //    Occupation = x.Occupation,
                //    NationalId = x.NationalId,
                //    Status = x.Status,
                //    PatientAllergy = x.PatientAllergy,
                //    MedicalAidName = x.MedicalAidName,
                //    MedicalAidNo = x.MedicalAidNo,
                //    resultFile = x.File,
                //    FileName = x.FileName,
                //    FileType = x.FileType,
                //    registeredDate = x.registeredDate
                //}).ToList();
                #endregion
            }
        }
        #endregion

        #region GetPatientId...
        public PatientModel GetPatientId(int? id)
        {
            PatientModel rm = new PatientModel();

            using (var parepo = new PatientRepository())
            {
                Patient _patient = parepo.GetById(id.Value);

                rm.userId = _patient.PatientId;

                return rm;
            }
        }
        #endregion

        #region Details Method...
        public PatientModel DetailsMethod(int? id)
        {
            PatientModel rm = new PatientModel();

            using (var parepo = new PatientRepository())
            {
                if (id.HasValue && id != 0)
                {
                    Patient _patient = parepo.GetById(id.Value);

                    rm.userId = _patient.PatientId;
                    rm.Email = _patient.Email;
                    rm.FullName = _patient.FullName;
                    rm.Surname = _patient.Surname;
                    rm.Title = _patient.Title;
                    rm.Age = _patient.Age;
                    rm.MaritalStatus = _patient.MaritalStatus;
                    rm.DOB = _patient.DOB;
                    rm.Sex = _patient.Sex;
                    rm.Address1 = _patient.Address1;
                    rm.Address2 = _patient.Address2;
                    rm.Address3 = _patient.Address3;
                    rm.PostalCode = _patient.PostalCode;
                    rm.Telephone = _patient.Telephone;
                    rm.Employer = _patient.Employer;
                    rm.EmployerTelephone = _patient.EmployerTelephone;
                    rm.Occupation = _patient.Occupation;
                    rm.NationalId = _patient.NationalId;
                    rm.Status = _patient.Status;
                    rm.PatientAllergy = _patient.PatientAllergy;
                    rm.MedicalAidName = _patient.MedicalAidName;
                    rm.MedicalAidNo = _patient.MedicalAidNo;

                    foreach (var item in _patient.PatientAddresses.ToList())
                    {
                        PatientAddressModel padd = new PatientAddressModel();
                        padd.Address = item.Address;
                        rm.PatientAddresses.Add(padd);
                    }
                }

                return rm;
            }
        }
        #endregion

        #region CreateMethod...
        public void CreateMethod(PatientModel rm, string Gender, string Status, string Title, string Patient_No)
        {
            Email_serviceViewModel es = new Email_serviceViewModel();
            Email_serviceBusiness esb = new Email_serviceBusiness();

            using (var parepo = new PatientRepository())
            {
                //if (rm.userId == null)
                //{
                //string result = objRegisterModel.DOB.Substring(6);
                int birthyear = Convert.ToDateTime(rm.DOB).Year;
                int currentyear = DateTime.Now.Year;

                //int age = currentyear - Convert.ToInt32(result);
                int Yourage = currentyear - birthyear;

                Patient _patient = new Patient();

                _patient.PatientId = rm.userId;
                _patient.Email = rm.Email;
                _patient.FullName = rm.FullName;
                _patient.Surname = rm.Surname;
                _patient.Title = Title;
                _patient.Age = Convert.ToString(Yourage);
                _patient.MaritalStatus = Status;
                _patient.DOB = rm.DOB;
                _patient.Sex = Gender;
                List<string> list = new List<string>();
                foreach (PatientAddressModel pa in rm.PatientAddresses.ToList())
                {
                    if (pa.DeleteAddress == true)
                    {
                        // Delete address which is marked to remove
                        rm.PatientAddresses.Remove(pa);
                    }
                };

                foreach (var item in rm.PatientAddresses.ToList())
                {
                    PatientAddress padd = new PatientAddress();
                    padd.Address = item.Address;
                    _patient.PatientAddresses.Add(padd);
                }
 
                _patient.Address1 = rm.Address1;
                _patient.Address2 = rm.Address2;
                _patient.Address3 = rm.Address3;
                _patient.PostalCode = rm.PostalCode;
                _patient.Telephone = rm.Telephone;
                _patient.Employer = rm.Employer;
                _patient.EmployerTelephone = rm.EmployerTelephone;
                _patient.Occupation = rm.Occupation;
                _patient.NationalId = rm.NationalId;
                _patient.Status = "Alive";
                _patient.PatientAllergy = rm.PatientAllergy;
                _patient.MedicalAidName = rm.MedicalAidName;
                _patient.MedicalAidNo = rm.MedicalAidNo;
                _patient.registeredDate = DateTime.Now;
                _patient.PatientNo = Patient_No;

                //Code to save the image to the Db
                if (rm.File != null && rm.File.ContentLength > 0)
                {
                    _patient.FileName = System.IO.Path.GetFileName(rm.File.FileName);
                    _patient.FileType = GlenwoodMed.Model.ViewModels.FileType.Avatar;
                    _patient.ContentType = rm.File.ContentType;
                        
                    using (var reader = new System.IO.BinaryReader(rm.File.InputStream))
                    {
                        _patient.File = reader.ReadBytes(rm.File.ContentLength);
                    }
                }

                es.To = rm.Email;
                es.Subject = "Registration Details";
                es.Body = "Patient Number: " + Patient_No + "<br/>"
                            + "Username: " + rm.Email + "<br/>"
                            + "Password: " + rm.NationalId;

                parepo.Insert(_patient);

                esb.createemail(es);
                System.Web.HttpContext.Current.Session["PatientId"] = _patient.PatientId;
                //}
            }
        }
        #endregion

        #region GETeditMethod...
        public PatientModel GETeditMethod(int? id)
        {
            PatientModel rm = new PatientModel();

            using (var parepo = new PatientRepository())
            {
                if (id.HasValue && id != 0)
                {
                    Patient _patient = parepo.GetById(id.Value);

                    rm.userId = _patient.PatientId;
                    rm.Email = _patient.Email;
                    rm.FullName = _patient.FullName;
                    rm.Age = _patient.Age;
                    rm.Surname = _patient.Surname;
                    rm.Title = _patient.Title;
                    rm.MaritalStatus = _patient.MaritalStatus;
                    rm.DOB = _patient.DOB;
                    rm.Sex = _patient.Sex;
                    rm.Address1 = _patient.Address1;
                    rm.Address2 = _patient.Address2;
                    rm.Address3 = _patient.Address3;
                    rm.PostalCode = _patient.PostalCode;
                    rm.Telephone = _patient.Telephone;
                    rm.Employer = _patient.Employer;
                    rm.EmployerTelephone = _patient.EmployerTelephone;
                    rm.Occupation = _patient.Occupation;
                    rm.NationalId = _patient.NationalId;
                    rm.Status = _patient.Status;
                    rm.PatientAllergy = _patient.PatientAllergy;
                    rm.MedicalAidName = _patient.MedicalAidName;
                    rm.MedicalAidNo = _patient.MedicalAidNo;
                    rm.resultFile = _patient.File;
                    rm.FileName = _patient.FileName;
                    rm.FileType = _patient.FileType;
                    foreach (var item in _patient.PatientAddresses.ToList())
                    {
                        PatientAddressModel padd = new PatientAddressModel();
                        padd.Address = item.Address;
                        rm.PatientAddresses.Add(padd);
                    }
                }

                return rm;
            }
        }
        #endregion

        #region PostEditMethod...
        public PatientModel PostEditMethod(PatientModel rm)
        {
            //string date = rm.DOB.ToString("d");
            //string result = objRegisterModel.DOB.Substring(6);
            int birthyear = Convert.ToDateTime(rm.DOB).Year;
            int currentyear = DateTime.Now.Year;

            //int age = currentyear - Convert.ToInt32(result);
            int Yourage = currentyear - birthyear;

            using (var parepo = new PatientRepository())
            {
                if (rm.userId == 0)
                {
                    Patient _patient = new Patient();

                    _patient.PatientId = rm.userId;
                    _patient.Email = rm.Email;
                    _patient.FullName = rm.FullName;
                    _patient.Surname = rm.Surname;
                    _patient.Title = rm.Title;
                    _patient.Age = Convert.ToString(Yourage);
                    _patient.MaritalStatus = rm.Status;
                    _patient.DOB = rm.DOB;
                    _patient.Sex = rm.Sex;
                    List<string> list = new List<string>();
                    foreach (PatientAddressModel pa in rm.PatientAddresses.ToList())
                    {
                        if (pa.DeleteAddress == true)
                        {
                            // Delete address which is marked to remove
                            rm.PatientAddresses.Remove(pa);
                        }
                    };

                    foreach (var item in rm.PatientAddresses.ToList())
                    {
                        PatientAddress padd = new PatientAddress();
                        padd.Address = item.Address;
                        _patient.PatientAddresses.Add(padd);
                    }

                    _patient.Address1 = rm.Address1;
                    _patient.Address2 = rm.Address2;
                    _patient.Address3 = rm.Address3;
                    _patient.PostalCode = rm.PostalCode;
                    _patient.Telephone = rm.Telephone;
                    _patient.Employer = rm.Employer;
                    _patient.EmployerTelephone = rm.EmployerTelephone;
                    _patient.Occupation = rm.Occupation;
                    _patient.NationalId = rm.NationalId;
                    _patient.Status = "Alive";
                    _patient.PatientAllergy = rm.PatientAllergy;
                    _patient.MedicalAidName = rm.MedicalAidName;
                    _patient.MedicalAidNo = rm.MedicalAidNo;
                    _patient.registeredDate = DateTime.Now;

                    //Code to save the image to the Db
                    if (rm.File != null && rm.File.ContentLength > 0)
                    {
                        _patient.FileName = System.IO.Path.GetFileName(rm.File.FileName);
                        _patient.FileType = GlenwoodMed.Model.ViewModels.FileType.Avatar;
                        _patient.ContentType = rm.File.ContentType;

                        using (var reader = new System.IO.BinaryReader(rm.File.InputStream))
                        {
                            _patient.File = reader.ReadBytes(rm.File.ContentLength);
                        }
                    }

                    parepo.Insert(_patient);
                }

                else
                {
                    Patient _patient = parepo.GetById(rm.userId);

                    _patient.PatientId = rm.userId;
                    _patient.Email = rm.Email;
                    _patient.FullName = rm.FullName;
                    _patient.Surname = rm.Surname;
                    _patient.Age = Convert.ToString(Yourage);
                    _patient.Title = rm.Title;
                    _patient.MaritalStatus = rm.MaritalStatus;
                    _patient.DOB = rm.DOB;
                    _patient.Sex = rm.Sex;
                    _patient.Address1 = rm.Address1;
                    _patient.Address2 = rm.Address2;
                    _patient.Address3 = rm.Address3;
                    _patient.PostalCode = rm.PostalCode;
                    _patient.Telephone = rm.Telephone;
                    _patient.Employer = rm.Employer;
                    _patient.EmployerTelephone = rm.EmployerTelephone;
                    _patient.Occupation = rm.Occupation;
                    _patient.NationalId = rm.NationalId;
                    _patient.Status = rm.Status;
                    _patient.PatientAllergy = rm.PatientAllergy;
                    _patient.MedicalAidName = rm.MedicalAidName;
                    _patient.MedicalAidNo = rm.MedicalAidNo;

                    if (rm.File != null && rm.File.ContentLength > 0)
                    {
                        _patient.FileName = System.IO.Path.GetFileName(rm.File.FileName);
                        _patient.FileType = GlenwoodMed.Model.ViewModels.FileType.Avatar;
                        _patient.ContentType = rm.File.ContentType;

                        using (var reader = new System.IO.BinaryReader(rm.File.InputStream))
                        {
                            _patient.File = reader.ReadBytes(rm.File.ContentLength);
                        }
                    }

                    foreach (var item in rm.PatientAddresses.ToList())
                    {
                        PatientAddress padd = new PatientAddress();
                        padd.Address = item.Address;
                        _patient.PatientAddresses.Add(padd);
                    }
                    parepo.Update(_patient);
                }

                return rm;
            }
        }
        #endregion

        #region GETdeleteMethod...
        public PatientModel GETdeleteMethod(int id)
        {
            PatientModel rm = new PatientModel();

            using (var parepo = new PatientRepository())
            {
                if (id != 0)
                {
                    Patient _patient = parepo.GetById(id);

                    rm.userId = _patient.PatientId;
                    rm.Email = _patient.Email;
                    rm.FullName = _patient.FullName;
                    rm.Surname = _patient.Surname;
                    rm.Age = _patient.Age;
                    rm.Title = _patient.Title;
                    rm.MaritalStatus = _patient.MaritalStatus;
                    rm.DOB = _patient.DOB;
                    rm.Sex = _patient.Sex;
                    rm.Address1 = _patient.Address1;
                    rm.Address2 = _patient.Address2;
                    rm.Address3 = _patient.Address3;
                    rm.PostalCode = _patient.PostalCode;
                    rm.Telephone = _patient.Telephone;
                    rm.Employer = _patient.Employer;
                    rm.EmployerTelephone = _patient.EmployerTelephone;
                    rm.Occupation = _patient.Occupation;
                    rm.NationalId = _patient.NationalId;
                    rm.Status = _patient.Status;
                    rm.PatientAllergy = _patient.PatientAllergy;
                    rm.MedicalAidName = _patient.MedicalAidName;
                    rm.MedicalAidNo = _patient.MedicalAidNo;
                }

                return rm;
            }
        }
        #endregion

        #region PostDeleteMethod...
        public void PostDeleteMethod(int id)
        {
            DataContext db = new DataContext();
            using (var parepo = new PatientRepository())
            {
                if (id != 0)
                {
                    Patient _patient = parepo.GetById(id);
                    var PatientAddresses = db.PatientAddresses.Where(i => i.PatientId == _patient.PatientId);
                    DeleteChilds(PatientAddresses);

                    parepo.Delete(_patient);
                }
            }
        }
        #endregion

        private void DeleteChilds(IEnumerable<PatientAddress> PatientAddresses)
        {
            DataContext db = new DataContext();
            foreach (var item in PatientAddresses)
            {
                db.PatientAddresses.Remove(item);
            }
        }

        #region Count Patients...
        public int CountMethod()
        {
            int count = 0;
            var allpatients = da.GetAll();

            foreach (GlenwoodMed.Data.Tables.Patient pa in allpatients)
            {
                count++;
            }

            return count;
        }
        #endregion

        #region GetPatients...
        public List<Patient> GetPatients()
        {
            return da.GetAll();
        }
        #endregion

        #region GetPatient...
        public Patient GetPatient(int PatientId)
        {
            PatientRepository pr = new PatientRepository();
            return pr.GetById(PatientId);
        }
        #endregion

        public MultiSelectList PopulatePatientNames()
        {
            IEnumerable<SelectListItem> userlist =
                (from m in da.GetAll() where m.PatientId != 0 select m).AsEnumerable()
                    .Select(m => new SelectListItem() { Text = m.FullName + " " + m.Surname, Value = m.PatientId.ToString() });
            return new SelectList(userlist, "Value", "Text");

            //MultiSelectList _patient;
            //_patient = new MultiSelectList(da.GetAll(), "PatientId", "FullName");
            //return _patient;
        }
    }
}
