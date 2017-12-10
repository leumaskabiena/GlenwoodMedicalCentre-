using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.Model.ViewModels
{
    public class ConsultationPriceView
    {
        public int PriceId { get; set; }

        [DataType(DataType.Currency)]
        [Required]
        public decimal PriceCost { get; set; }
        public string DateCreated { get; set; }
        public string DateEdited { get; set; }
    }
}
