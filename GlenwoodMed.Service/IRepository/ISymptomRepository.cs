using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlenwoodMed.Data.Tables;

namespace GlenwoodMed.Service.IRepository
{
   public interface ISymptomRepository:IDisposable
    {
        Symptoms GetById(Int32 id);
        List<Symptoms> GetAll();
        void Insert(Symptoms model);
        void Update(Symptoms model);
        void Delete(Symptoms model);
        void Save();
        IEnumerable<Symptoms> Find(Func<Drug, bool> predicate);
    }
}
