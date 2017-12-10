using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.Data.Tables
{
   public  class Symptoms
    {
       public int Symptomsid { get; set; }
       public string symptomsname { get; set; }

       public virtual List<Consultation> Consultations { get; set; } 
    }
}
