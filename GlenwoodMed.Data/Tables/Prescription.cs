using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.Data.Tables
{
    public class Prescription
    {
        [Key]
        public int p_MedicineId { get; set; }
        public string p_Medicine { get; set; }
        public string p_PatientName { get; set; }
        public DateTime p_Date { get; set; }
    }
}
