using GlenwoodMed.BusinessLogic.IBusiness;
using GlenwoodMed.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlenwoodMed.Service.RepositoryClass;
using GlenwoodMed.Model.ViewModels;

namespace GlenwoodMed.BusinessLogic.Business
{
    public class MedCertificateBusiness: IMedCertificateBusiness
    {
        PatientBusiness ee = new PatientBusiness();
        public List<MedicalCertificateModel> GetallMedCert(int PatientId)
        {
            PatientRepository pr = new PatientRepository();
            using (var medrepo = new MedicalCertificateRepository())
            {
                return medrepo.GetallCertificate().FindAll(med => med.PatientId == PatientId).Select(x => new MedicalCertificateModel()
                {
                    MedcertificateId = x.MedcertificateId,
                    Date = x.Date,
                    PatintName = x.PatintName.ToUpper(),
                    OpinonIllness = x.OpinonIllness,
                    Fitnessproblem = x.Fitnessproblem,
                    StartingDate = x.StartingDate,
                    Enddate = x.Enddate,
                    Comment = x.Comment,
                    Doctorname = x.Doctorname,
                    Address = x.Address,
                    PatientId = x.PatientId,
                    resultFile = pr.GetById(x.PatientId).File,
                    FileName = pr.GetById(x.PatientId).FileName,
                    FileType = GlenwoodMed.Model.ViewModels.FileType.Avatar,
                    datecreated = x.datecreated
                }).ToList();
                
            }
        }
        public void create(MedicalCertificateModel med, int PatientId)//ss, int PatientId)
        {
            PatientRepository pp = new PatientRepository();

            var Pname = pp.GetAll().ToList().Find(x => x.PatientId == PatientId);
            using (var medrep = new MedicalCertificateRepository())
            {
                //var Pname = pp.GetAll().ToList().Find(x => x.PatientId == PatientId);
                MedicalCertificate ee = new MedicalCertificate
                {
                    MedcertificateId = med.MedcertificateId,
                    Date = med.Date,
                    PatintName = Pname.FullName+" "+Pname.Surname,
                    OpinonIllness = med.OpinonIllness,
                    Fitnessproblem = med.Fitnessproblem,
                    StartingDate = med.StartingDate,
                    Enddate = med.Enddate,
                    Comment = med.Comment,
                    Doctorname = med.Doctorname,
                    Address = med.Address,
                    PatientId=med.PatientId,
                    datecreated = DateTime.Now.Date
                };
                medrep.Create(ee);
            }
        }
        public MedicalCertificateModel GetbyId(int? PatientId)
        {
            MedicalCertificateModel ee = new MedicalCertificateModel();
            using (var medrep = new MedicalCertificateRepository())
            {
                MedicalCertificate med = medrep.GetById(PatientId.Value);
                ee.MedcertificateId = med.MedcertificateId;
                return ee;
            }
        }

        public List<MedicalCertificateModel> GetAllCertificates()
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
                    Doctorname = x.Doctorname,
                    Address = x.Address,
                    PatientId = x.PatientId,
                    datecreated = x.datecreated
                }).ToList();
            }
        }
    }
}
