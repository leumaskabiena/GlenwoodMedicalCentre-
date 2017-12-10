using GlenwoodMed.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.Service.IRepository
{
    public interface IFeedbackRepository : IDisposable
    {
        FeedBack GetById(Int32 id);
        List<FeedBack> GetAll();
        void Insert(FeedBack model);
        void Update(FeedBack model);
        void Delete(FeedBack model);
        IEnumerable<FeedBack> Find(Func<FeedBack, bool> predicate);
    }
}
