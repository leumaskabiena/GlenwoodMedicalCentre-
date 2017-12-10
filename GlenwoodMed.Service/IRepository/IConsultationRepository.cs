using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlenwoodMed.Data;
using GlenwoodMed.Data.Tables;

namespace GlenwoodMed.Service.IRepository
{
    public  interface IConsultationRepository:IDisposable
    {
        Consultation GetById(string id);
        List<Consultation> GetAll();
        void Insert(Consultation model);
        void Update(Consultation model);
        void Delete(Consultation model);
        IEnumerable<Consultation> Find(Func<Consultation, bool> predicate);
    }
}
