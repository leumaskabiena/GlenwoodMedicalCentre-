using GlenwoodMed.Data;
using GlenwoodMed.Data.Tables;
using GlenwoodMed.Service.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.Service.RepositoryClass
{
    public class ImageGalleryRepository:IImageGalleryRepository
    {
        private DataContext _dataContext = null;
        private readonly IRepository<ImageGallery> _imageRepository;

        public ImageGalleryRepository()
        {
            _dataContext = new DataContext();
            _imageRepository = new RepositoryService<ImageGallery>(_dataContext);

        }

        public ImageGallery GetById(int id)
        {
            return _imageRepository.GetById(id);
        }

        public List<ImageGallery> GetAll()
        {
            return _imageRepository.GetAll().ToList();
        }

        public void Insert(ImageGallery model)
        {
            _imageRepository.Insert(model);
        }

        public void Update(ImageGallery model)
        {
            _imageRepository.Update(model);
        }

        public void Delete(ImageGallery model)
        {
            _imageRepository.Delete(model);
        }

        public IEnumerable<ImageGallery> Find(Func<ImageGallery, bool> predicate)
        {
            return _imageRepository.Find(predicate).ToList();
        }

        public void Dispose()
        {
            _dataContext.Dispose();
            _dataContext = null;
        }
    }
}
