using System;
using System.Collections.Generic;
using GlenwoodMed.Data.Tables;

namespace GlenwoodMed.Service.IRepository
{
    public interface IDrugRepository : IDisposable
    {
        Drug GetById(Int32 id);
        List<Drug> GetAll();
        void Insert(Drug model);
        void Update(Drug model);
        void Delete(Drug model);
        void Save();
        IEnumerable<Drug> Find(Func<Drug, bool> predicate);

    }
}
