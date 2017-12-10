using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.BusinessLogic.IBusiness
{
    public interface IStatisticsBusiness
    {
        object[] AgeData(int? number1, int? number2, int? number3);
        object[] DrugData();
        object[] ProfitYear();
        object[] ProfitMonth(int year);
        object[] ProfitDays(int year, string month);
    }
}
