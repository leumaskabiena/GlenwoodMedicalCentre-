using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.Model.ViewModels
{
    public class Test_Image
    {
        public List<TestResultModel> _testList { get; set; }
        public TestResultModel _test { get; set; }
        public ImageView _image { get; set; }
    }
}
