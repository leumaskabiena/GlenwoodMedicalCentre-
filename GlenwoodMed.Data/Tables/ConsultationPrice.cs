using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.Data.Tables
{
    public class ConsultationPrice
    {
        [Key]
        public int PriceId { get; set; }
        [DataType(DataType.Currency)]
        public decimal PriceCost { get; set; }
        public string DateEdited { get; set; }
        public string DateCreated { get; set; }
    }
}
