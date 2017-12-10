using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.Data.Tables
{
    public class Illness
    {
     
        public int Illnessid { get; set; }
        public string Illnessname { get; set; }

       public virtual List<Consultation> Consultations { get; set; } 
    }
}
