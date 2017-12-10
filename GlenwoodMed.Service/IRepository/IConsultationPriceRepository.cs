using GlenwoodMed.Data;
using GlenwoodMed.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.Service.IRepository
{
    public interface IConsultationPriceRepository:IDisposable
    {
        List<ConsultationPrice> Getall();
        void Update(ConsultationPrice model);
        ConsultationPrice FindbyId(int id);
    }
}
