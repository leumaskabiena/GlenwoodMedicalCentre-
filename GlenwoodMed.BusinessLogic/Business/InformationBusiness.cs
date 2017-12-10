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
    public class InformationBusiness
    {
        PatientRepository pr = new PatientRepository();
        SymptomRepository symptomrtepo = new SymptomRepository();
        CustRepository custrepo = new CustRepository();
        IllnessRepository illrepo = new IllnessRepository();
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
                    PatientId = x.PatientId,
                    resultFile = pr.GetById(x.PatientId).File,
                    FileName = pr.GetById(x.PatientId).FileName,
                    FileType = GlenwoodMed.Model.ViewModels.FileType.Avatar
                }).ToList();
            }
        }

        public List<ConsultationView> GetAllConsultations()
        {
            using (var consultrepo = new ConsultationRepository())
            {
                
                List<ConsultationView> consviewlist=new List<ConsultationView>();
                List<ConsultationView.Cust> conscustlist = new List<ConsultationView.Cust>();
                ConsultationView.Illness consillness = new ConsultationView.Illness();
                List<ConsultationView.Illness> consillnesslist = new List<ConsultationView.Illness>();
                ConsultationView.procedure conprocedure = new ConsultationView.procedure();
                List<ConsultationView.procedure> conprocedurelist = new List<ConsultationView.procedure>();
                
                ConsultationView.TestType constexttype = new ConsultationView.TestType();
                var user = consultrepo.GetAll().ToList();
              
              foreach(var newitem in user)
              {
                  ConsultationView consview = new ConsultationView();
                  consview.symptomses = new List<SymptomsModel>();
                  consview.Illnesses = new List<ConsultationView.Illness>();
                  consview.Custs = new List<ConsultationView.Cust>();
                    consview.ConsultId = newitem.ConsultId;
                    //illness = x.illness,
                    consview.PatientId = newitem.PatientId;
                    consview.Symptoms = newitem.Symptoms;
                    consview.Description = newitem.Description;
                    //PatientSname = x.PatientSname,
                    consview.ConsultDate = newitem.ConsultDate;
                    //PatientFname = x.PatientFname,
                    consview.PresribedMed = newitem.PresribedMed;
                    consview.ConsultTime = newitem.ConsultTime;
                    consview.TotalPrice = newitem.TotalPrice;
                    consview.Notes = newitem.Notes;
                    consview.patientfullname = newitem.patientfullname;
                    consview.resultFile = pr.GetById(newitem.PatientId).File;
                    consview.FileName = pr.GetById(newitem.PatientId).FileName;
                    consview.FileType = pr.GetById(newitem.PatientId).FileType;
                  foreach(var cust in newitem.CustLis)
                  {
                      ConsultationView.Cust conscust = new ConsultationView.Cust();
                      var custtoadd = custrepo.Getall().Find(x => x.custId == cust.custId);
                      conscust.DrugId = custtoadd.DrugId;
                      conscust.Dosage = custtoadd.Dosage;
                      conscust.custId = custtoadd.custId;
                      conscust.Quantity = custtoadd.Quantity;
                      consview.Custs.Add(conscust);
                  }
                  foreach(var symptom in newitem.Symptomses )
                  {
                      SymptomsModel Symptomsmodel = new SymptomsModel();
                      var symotomstoadd = symptomrtepo.GetById(symptom.Symptomsid);
                      Symptomsmodel.symptomsname = symotomstoadd.symptomsname;
                      Symptomsmodel.Symptomsid = symotomstoadd.Symptomsid;
                      consview.symptomses.Add(Symptomsmodel);
                  }
                  newitem.Illness = new List<Illness>();
                  foreach (var ill in newitem.Illness)
                  {
                      ConsultationView.Illness conill = new ConsultationView.Illness();
                      var symotomstoadd = illrepo.GetById(ill.Illnessid);
                      conill.Illnessname = symotomstoadd.Illnessname;
                      conill.Illnessid = symotomstoadd.Illnessid;
                      consview.Illnesses.Add(conill);
                  }
                  consviewlist.Add(consview);
              }
          
              return consviewlist;
            
            }
        }

        public int CountCertificates()
        {
            int count = 0;

            var medrepo = new MedicalCertificateRepository();
            
            foreach(var c in medrepo.GetallCertificate())
            {
                count++;
            }

            return count;
        }

        public int CountConsultations()
        {
            int count = 0;

            var crepo = new ConsultationRepository();

            foreach (var c in crepo.GetAll())
            {
                count++;
            }

            return count;
        }


    }
}
