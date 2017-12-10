using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlenwoodMed.BusinessLogic.IBusiness;
using GlenwoodMed.Model.ViewModels;
using GlenwoodMed.Service.RepositoryClass;
using GlenwoodMed.Data.Tables;
using GlenwoodMed.Data;

namespace GlenwoodMed.BusinessLogic.Business
{//Copyright 
    public class HIVTestResultBusiness:IHIVTestResultBusiness
    {
        PatientRepository pp = new PatientRepository();
        public List<HIVTestResultModel> GetAllTest()
        {
            using(var testRepo=new HIVTestResultRepository())
            {
                return testRepo.GetAllTest().Select(x => new HIVTestResultModel()
                    {
                        TestId = x.TestId,
                        PatientName = x.PatientName,
                        Date = x.Date,
                        DOB = x.DOB,
                        Gender = x.Gender,
                        TestigLocation=x.TestigLocation,
                        NextAppointment = x.NextAppointment,
                        HIVtestType=x.HIVtestType,
                        Status=x.Status,
                        PatientId=x.PatientId
                    }).ToList();
                
            }
        }
        public HIVTestResultModel GetById(int? id)
        {
            HIVTestResultModel ee = new HIVTestResultModel();

            using (var parepo = new HIVTestResultRepository())
            {
                HIVTestResult test = parepo.GetById(id.Value);

                ee.TestId = test.TestId;

                return ee;
            }
        }
        public void Create(HIVTestResultModel test , int PatientId)
        {
            
            using (var testropo=new HIVTestResultRepository())
            {
                var Pname = pp.GetAll().ToList().Find(x => x.PatientId == PatientId);
                HIVTestResult ee = new HIVTestResult
                {
                    TestId = test.TestId,
                   PatientName = Pname.FullName+" "+Pname.Surname,
                    Date = test.Date,
                    DOB = Convert.ToDateTime(Pname.DOB),
                    Gender = Pname.Sex,
                    TestigLocation=test.TestigLocation,
                    NextAppointment = test.NextAppointment,
                    HIVtestType=test.HIVtestType,
                    Status=test.Status,
                    PatientId = PatientId,
                   

                };
                testropo.Create(ee);
            }
        }

        public HIVTestResultModel GetEdit(int? id)
        {
            HIVTestResultModel ee = new HIVTestResultModel();

            using (var testrep=new HIVTestResultRepository())
            {
                  //PatientRepository pp = new PatientRepository();
                // var Pname = pp.GetAll().ToList().Find(x => x.PatientId == id);
                if(id.HasValue&&id!=0)
                {
                    HIVTestResult test = testrep.GetById(id.Value);
                    ee.TestId=test.TestId;
                    ee.PatientName=test.PatientName;
                    ee.Date = test.Date; 
                    //ee.DOB = Convert.ToDateTime(Pname.DOB);
                   // ee.Gender = Pname.Sex;
                    ee.TestigLocation = test.TestigLocation;
                    ee.NextAppointment = test.NextAppointment;
                    ee.HIVtestType = test.HIVtestType;
                    ee.Status=test.Status;
                    ee.PatientId = test.PatientId;

                }
                return ee;
            }
        }
        public HIVTestResultModel PostEdit(HIVTestResultModel id)
        {
            using (var testrep=new HIVTestResultRepository())
            {

                if(id.TestId==0)
                {
                    HIVTestResult ee = new HIVTestResult
                    {
                        TestId = id.TestId,
                        //PatientName = id.PatientName,
                        Date = id.Date,
                       // DOB = id.DOB,
                       // Gender = id.Gender,
                        TestigLocation=id.TestigLocation,
                        NextAppointment = id.NextAppointment,
                        HIVtestType=id.HIVtestType,
                        Status=id.Status,
                        //PatientId=id.PatientId
                    };
                    testrep.Create(ee);
                }
                else
                {
                    HIVTestResult test = testrep.GetById(id.TestId);

                    test.TestId = id.TestId;

                    //test.PatientName = id.PatientName;
                    test.Date = id.Date;
                   // test.DOB = id.DOB;
                   // test.Gender = id.Gender;
                    test.TestigLocation = id.TestigLocation;
                    test.NextAppointment = id.NextAppointment;
                    test.HIVtestType = id.HIVtestType;
                    test.Status = id.Status;
                    //test.PatientId = id.PatientId;
                    testrep.update(test);
                }
                return id;
                
            }
        }
        public HIVTestResultModel GetDelete(int? id)
        {
            HIVTestResultModel ee = new HIVTestResultModel();

            using (var testrep=new HIVTestResultRepository())
            {
                if(id!=0)
                {
                    HIVTestResult test = testrep.GetById(id.Value);
                    ee.TestId = test.TestId;
                    ee.PatientName = test.PatientName;
                    ee.Date = test.Date;
                   // ee.DOB = test.DOB;
                   // ee.Gender = test.Gender;
                    ee.TestigLocation = test.TestigLocation;
                    ee.NextAppointment = test.NextAppointment;
                    ee.HIVtestType = test.HIVtestType;
                    ee.Status = test.Status;
                    ee.PatientId = test.PatientId;
                }
                return ee;
            }
        }
        public void PostDelete(int testmodel)
        {
            using(var testrep=new HIVTestResultRepository())
            {
                if(testmodel!=0)
                {
                    HIVTestResult te = testrep.GetById(testmodel);
                    testrep.Delete(te);
                }
            }
        }
        public HIVTestResultModel Details(int? id)
        {
            HIVTestResultModel ee = new HIVTestResultModel();
            using (var testrep=new HIVTestResultRepository())
            {
                 var Pname = pp.GetAll().ToList().Find(x => x.PatientId == id);
                if(id.HasValue && id!=0)
                {
                    HIVTestResult test=testrep.GetById(id.Value);
                    ee.TestId = test.TestId;
                    ee.PatientName = test.PatientName;
                    ee.Date = test.Date;
                    //ee.DOB = test.DOB;
                    //ee.Gender = test.Gender;
                    ee.TestigLocation = test.TestigLocation;
                    ee.NextAppointment = test.NextAppointment;
                    ee.HIVtestType = test.HIVtestType;
                    ee.Status = test.Status;
                    ee.PatientId = test.PatientId;
                }
                return ee;
            }
        }

        public int Count()
        {
            HIVTestResultModel ee = new HIVTestResultModel();
            DataContext db=new DataContext();

            int countpo = 0;
            var listtest = db.HIVTestResults.ToList();
            foreach (HIVTestResult oo in listtest)
            {
              
                if (oo.Status == "Positive")
                {
                    countpo++;
                }
            }
            return countpo;
           
        }
        public int CountNeg()
        {
            HIVTestResultModel ee = new HIVTestResultModel();
            DataContext db = new DataContext();

            int countpo = 0;
            var listtest = db.HIVTestResults.ToList();
            foreach (HIVTestResult oo in listtest)
            {

                if (oo.Status == "Negative")
                {
                    countpo++;
                }
            }
            return countpo;

        }
       
    }
}
