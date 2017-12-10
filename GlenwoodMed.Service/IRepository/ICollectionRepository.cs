using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlenwoodMed.Data.Tables;

namespace GlenwoodMed.Service.IRepository
{
   public  interface ICollectionRepository:IDisposable
   {
       List<CollectionDrugs> Getall();
       CollectionDrugs FindbyId(int id);
       void Create(CollectionDrugs model);
       void Update(CollectionDrugs model);
       void Delete(CollectionDrugs model);
   }
}
