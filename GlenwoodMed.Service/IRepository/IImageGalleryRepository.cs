using GlenwoodMed.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.Service.IRepository
{
    public  interface IImageGalleryRepository:IDisposable
    {
        ImageGallery GetById(Int32 id);
        List<ImageGallery> GetAll();
        void Insert(ImageGallery model);
        void Update(ImageGallery model);
        void Delete(ImageGallery model);
        IEnumerable<ImageGallery> Find(Func<ImageGallery, bool> predicate);
    }
}
