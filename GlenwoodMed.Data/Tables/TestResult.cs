using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GlenwoodMed.Data.Tables
{
   public class TestResult
    {
        [Key]
        public int ResultId { get; set; }
        [DisplayName("Select File to Upload")]
        public IEnumerable<HttpPostedFileBase> File { get; set; }
        public string FileName { get; set; }
        public byte[] resultFile { get; set; }

        public int PatientId { get; set; }
        public string PatientName { get; set; }
    }
    public class Result
    {
        [Key]
        public int Id { get; set; }
        public string FileName { get; set; }
        public byte[] File { get; set; }

        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public string PatientName { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
