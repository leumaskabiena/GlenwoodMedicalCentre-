using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlenwoodMed.Data.Tables;

namespace GlenwoodMed.Service.IRepository
{
    public interface IConsultationDrugsRepository:IDisposable
    {
        List<ConsultationDrug> Getall();
        ConsultationDrug FindbyId(int id);
        void Create(ConsultationDrug model);
        void Update(ConsultationDrug model);
        void Delete(ConsultationDrug model);
    }
}
