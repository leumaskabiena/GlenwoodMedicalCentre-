using GlenwoodMed.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.BusinessLogic.IBusiness
{
    public interface IHIVTestResultBusiness
    {
        List<HIVTestResultModel> GetAllTest();
        HIVTestResultModel GetById(int? id);
        void Create(HIVTestResultModel testResult, int Pid);
        HIVTestResultModel GetEdit(int? id);
        HIVTestResultModel PostEdit(HIVTestResultModel id);
        HIVTestResultModel GetDelete(int? id);
        void PostDelete(int testmodel);
        HIVTestResultModel Details(int? id);
    }
}
