using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlenwoodMed.Data.Tables;
using GlenwoodMed.Model.ViewModels;
using GlenwoodMed.Service.RepositoryClass;

namespace GlenwoodMed.BusinessLogic.Business
{
    public class ProcedureBusiness
    {
        ProcedureItemView ProcedureItemView = new ProcedureItemView();
        Procedure procedure = new Procedure();
        ProcedureItem ProcedureItem = new ProcedureItem();
        ProcedureRepository procedureRepository=new ProcedureRepository();
        ProcedureItemRepository procedureItemRepository=new ProcedureItemRepository();


        public void CreateProcedure(ProcedureView PV, int []procedureitems)
        {
            procedure.ProcedureItem=new List<ProcedureItem>();
            foreach (var item in procedureitems)
            {
                var proceduretoadd=procedureItemRepository.GetById(item);
                procedure.procedurePrice += proceduretoadd.price;
                procedure.ProcedureItem.Add(proceduretoadd);
            }
            procedureRepository.Insert(procedure);
        }

        public ProcedureView EditProcedureView(int? id)
        {
            ProcedureView PV=new ProcedureView();
            if (PV != null)
            {
                var ob = procedureRepository.GetById(id.Value);
                List<ProcedureView> procedures = new List<ProcedureView>();
                ProcedureItemView procedureItem=new ProcedureItemView();
                 PV.procedureId=ob.procedureId;
                ob.procedureName = PV.procedureName;
                ob.procedurePrice = PV.procedurePrice;
                 PV.ProcedureItem =new List<ProcedureItemView>();
                foreach (var item in ob.ProcedureItem)
                {
                    var produce = procedureItemRepository.GetById(item.ProcedureitemID);
                    procedureItem.name = produce.name;
                    procedureItem.ProcedureitemID = produce.ProcedureitemID;
                    PV.ProcedureItem.Add(procedureItem);
                }
            }
            return PV;
        }
        public void EditProcedurePost(ProcedureView PV, int[] procedureitems)
        {
            if (PV != null)
            {
                var ob=procedureRepository.GetById(PV.procedureId);
                
                ob.procedureId = PV.procedureId;
                ob.procedureName = PV.procedureName;
                ob.procedurePrice = PV.procedurePrice;
                foreach (var item in procedureitems)
                {
                    var produce = procedureItemRepository.GetById(item);
                    ob.ProcedureItem.Add(produce);
                }
                procedureRepository.Update(ob);

            }

        }
    }
}
