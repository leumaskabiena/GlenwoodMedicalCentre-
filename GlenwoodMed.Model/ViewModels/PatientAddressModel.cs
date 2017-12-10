using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.Model.ViewModels
{
    public class PatientAddressModel
    {
        public int AddressId { get; set; }
        public string Address { get; set; }
        public int PatientId { get; set; }
        public bool DeleteAddress { get; set; }

        public virtual PatientModel Patient { get; set; }
    }
}
