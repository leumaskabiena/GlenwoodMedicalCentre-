using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.Model.ViewModels
{
    public class Drug_PropertiesModel
    {
        [DisplayName("Drug Code")]
        public string DrugCode { get; set; }
        [DisplayName("Drug Name")]
        public string DrugName { get; set; }
        [DisplayName("Drug Category")]
        public string DrugCategory { get; set; }
        [DisplayName("Drug Description")]
        public string DrugDescription { get; set; }
    }
}
