using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GlenwoodMed.Model.ViewModels
{
    public class ProcedureView
    {
        //public Procedure()
        //{
        //    //consultations = new HashSet<Consultation>();
        //}
        [Key]
        public int procedureId { get; set; }

        public string procedureName { get; set; }

        public decimal procedurePrice { get; set; }
        public ICollection<ConsultationView> Consultation { get; set; }
        public virtual List<ProcedureItemView> ProcedureItem { get; set; }
    }
}
