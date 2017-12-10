using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GlenwoodMed.Data.Tables
{
    public class WorkingTime
    {
        [Key]
        public int Id { get;set; }

        [Display(Name = "Start Time ")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        public string hour_start { get; set; }

        [Display(Name = "End Time ")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        public string hour_end { get; set; }
        [Display(Name = "End Time ")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        public string text { get; set; }
    }
}
