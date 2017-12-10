using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GlenwoodMed.Data.Tables;

namespace GlenwoodMedicalCentre.Models
{
    public class CustModel
    {
        public IEnumerable<Cust> CustList { get; set; } 
    }
}