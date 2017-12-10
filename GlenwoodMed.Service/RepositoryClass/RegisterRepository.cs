using GlenwoodMed.Data;
using GlenwoodMed.Service.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.Service.RepositoryClass
{
    public class RegisterRepository : IRegisterRepository
    {
        private DataContext _idatacontext = null;
        private readonly IRepository<ApplicationUser> _depRepository;

        public RegisterRepository()
        {
            _idatacontext = new DataContext();
            _depRepository = new RepositoryService<ApplicationUser>(_idatacontext);

        }

        public List<ApplicationUser> GetAll()
        {
            return _depRepository.GetAll().ToList();
        }

        public ApplicationUser GetById(string id)
        {
            return _depRepository.GetById(id);
        }

        public void Update(ApplicationUser model)
        {
            _depRepository.Update(model);
        }

        public void Dispose()
        {
            _idatacontext.Dispose();
            _idatacontext = null;
        }
    }
}
