using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlenwoodMed.Data.Tables;

namespace GlenwoodMed.Service.IRepository
{
    public interface IIllnessRepository:IDisposable
    {
        Illness GetById(Int32 id);
        List<Illness> GetAll();
        void Insert(Illness model);
        void Update(Illness model);
        void Delete(Illness model);
        void Save();
        IEnumerable<Illness> Find(Func<Illness, bool> predicate);
    }
}
