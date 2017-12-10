using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.Model.ViewModels
{
    public class SymptomsModel
    {
        public SymptomsModel()
       {
           Consultations=new HashSet<ConsultationView>();
       }
       public int Symptomsid { get; set; }
       public string symptomsname { get; set; }

       public virtual ICollection<ConsultationView> Consultations { get; set; } 
    }
}
