using GlenwoodMed.BusinessLogic.IBusiness;
using GlenwoodMed.Data.Tables;
using GlenwoodMed.Model.ViewModels;
using GlenwoodMed.Service.RepositoryClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.BusinessLogic.Business
{
  public class FeedBackBusiness:IFeedBackBusiness
    {
      public List<FeedBackViewModel> GetAll()
        {
            using (var obj = new FeedBackRepository())
            {
                return obj.GetAll().
                 Select(x => new FeedBackViewModel()
                 {
                     PatientId = x.PatientId,
                     Name = x.Name,
                     Email = x.Email,
                     Comment = x.Comment,
                     Votes = x.Votes

                 }).ToList();
                        
            }
        }
      public FeedBackViewModel GetById(int? id)
      {
          
          FeedBackViewModel dr = new FeedBackViewModel();
          using (var obj = new FeedBackRepository())
          {
              if (id != null)
              {
                  var _obj = obj.GetById(id.Value);
                  
                  dr.PatientId = _obj.PatientId;
              }

              return dr;
          }
      }
      public void CreateMethod(FeedBackViewModel model, string feedback)
      {
          using (var obj = new FeedBackRepository())
              if (model.PatientId == 0)
              {
                 
                  FeedBack _fd = new FeedBack
                  {
                      PatientId= model.PatientId,
                      Name = model.Name,
                      Email= model.Email,
                      Comment = model.Comment,
                      Votes = feedback
                  };
                  obj.Insert(_fd);
              }
      }
      public FeedBackViewModel DetailsMethod(int? id)
      {
         
          FeedBackViewModel dr = new FeedBackViewModel();
          using (var fd = new FeedBackRepository())
          {
              if (id.HasValue && id != 0)
              {
            
                  FeedBack _fb = fd.GetById(id.Value);

                  dr.PatientId = _fb.PatientId;
                  dr.Name = _fb.Name;
                  dr.Email = _fb.Email;
                  dr.Comment = _fb.Comment;
                 

              }
              return dr;
          }
      }
      public FeedBackViewModel GetDeleteMethod(int id)
      {
          FeedBackViewModel rm = new FeedBackViewModel();

          using (var parepo = new FeedBackRepository())
          {
              if (id != 0)
              {
                  FeedBack _patient = parepo.GetById(id);

                  rm.PatientId = _patient.PatientId;
                  rm.Name = _patient.Name;
                  rm.Email = _patient.Email;
                  rm.Comment = _patient.Comment;
                 
              }

              return rm;
          }
      }

      public void PostDeleteMethod(int id)
      {
          using (var parepo = new FeedBackRepository())
          {
              if (id != 0)
              {
                  FeedBack _patient = parepo.GetById(id);
                  parepo.Delete(_patient);
              }
          }
      }
    }
}
