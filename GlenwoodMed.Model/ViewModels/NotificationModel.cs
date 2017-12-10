using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.Model.ViewModels
{
    public class NotificationModel
    {
        [Key]
        public int notificationId { get; set; }
        public bool status { get; set; }
    }
}
