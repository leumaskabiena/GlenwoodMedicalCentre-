using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.Data.Tables
{
    public class Procedure
    {
        //public Procedure()
        //{
        //    //consultations = new HashSet<Consultation>();
        //}
        [Key]
        public int procedureId { get; set; }

        public string procedureName { get; set; }

        public decimal procedurePrice { get; set; }

        public virtual List<Consultation> consultations { get; set; }

        public virtual List<ProcedureItem> ProcedureItem { get; set; }
    }
}
