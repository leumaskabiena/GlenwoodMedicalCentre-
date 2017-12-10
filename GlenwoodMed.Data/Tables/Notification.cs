using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.Data.Tables
{
    public class Notification
    {
        [Key]
        public int notificationId { get; set; }
        public bool status { get; set; }
    }
}
