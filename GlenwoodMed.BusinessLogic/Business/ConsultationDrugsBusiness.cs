using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using GlenwoodMed.Data;
using GlenwoodMed.Data.Tables;
using GlenwoodMed.Model.ViewModels;
using GlenwoodMed.Service.RepositoryClass;

namespace GlenwoodMed.BusinessLogic.Business
{
    public class ConsultationDrugsBusiness
    {
        DataContext da = new DataContext();
        DrugRespo drugrep = new DrugRespo();

        public List<ConsultationDrugView> AllConsultationDrugs(int Id)
        {

            using (var consultrepo = new ConsultationDrugsRepository())
            {
                var consultation = consultrepo.Getall().FindAll(x => x.PrescriptionId == Id).ToList();
                return
                    (consultation
                        .Select(
                            x =>
                                new ConsultationDrugView()
                                {
                                    DrugId = x.DrugId,
                                    DrugName = x.DrugName,
                                    DrugToConsultId = x.DrugToConsultId,
                                    Price = x.Price,
                                    Quantity = x.Quantity,


                                })).ToList();
            }
        }

        public Consultation AddDrugToConsult(Consultation consut, string id)
        {
            var Consultation = da.Consultations.ToList().Find(x => x.ConsultId == id);
            var PatientName = da.Patients.ToList().Find(x => x.PatientId == Consultation.PatientId);
            Consultation.patientfullname = PatientName.FullName + " " + PatientName.Surname;
            //DosageViewModel model = new DosageViewModel();
            //DrugRespo respo = new DrugRespo();
            //foreach (var item in collection.Drugs)
            //{
            //    model.DrugName = item.DrugName;
            //    model.PaymentType = item.Price*quantity;
            //    model.Quantity = quantity;
            //    model.PatientID = collection.PatientID;
            //    model.PatientName = collection.PatientName;
            //    da.DosageViewModel.Add(model);
            //    Drug update = respo.GetById(item.DrugId);
            //    update.Quantity -= quantity;
            //    respo.Update(update);
            //    da.SaveChanges();

            //}
            //foreach (var item in Drugs)
            //{
            //    var drugstoadd = da.Drugs.Find(int.Parse(item));
            //    collection.Drugs.Add(drugstoadd);
            //}
            //da.SaveChanges();
            return Consultation;
        }
        public Consultation AddDrugToConsult(string id/*,int PrescriptionID*/)
        {
            using (var consultrepo = new ConsultationDrugsRepository())
            {
                var collection = da.Consultations.ToList().Find(x => x.ConsultId == id);
                var PatientName = da.Patients.ToList().Find(x => x.PatientId == collection.PatientId);
                collection.patientfullname = PatientName.FullName + " " + PatientName.Surname;
                //var PrescriptionId = da.CollectionDrugs.ToList().Find(x => x.collectionID == id);
                //var c = da.ConsultationDrugs.ToList().Find(x => x.PrescriptionId == PrescriptionId.collectionID);
                //var drugid = da.Drugs.ToList().Find(x => x.DrugId == cdv.DrugId);
                //if (cdv.DrugToConsultId == 0)
                //{
                //    Drug m = drugrep.GetById(cdv.DrugId);
                //    ConsultationDrug con = consultrepo.FindbyId(cdv.DrugToConsultId);
                //        ConsultationDrug consultdrug = new ConsultationDrug()
                //        {
                //            DrugId = cdv.DrugId,
                //            PrescriptionId = id,
                //            DrugName = drugid.DrugName,
                //            Price = drugid.Price*cdv.Quantity,
                //            DrugToConsultId = cdv.DrugToConsultId,
                //            Quantity = cdv.Quantity,
                //        };


                //        int quantity = m.Quantity - cdv.Quantity;
                //        m.Quantity = quantity;

                //        drugrep.Update(m);

                //        consultrepo.Create(consultdrug);

                //}
                return collection;
            }

        }
        #region Get and Delete Drug From Consultation
        public void GetDeleteDrugFromConsultation(string id)
        {
            bool collected = true;
            using (var consrepo = new ConsultationRepository())
            {
                CollectionRepository collrepo = new CollectionRepository();
               var consultdrug= consrepo.GetById(id);
                //consrepo.Delete(consultdrug);
                consultdrug.collected = collected;
                consrepo.Update(consultdrug);
                //da.CollectionDrugs.Remove(consultdrug);
                //da.SaveChanges();
            }
            //ConsultationDrugView cdv=new ConsultationDrugView();
            //using (var consultrepo = new ConsultationDrugsRepository())
            //{
            //    if (id != 0)
            //    {
            //        ConsultationDrug consult = consultrepo.FindbyId(id);


            //        cdv.DrugId = consult.DrugId;
            //        cdv.PrescriptionId = consult.PrescriptionId;
            //        cdv.DrugName = consult.DrugName;
            //        cdv.Price = consult.Price;
            //        cdv.DrugToConsultId = consult.DrugToConsultId;
            //        cdv.Quantity = consult.Quantity;


            //    }

            //    return cdv;
            //}
        }
        #endregion

        #region Post and delete Drug from consultation
        public void PostDeleteMethod(int id, int drugid, int quantity)
        {



            //using (var consrepo = new ConsultationDrugsRepository())
            //{
            //    var drugs = drugrep.GetById(drugid);

            //    ConsultationDrugView cDV=new ConsultationDrugView();
            //    if (id != 0)
            //    {


            //        ConsultationDrug drug = consrepo.FindbyId(id);
            //        int quantit = drugs.Quantity + quantity;
            //        drugs.Quantity = quantit;
            //        drugrep.Update(drugs);
            //        consrepo.Delete(drug);
            //    }
            //}
        }
        #endregion

        #region View Consultation Drugs
        public void ViewDrugToConsult(ConsultationDrugView cdv, int id)
        {
            using (var consultrepo = new ConsultationDrugsRepository())
            {
                var drugid = da.Drugs.ToList().Find(x => x.DrugId == cdv.DrugId);
                if (cdv.DrugToConsultId == 0)
                {
                    var prescriptionid = da.CollectionDrugs.ToList().Find(x => x.collectionID == id);
                    ConsultationDrug drug = new ConsultationDrug()
                    {
                        DrugId = cdv.DrugId,
                        PrescriptionId = prescriptionid.collectionID,
                        DrugName = drugid.DrugName,
                        //Price = drugid.Price * cdv.Quantity,
                        DrugToConsultId = cdv.DrugToConsultId,
                        Quantity = cdv.Quantity,
                    };
                    consultrepo.Create(drug);
                }
            }
        }
        #endregion
        public SelectList GetUser()
        {
            IEnumerable<SelectListItem> userlist =
                (from m in da.Drugs where m.DrugId != null select m).AsEnumerable()
                    .Select(m => new SelectListItem() { Text = m.DrugName + " " + "Quantity " + m.DrugQuantity, Value = m.DrugId.ToString() });
            return new SelectList(userlist, "Value", "Text");//,con.UserId);
        }
        #region Get Consultation Drugs

        public List<ConsultationDrug> ConsultationDrugs()
        {
            return da.ConsultationDrugs.ToList();
        }

        #endregion
    }
}
