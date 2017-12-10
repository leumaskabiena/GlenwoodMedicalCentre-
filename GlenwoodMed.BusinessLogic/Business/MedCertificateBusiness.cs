using GlenwoodMed.BusinessLogic.IBusiness;
using GlenwoodMed.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlenwoodMed.Service.RepositoryClass;
using GlenwoodMed.Model.ViewModels;
using System.Security.Principal;
using GlenwoodMed.Data;

namespace GlenwoodMed.BusinessLogic.Business
{
    public class MedCertificateBusiness : IMedCertificateBusiness
    {
        //PatientBusiness ee = new PatientBusiness();
        MedicalCertificateModel ee = new MedicalCertificateModel();
        public List<MedicalCertificateModel> GetallMedCert()
        {
            using (var medrepo = new MedicalCertificateRepository())
            {
                return medrepo.GetallCertificate().Select(x => new MedicalCertificateModel()
                {
                    MedcertificateId = x.MedcertificateId,
                    Date = x.Date,
                    PatintName = x.PatintName.ToUpper(),
                    OpinonIllness = x.OpinonIllness,
                    Fitnessproblem = x.Fitnessproblem,
                    StartingDate = x.StartingDate,
                    Enddate = x.Enddate,
                    Comment = x.Comment,
                    //Doctorname = x.Doctorname,
                   // Address = x.Address,
                    PatientId = x.PatientId

                }).ToList();
            }
        }
        //public IPrincipal User { get; }
        public void create(MedicalCertificateModel med, int PatientId)//ss, int PatientId)
        {
            PatientRepository pp = new PatientRepository();
            /* RegisterRepository reg = new RegisterRepository();
           string user= User.Identity.Name;
           ApplicationUser getst = reg.GetAll().ToList().Find(x => x.UserName == user);
           string stuffname = getst.FullName + " " + getst.Surname;*/

            DateTime da = new DateTime();
            string date = da.Day +"-"+ da.Month +"-"+ da.Year;
            var dat = DateTime.Now.Day + "-"+DateTime.Now.Month+"-"+ DateTime.Now.Year;
            
            var Pname = pp.GetAll().ToList().Find(x => x.PatientId == PatientId);
            using (var medrep = new MedicalCertificateRepository())
            {
                //var Pname = pp.GetAll().ToList().Find(x => x.PatientId == PatientId);
                MedicalCertificate ee = new MedicalCertificate
                {
                    MedcertificateId = med.MedcertificateId,
                    Date = DateTime.Now.Date,
                    PatintName = Pname.FullName + " " + Pname.Surname,
                    OpinonIllness = med.OpinonIllness,
                    Fitnessproblem = med.Fitnessproblem,
                    StartingDate = med.StartingDate,
                    Enddate = med.Enddate,
                    Comment = med.Comment,
                    //Doctorname =  med.Doctorname
                    // Address = med.Address,
                    PatientId = PatientId
                };
                medrep.Create(ee);
            }
        }
        public MedicalCertificateModel GetbyId(int? id)
        {
            //MedicalCertificateModel ee = new MedicalCertificateModel();
            using (var medrep = new MedicalCertificateRepository())
            {
                MedicalCertificate med = medrep.GetById(id.Value);
                ee.MedcertificateId = med.MedcertificateId;
                return ee;
            }
        }
        public MedicalCertificateModel GetEdit(int? id)
        {
            MedicalCertificateModel ee = new MedicalCertificateModel();

            using (var medcert = new MedicalCertificateRepository())
            {
                if (id.HasValue)
                {
                    MedicalCertificate med = medcert.GetById(id.Value);
                    ee.MedcertificateId = med.MedcertificateId;
                    ee.Date = med.Date;
                    ee.PatintName = med.PatintName;
                    ee.OpinonIllness = med.OpinonIllness;
                    ee.Fitnessproblem = med.Fitnessproblem;
                    ee.StartingDate = med.StartingDate;
                    ee.Enddate = med.Enddate;
                    ee.Comment = med.Comment;
                    //ee.Doctorname = med.Doctorname;
                    //ee.Address = med.Address;
                    ee.PatientId = med.PatientId;

                }
                return ee;
            }
        }
        public MedicalCertificateModel PostEdit(MedicalCertificateModel id)
        {
            using (var medrep = new MedicalCertificateRepository())
            {
                if (id.MedcertificateId == 0)
                {
                    MedicalCertificate md = new MedicalCertificate
                    {
                        MedcertificateId = id.MedcertificateId,
                        Date = id.Date,
                        PatintName = id.PatintName,
                        OpinonIllness = id.OpinonIllness,
                        Fitnessproblem = id.Fitnessproblem,
                        StartingDate = id.StartingDate,
                        Enddate = id.Enddate,
                        Comment = id.Comment,
                        //Doctorname = id.Doctorname,
                       // Address = id.Address,
                        PatientId = id.PatientId
                    };
                    medrep.Create(md);
                }
                else
                {
                    MedicalCertificate med = medrep.GetById(id.MedcertificateId);
                    med.MedcertificateId = id.MedcertificateId;
                    med.Date = id.Date;
                    med.PatintName = id.PatintName;
                    med.OpinonIllness = id.OpinonIllness;
                    med.Fitnessproblem = id.Fitnessproblem;
                    med.StartingDate = id.StartingDate;
                    med.Enddate = id.Enddate;
                    med.Comment = id.Comment;
                    //med.Doctorname = id.Doctorname;
                   // med.Address = id.Address;
                    med.PatientId = id.PatientId;
                    medrep.Upadte(med);
                }
                return id;
            }
        }
        public MedicalCertificateModel GetDelete(int? id, MedicalCertificateModel medi)
        {
            using (var medrep = new MedicalCertificateRepository())
            {
                if(id!=0)
                {
                    MedicalCertificate med = medrep.GetById(id.Value);
                    medi.MedcertificateId = med.MedcertificateId;
                    medi.Date = med.Date;
                    medi.PatintName = med.PatintName;
                    medi.OpinonIllness = med.OpinonIllness;
                    medi.Fitnessproblem = med.Fitnessproblem;
                    medi.StartingDate = med.StartingDate;
                    medi.Enddate = med.Enddate;
                    medi.Comment = med.Comment;
                    //medi.Doctorname = med.Doctorname;
                    //ee.Address = med.Address;
                    medi.PatientId = med.PatientId;
                }
                return medi;
            }

        }

      

        public void PostDelete(int del)
        {
            using (var medrep = new MedicalCertificateRepository())
            {
                if(del!=0)
                {
                    MedicalCertificate md = medrep.GetById(del);
                    medrep.delete(md);
                }
            }
        }

        #region GetDependentId...
        public MedicalCertificate GetMedId(int id)
        {
            var medrep = new MedicalCertificateRepository();
            return medrep.GetById(id);
        }
        #endregion
    }
}
