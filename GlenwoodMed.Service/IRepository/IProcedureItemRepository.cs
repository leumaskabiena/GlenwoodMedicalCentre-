using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlenwoodMed.Data.Tables;

namespace GlenwoodMed.Service.IRepository
{
    public interface IProcedureItemRepository:IDisposable
    {
        ProcedureItem GetById(Int32 id);
        List<ProcedureItem> GetAll();
        void Insert(ProcedureItem model);
        void Update(ProcedureItem model);
        void Delete(ProcedureItem model);
        void Save();
        IEnumerable<ProcedureItem> Find(Func<ProcedureItem, bool> predicate);
    }
}
