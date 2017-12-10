using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web;
using System.Web.UI;
using GlenwoodMed.BusinessLogic.IBusiness;
using GlenwoodMed.Data;
using GlenwoodMed.Data.Tables;
using GlenwoodMed.Model.ViewModels;
using GlenwoodMed.Service.IRepository;
using GlenwoodMed.Service.RepositoryClass;
using MoreLinq;

namespace GlenwoodMed.BusinessLogic.Business
{
    public class ConsultationBusiness : IConsultationBusiness
    {
        DataContext da = new DataContext();
        PatientBusiness pb = new PatientBusiness();
        CustRepository custrep = new CustRepository();
        ConsultationRepository consultrep = new ConsultationRepository();
        IllnessRepository Illnessrep = new IllnessRepository();
        TestTypeRepository testresult = new TestTypeRepository();
        SymptomRepository Symptomresult = new SymptomRepository();
        private ProcedureItemRepository procedureItemRepo = new ProcedureItemRepository();
        ProcedureRepository procedureRepo = new ProcedureRepository();
        #region GetAllConsultations

        public List<ConsultationView> GetAllConsultations(int Id)
        {
            using (var consultrepo = new ConsultationRepository())
            {
                var name = da.Patients.ToList().Find(x => x.PatientId == Id);
                var user = consultrepo.GetAll().FindAll(x => x.PatientId == Id).ToList();
                return user.Select(x => new ConsultationView()
                {
                    ConsultId = x.ConsultId,
                    //illness = x.illness,
                    PatientId = x.PatientId,
                    Symptoms = x.Symptoms,
                    Description = x.Description,

                    //PatientSname = x.PatientSname,
                    ConsultDate = x.ConsultDate,
                    //PatientFname = x.PatientFname,
                    PresribedMed = x.PresribedMed,
                    ConsultTime = x.ConsultTime,
                    TotalPrice = x.TotalPrice,


                }).ToList();
            }
        }

        #endregion

        #region GetAllConsultationswithoutId

        public List<ConsultationView> GetAllCons()
        {
            using (var consultrepo = new ConsultationRepository())
            {
                var user = consultrepo.GetAll().ToList();
                return user.Select(x => new ConsultationView()
                {
                    ConsultId = x.ConsultId,
                    //illness = x.illness,
                    PatientId = x.PatientId,
                    Symptoms = x.Symptoms,
                    Description = x.Description,
                    //PatientSname = x.PatientSname,
                    ConsultDate = x.ConsultDate,
                    //PatientFname = x.PatientFname,
                    PresribedMed = x.PresribedMed,
                    ConsultTime = x.ConsultTime,
                    ProcedurePrice = x.ProcedurePricee,
                    TestTypePrice = x.TestTypePrice
                }).ToList();
            }
        }

        #endregion

        #region GetConsultationId

        public ConsultationView GetDrugs(string id)
        {
            ConsultationView cv = new ConsultationView();

            using (var deprepo = new ConsultationRepository())
            {
                Consultation _Consult = deprepo.GetById(id);
             

                cv.ConsultId = _Consult.ConsultId;
                cv.collected = _Consult.collected;
                cv.ConsultTime = _Consult.ConsultTime;
                cv.Description = _Consult.Description;
                //cv.illness = _Consult.illness;
                cv.Symptoms = _Consult.Symptoms;
                cv.TotalPrice = _Consult.TotalPrice;
                cv.patientfullname = _Consult.patientfullname;
                cv.ConsultDate = _Consult.ConsultDate;
                cv.PatientId = _Consult.PatientId;
                cv.Custs = new List<ConsultationView.Cust>();
                foreach (var VARIABLE in _Consult.CustLis)
                {
                    ConsultationView.Cust obCust = new ConsultationView.Cust();
                    obCust.custId = VARIABLE.custId;
                    obCust.Dosage = VARIABLE.Dosage;
                    obCust.DrugId = VARIABLE.DrugId;
                    obCust.Quantity = VARIABLE.Quantity;
                    cv.Custs.Add(obCust);
                }

                return cv;
            }
        }
        public DispenseDrug GetDispenseDrugs(string id)
        {
            DispenseDrug cv = new DispenseDrug();

            using (var deprepo = new ConsultationRepository())
            {
                Consultation _Consult = deprepo.GetById(id);


                cv.ConsultId = _Consult.ConsultId;
                cv.collected = _Consult.collected;
                cv.ConsultTime = _Consult.ConsultTime;
                cv.Description = _Consult.Description;
                //cv.illness = _Consult.illness;
                cv.Symptoms = _Consult.Symptoms;
                cv.TotalPrice = _Consult.TotalPrice;
                cv.patientfullname = _Consult.patientfullname;
                cv.ConsultDate = _Consult.ConsultDate;
                cv.PatientId = _Consult.PatientId;
                cv.DispenseCusts = new List<DispenseDrug.DispenseCust>();
                foreach (var VARIABLE in _Consult.CustLis)
                {
                    DispenseDrug.DispenseCust obCust = new DispenseDrug.DispenseCust();
                    obCust.custId = VARIABLE.custId;
                    obCust.Dosage = VARIABLE.Dosage;
                    obCust.DrugId = VARIABLE.DrugId;
                    obCust.Quantity = VARIABLE.Quantity;
                    cv.DispenseCusts.Add(obCust);
                }

                return cv;
            }
        }
        #endregion

        #region Details Method...

        public ConsultationView DetailsMethod(string id)
        {
            ConsultationView cv = new ConsultationView();

            using (var deprepo = new ConsultationRepository())
            {
                if (id != null)
                {
                    Consultation _consult = deprepo.GetById(id);

                    cv.ConsultId = _consult.ConsultId;
                    //cv.illness = _consult.illness;
                    cv.Symptoms = _consult.Symptoms;
                    cv.PatientId = _consult.PatientId;
                    cv.Description = _consult.Description;
                    //cv.PatientSname = _consult.PatientSname;
                    cv.ConsultDate = _consult.ConsultDate;
                    // cv.PatientFname = _consult.PatientFname;
                    cv.PresribedMed = _consult.PresribedMed;
                    cv.ConsultTime = _consult.ConsultTime;
                    cv.TotalPrice = _consult.TotalPrice;

                }

                return cv;
            }
        }

        #endregion
        #region CreateMethod...
        public ConsultationView CreateMethod(ConsultationView cv, int id)
        {
            var pro = new PatientRepository();
            var name = pb.GetAllPatients().Find(x => x.userId == id);

            cv.PatientId = id;
            cv.patientfullname = name.FullName + " " + name.Surname;
            cv.Description = name.PatientAllergy;
            cv.FileName = pro.GetById(id).FileName;
            cv.FileType = pro.GetById(id).FileType;
            cv.resultFile = pro.GetById(id).File;

            return cv;
        }
        #endregion


        #region populate Data in Create View for Consultation

        //populate for Symptoms
        public MultiSelectList populatelistsymptoms()
        {
            MultiSelectList symptoms;
            symptoms = new MultiSelectList(Symptomresult.GetAll(), "Symptomsid", "symptomsname");
            return symptoms;
        }
        public MultiSelectList populatelistIllness(/*object[] itemObjects*/)
        {
            MultiSelectList Illness;
            Illness = new MultiSelectList(Illnessrep.GetAll(), "Illnessid", "Illnessname"/*, itemObjects*/);
            return Illness;
        }
        public MultiSelectList populateProcedure()
        {
            MultiSelectList Procedure;
            Procedure = new MultiSelectList(procedureRepo.GetAll(), "procedureId", "procedureName");
            return Procedure;
        }
        public MultiSelectList populateProcedureItem()
        {
            MultiSelectList ProcedureItem;
            ProcedureItem = new MultiSelectList(procedureItemRepo.GetAll(), "ProcedureitemID", "name");
            return ProcedureItem;
        }
        //Populate for drugs
        public MultiSelectList populatelistdrugs()
        {
            MultiSelectList drugs;
            drugs = new MultiSelectList(da.Drugs.ToList(), "DrugId", "DrugName");
            return drugs;
        }

        public MultiSelectList populatetest()
        {

            MultiSelectList drugs;
            drugs = new MultiSelectList(testresult.GetAll(), "TestTypeID", "Name");
            return drugs;
        }
        public void AddSymptoms(string name)
        {
            SymptomRepository symrepo = new SymptomRepository();
            Symptoms newsym = new Symptoms();
            newsym.symptomsname = name;
            var find = da.Symptomses.ToList();
            if (!find.Exists(x => x.symptomsname == name))
            {
                symrepo.Insert(newsym);
            }
            else
            {

            }
        }
        public void AddIllness(string name)
        {
            IllnessRepository symrepo = new IllnessRepository();
            Illness newilln = new Illness();
            newilln.Illnessname = name;
            var find = da.Symptomses.ToList();
            if (!find.Exists(x => x.symptomsname == name))
            {
                symrepo.Insert(newilln);
            }
            else
            {

            }
        }
        #endregion



        public void updatePrice(string ConsultID, decimal amountpaid)
        {
            var items = consultrep.GetAll().Find(x => x.ConsultId == ConsultID);

            items.Amountpaid = items.Amountpaid + amountpaid;
            consultrep.Update(items);
        }



        #region CreateMethod...

        #region GETeditMethod...

        public ConsultationView GETeditMethod(string id)
        {
            ConsultationView cv = new ConsultationView();

            using (var deprepo = new ConsultationRepository())
            {
                if (id != null)
                {
                    Consultation _consultation = deprepo.GetById(id);

                    cv.ConsultId = _consultation.ConsultId;
                    //cv.illness = _consultation.illness;
                    cv.Symptoms = _consultation.Symptoms;
                    //cv.PatientSname = _consultation.PatientSname;
                    cv.ConsultDate = _consultation.ConsultDate;
                    //cv.PatientFname = _consultation.PatientFname;
                    cv.PresribedMed = _consultation.PresribedMed;
                    cv.ConsultTime = _consultation.ConsultTime;
                    cv.TotalPrice = _consultation.TotalPrice;
                    cv.Description = _consultation.Description;
                }

                return cv;
            }
        }

        #endregion

        #region PostEditMethod...

        public ConsultationView PostEditMethod(ConsultationView cv)
        {
            using (var deprepo = new ConsultationRepository())
            {
                if (cv.ConsultId == null)
                {
                    Consultation _consultation = new Consultation
                    {
                        ConsultId = cv.ConsultId,
                        //illness = cv.illness,
                        Symptoms = cv.Symptoms,
                        //PatientSname = cv.PatientSname,
                        ConsultDate = cv.ConsultDate,
                        //PatientFname = cv.PatientFname,
                        PresribedMed = cv.PresribedMed,
                        ConsultTime = cv.ConsultTime,
                        TotalPrice = cv.TotalPrice,
                        Description = cv.ConsultTime,

                    };

                    deprepo.Insert(_consultation);
                }

                else
                {
                    Consultation _consultation = deprepo.GetById(cv.ConsultId);

                    _consultation.ConsultId = cv.ConsultId;
                    //_consultation.illness = cv.illness;
                    _consultation.Symptoms = cv.Symptoms;
                    _consultation.Symptoms = cv.Symptoms;
                    //_consultation.PatientSname = cv.PatientSname;
                    _consultation.ConsultDate = cv.ConsultDate;
                    // _consultation.PatientFname = cv.PatientFname;
                    _consultation.PresribedMed = cv.PresribedMed;
                    _consultation.ConsultTime = cv.ConsultTime;
                    _consultation.TotalPrice = cv.TotalPrice;
                    _consultation.ConsultTime = cv.ConsultTime;
                    deprepo.Update(_consultation);
                }

                return cv;
            }
        }

        #endregion

        #region GETdeleteMethod...

        public ConsultationView GETdeleteMethod(string id)
        {
            ConsultationView cv = new ConsultationView();

            using (var deprepo = new ConsultationRepository())
            {
                if (id != null)
                {
                    Consultation _consultation = deprepo.GetById(id);

                    cv.ConsultId = _consultation.ConsultId;
                    //cv.illness = _consultation.illness;
                    cv.Symptoms = _consultation.Symptoms;
                    cv.Symptoms = _consultation.Symptoms;
                    //cv.PatientSname = _consultation.PatientSname;
                    cv.ConsultDate = _consultation.ConsultDate;
                    //cv.PatientFname = _consultation.PatientFname;
                    cv.PresribedMed = _consultation.PresribedMed;
                    cv.ConsultTime = _consultation.ConsultTime;
                    cv.TotalPrice = _consultation.TotalPrice;
                }

                return cv;
            }
        }

        #endregion

        #region PostDeleteMethod...

        public void PostDeleteMethod(string id)
        {
            using (var deprepo = new ConsultationRepository())
            {
                if (id != null)
                {
                    Consultation _dependent = deprepo.GetById(id);
                    deprepo.Delete(_dependent);
                }
            }
        }

        #endregion

        #region AddConsultation...
        public void AddConsultation(ConsultationView cv, int id, int[] Symptoms, string[] PresribedMed, int[] Testtype,int[] illness,int[] procedures)
        {
            //Objects

            var ob = new List<Cust>();
            var cust = new Cust();
            ConsultationPriceBusiness cons = new ConsultationPriceBusiness();

            bool collected = false;

            using (var deprepo = new ConsultationRepository())
            {
              var newdb=  deprepo.DbContext();
                if (cv.ConsultId == null)
                {

                    cv.PatientId = id;


                    //Set the date and time for consultation
                    var curr = DateTime.Now;
                    string date = curr.ToString("D");
                    string time = curr.ToString("hh:m:s: tt");
                    cv.ConsultDate = curr.Date;
                    cv.ConsultTime = time;

                    //find the patient you're creating consultation for
                    var patient = da.Patients.ToList().Find(x => x.PatientId == id);



                    Guid consul = Guid.NewGuid();
                    string consultid = consul.ToString("N");
                    cv.ConsultId = consultid;

                    cv.patientfullname = patient.FullName + " " + patient.Surname;
                    cv.TotalPrice = 400;

                    Consultation consultation = new Consultation()
                    {
                        ConsultId = cv.ConsultId,
                        collected = cv.collected,
                        ConsultTime = cv.ConsultTime,
                        Description = cv.Description,
                        //illness = cv.illness,
                        Symptoms = cv.Symptoms,
                        TotalPrice = cv.TotalPrice,
                        patientfullname = cv.patientfullname,
                        ConsultDate = cv.ConsultDate,
                        PatientId = cv.PatientId,
                        Notes = cv.Notes
                    };

                    consultation.TestTypes = new List<TestType>();
                 
                    var custlistitem = cv.Custs.ToList().Count;
                    var procedurelistitem = cv.procedures.ToList().Count;

                    
                    consultation.CustLis = new List<Cust>();
                    if (custlistitem != 0)
                    {
                        foreach (var iteem in cv.Custs)
                        {
                            if ((iteem.DrugId != null) && (iteem.Dosage != null) && (iteem.Quantity != 0))
                            {
                                var obs = new Cust();

                                Guid m = Guid.NewGuid();
                                string custi = m.ToString("N");
                                obs.custId = custi;
                                obs.DrugId = iteem.DrugId;
                                obs.Quantity = iteem.Quantity;
                                obs.Dosage = iteem.Dosage;
                                ob.Add(obs);
                                consultation.CustLis.Add(obs);
                                
                            }
                            
                            //da.Custs.Add(obs);
                            //custrep.Create(obs);S

                        }
                        //foreach (var item in ob)
                        //{
                        //    var find = newdb.Drugs.ToList().Find(x => Convert.ToString(x.DrugId) == item.DrugId);
                        //    find.DrugQuantity -= item.Quantity;
                        //    consultation.TotalPrice += find.DrugPrice;                 
                        //}
                    }
                    if (Testtype != null)
                    {
                        var testResults = new List<TestType>();


                        var TestTyp = new TestType();
                        foreach (var item in Testtype)
                        {

                            var symptomstoadd = newdb.TestTypes.Find(item);
                            //TestTyp.Name = symptomstoadd.Name;
                            //TestTyp.Price = symptomstoadd.Price;
                            //TestTyp.Description = symptomstoadd.Description;
                            testResults.Add(symptomstoadd);
                            ////TestTyp.Consultations.Add(consultation);
                            newdb.TestTypes.Attach(symptomstoadd);
                            consultation.TestTypes.Add(symptomstoadd);
                        }
                         foreach (var item in testResults)
                         {
                             consultation.TotalPrice += item.Price;
                             consultation.TestTypePrice += item.Price;
                         }
                    }
                    if (illness != null)
                    {
                        var Illn = new Illness();
                        consultation.Illness = new List<Illness>();
                        foreach (var item in illness)
                        {

                            var symptomstoadd = newdb.Illness.Find(item);
                            //Illn.Illnessid = symptomstoadd.Illnessid;
                            //Illn.Illnessname = symptomstoadd.Illnessname;
                            newdb.Illness.Attach(symptomstoadd);
                            consultation.Illness.Add(symptomstoadd);
                        }
                    }
                    if (Symptoms != null)
                    {
                        var sympto = new Symptoms();
                        consultation.Symptomses = new List<Symptoms>();
                        foreach (var item in Symptoms)
                        {

                            var symptomstoadd = newdb.Symptomses.Find(item);
                            //sympto.symptomsname = symptomstoadd.symptomsname;
                            //consultation.Symptomses = new List<Symptoms> { symptomstoadd };
                            newdb.Symptomses.Attach(symptomstoadd);
                            consultation.Symptomses.Add(symptomstoadd);
                        }
                    }
                    if (procedurelistitem != 0)
                    {
                        consultation.Procedures = new List<Procedure>();
                        foreach (var item in cv.procedures)
                        {
                            if (item.procedurename != null && item.procedureQuantity != 0)
                            {
                                var symptomstoadd = newdb.Procedures.ToList().Find(x => x.procedureName == item.procedurename);
                                //sympto.symptomsname = symptomstoadd.symptomsname;
                                //consultation.Symptomses = new List<Symptoms> { symptomstoadd };
                                newdb.Procedures.Attach(symptomstoadd);
                                consultation.Procedures.Add(symptomstoadd);
                                consultation.TotalPrice += symptomstoadd.procedurePrice * item.procedureQuantity;
                                consultation.ProcedurePricee += symptomstoadd.procedurePrice * item.procedureQuantity;
                            }
                        }
                    }
                    consultation.TotalPrice += consultation.TotalPrice * Convert.ToDecimal(0.14);
                    newdb.Consultations.Add(consultation);
                    newdb.SaveChanges();
                    //dab.SaveChanges();
                    //consultrep.Insert(consultation);
                    //var delete = testresult.GetById(TestTyp.TestTypeID);
                    //testresult.Delete(delete);

                    //var repo=deprepo.GetById(consultid);



                    //da.SaveChangesAsync();
                    //deprepo.Update(repo);


                    //cv.ConsultDate = date;
                    //if (Symptoms != null)
                    //{
                    //    cv.Symptomses = new List<Symptoms>();
                    //    foreach (var item in Symptoms)
                    //    {
                    //        var symptomstoadd = da.Symptomses.Find(int.Parse(item));
                    //        cv.Symptomses.Add(symptomstoadd);
                    //    }

                    //}


                    //foreach (var VARIABLE in cv.CustModell.CustList)
                    //{
                    //    VARIABLE.Quantity;
                    //    VARIABLE.DrugName;
                    //}


                    //if (PresribedMed != null)
                    //{
                    //    var m = _collection.CustList;
                    //    cv.Drugs = new List<Drug>();
                    //    foreach (var item in cv.)
                    //    {

                    //        var drugstoadd = da.Custs.Find(int.Parse(item));
                    //        m.Add(new Cust({DrugName = item.D} ));
                    //        _collection.CustList.Add(cv.custList);
                    //        cv.Drugs.Add(drugstoadd);


                    //    }
                    //}
                    //da.CollectionDrugs.Add(_collection);
                    //deprepo.Insert(cv);
                    // da.Consultations.Add(coc);

                    // da.SaveChanges();


                }
            }
        }
        #endregion

        #region ViewAllCollectionDrugs

        public List<CollectionView> GetPendingDrugs()
        {
            using (var clinicrepo = new CollectionRepository())
            {
                List<CollectionDrugs> notcollected = clinicrepo.Getall().FindAll(x => x.Collected == false);
                return
                    notcollected.ToList()
                        .Select(
                            x =>
                                new CollectionView()
                                {
                                    collectionID = x.collectionID,
                                    PatientName = x.PatientName,
                                    Prescription = x.Prescription,
                                    Collected = x.Collected
                                })
                        .ToList();
            }
        }
        public List<CollectionView> GetCollectedDrugs()
        {
            using (var clinicrepo = new CollectionRepository())
            {
                List<CollectionDrugs> collected = clinicrepo.Getall().FindAll(x => x.Collected == true);
                return
                    collected.ToList()
                        .Select(
                            x =>
                                new CollectionView()
                                {
                                    collectionID = x.collectionID,
                                    PatientName = x.PatientName,
                                    Prescription = x.Prescription,
                                    Collected = x.Collected,
                                    PaymentType = x.PaymentType
                                })
                        .ToList();
            }
        }
        public List<CollectionView> AllConsultationDrugs()
        {
            using (var clinicrepo = new CollectionRepository())
            {
                return
                    clinicrepo.Getall().ToList()
                        .Select(
                            x =>
                                new CollectionView()
                                {
                                    collectionID = x.collectionID,
                                    PatientName = x.PatientName,
                                    Prescription = x.Prescription,
                                    Collected = x.Collected,
                                    PaymentType = x.PaymentType

                                })
                        .ToList();
            }
        }
        #endregion

        public void UpdateCollectionDrug(int id)
        {
            using (var clinicrepo = new CollectionRepository())
            {
                CollectionDrugs find = clinicrepo.FindbyId(id);
                find.Collected = true;

                clinicrepo.Update(find);
            }
        }

        #region Details Method...

        public CollectionView GetDetailsMethod(int? id)
        {
            CollectionView cv = new CollectionView();

            using (var deprepo = new CollectionRepository())
            {
                if (id.HasValue && id != 0)
                {
                    CollectionDrugs _consult = deprepo.FindbyId(id.Value);

                    cv.collectionID = _consult.collectionID;
                    cv.PatientName = _consult.PatientName;
                    cv.Prescription = _consult.Prescription;
                    cv.Collected = _consult.Collected;
                }

                return cv;
            }
        }

        #endregion

        #region GetConsultations...
        public List<Consultation> GetConsultations()
        {
            return consultrep.GetAll();
        }
        #endregion

        #region Get Drugs
        public List<Drug> GetDrugs()
        {
            return da.Drugs.ToList();
        }
        #endregion

        public SelectList GetUser()
        {
            ConsultationView con = new ConsultationView();
            IEnumerable<SelectListItem> userlist =
                (from m in pb.GetPatients() where m.PatientId != 0 select m).AsEnumerable()
                    .Select(m => new SelectListItem() { Text = m.FullName + " " + m.Surname, Value = m.PatientId.ToString() });
            return new SelectList(userlist, "Value", "Text");//,con.UserId);
        }

        public List<ConsultationView> Last2Consultations(int? Patientid)
        {
            
            List<ConsultationView> cv = new List<ConsultationView>();

            var listss = consultrep.GetAll().FindAll(x => x.PatientId == Patientid).TakeLast(3).Reverse().ToList();
           
            foreach (var ite in listss)
            {
                ConsultationView cvob = new ConsultationView();
                cvob.ConsultDate = ite.ConsultDate;
                cvob.ConsultId = ite.ConsultId;
                cvob.ConsultTime = ite.ConsultTime;
                cvob.Notes = ite.Notes;
                //vob.illness = ite.illness;
                cvob.PatientId = ite.PatientId;
                cvob.Custs = new List<ConsultationView.Cust>();
                cvob.Illnesses=new List<ConsultationView.Illness>();
               
                foreach (var item in ite.CustLis)
                {
                    ConsultationView.Cust obCust = new ConsultationView.Cust();
                    obCust.custId = item.custId;
                    obCust.Dosage = item.Dosage;
                    obCust.DrugId = item.DrugId;
                    obCust.Quantity = item.Quantity;
                    cvob.Custs.Add(obCust);
                }
                foreach (var illness in ite.Illness)
                {
                    ConsultationView.Illness obillness = new ConsultationView.Illness();
                    obillness.Illnessid = illness.Illnessid;
                    obillness.Illnessname = illness.Illnessname;    
                    cvob.Illnesses.Add(obillness);
                }
                cv.Add(cvob);
            }
            return cv;
        }
        public void AddConsultation(ConsultationView cv)
        {
            throw new NotImplementedException();
        }


        public ConsultationView GetConsultationId(int? id)
        {
            throw new NotImplementedException();
        }


        public ConsultationView DetailsMethod(int? id)
        {
            throw new NotImplementedException();
        }


        public ConsultationView GETeditMethod(int? id)
        {
            throw new NotImplementedException();
        }


        public ConsultationView GETdeleteMethod(int id)
        {
            throw new NotImplementedException();
        }

        public void PostDeleteMethod(int id)
        {
            throw new NotImplementedException();
        }
    }
}

        #endregion

