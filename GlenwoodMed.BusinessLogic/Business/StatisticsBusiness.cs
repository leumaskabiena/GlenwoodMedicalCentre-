using GlenwoodMed.BusinessLogic.IBusiness;
using GlenwoodMed.Data;
using GlenwoodMed.Data.Tables;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.BusinessLogic.Business
{
    public class StatisticsBusiness : IStatisticsBusiness
    {
        public class AgeClass
        {
            public string AgeG { get; set; }
            public int count { get; set; }

            public AgeClass()
            {
                AgeG = "";
                count = 0;
            }

            public AgeClass(string Age, int C)
            {
                AgeG = Age;
                count = C;
            }
        }

        public object[] AgeData(int? number1, int? number2, int? number3)
        {
            List<AgeClass> agc = new List<AgeClass>();

            DataContext da = new DataContext();

            string age = "", age1 = "", age2 = "", age3 = "", age4 = "", age5 = "";
            int Count = 0, Count1 = 0, Count2 = 0, Count3 = 0, Count4 = 0, Count5 = 0;

            if(!number1.HasValue && !number2.HasValue && !number3.HasValue)
            {
                foreach (Patient p in da.Patients)
                {
                    int Age = Convert.ToInt32(p.Age);

                    if (Age < 13)
                    {
                        age = "Less than 13";
                        Count++;
                    }

                    if ((Age >= 13) && (Age <= 18))
                    {
                        age1 = "13 - 18";
                        Count1++;
                    }

                    if ((Age >= 19) && (Age <= 30))
                    {
                        age2 = "19 - 30";
                        Count2++;
                    }

                    if ((Age >= 31) && (Age <= 45))
                    {
                        age3 = "31 - 45";
                        Count3++;
                    }

                    if ((Age >= 46) && (Age <= 60))
                    {
                        age4 = "46 - 60";
                        Count4++;
                    }

                    if (Age >= 61)
                    {
                        age5 = "61 Above";
                        Count5++;
                    }
                }

                AgeClass obj = new AgeClass(age, Count);
                AgeClass obj1 = new AgeClass(age1, Count1);
                AgeClass obj2 = new AgeClass(age2, Count2);
                AgeClass obj3 = new AgeClass(age3, Count3);
                AgeClass obj4 = new AgeClass(age4, Count4);
                AgeClass obj5 = new AgeClass(age5, Count5);

                agc.Add(obj);
                agc.Add(obj1);
                agc.Add(obj2);
                agc.Add(obj3);
                agc.Add(obj4);
                agc.Add(obj5);
            }

            if (number1.HasValue)
            {
                age1 = number1.ToString();

                var ag = (from e in da.Patients.ToList()
                          where e.Age == number1.Value.ToString()
                          select e.Age).ToList();

                foreach(var p in ag)
                {
                    Count1++;
                }

                AgeClass obj1 = new AgeClass(age1, Count1);
                agc.Add(obj1);
            }

            if (number2.HasValue && number3.HasValue)
            {
                foreach (Patient p in da.Patients)
                {
                    int Age = Convert.ToInt32(p.Age);

                    if ((Age >= number2.Value) && (Age <= number3.Value))
                    {
                        age1 = number2.Value.ToString() + "-" + number3.Value.ToString();
                        Count1++;
                    }
                }

                AgeClass obj1 = new AgeClass(age1, Count1);
                agc.Add(obj1);
            }

            var chartData = new object[agc.Count + 1];
            chartData[0] = new object[]{
                "Age Group",
                "Age Count"
            };

            int count = 0;
            foreach (var i in agc)
            {
                count++;
                chartData[count] = new object[] { i.AgeG, i.count };
            }

            return chartData;
        }

        public object[] DrugData()
        {
            List<Drug> drg = new List<Drug>();
            DataContext da = new DataContext();
            drg = da.Drugs.ToList();

            var chartData = new object[drg.Count + 1];
            chartData[0] = new object[]{
                "Drug Group",
                "Drug Quantity"
            };

            int count = 0;
            foreach (var i in drg)
            {
                count++;
                chartData[count] = new object[] { i.DrugName, i.DrugQuantity };
            }

            return chartData;
        }

        public object[] ReportData()
        {
            int days = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);

            List<Consultation> con = new List<Consultation>();
            DataContext da = new DataContext();
            //con = da.Consultations.ToList();

            con = (from a in da.Consultations
                   where a.ConsultDate.Year.Equals(DateTime.Now.Year) && a.ConsultDate.Month.Equals(DateTime.Now.Month)
                   select a).ToList();

            //if(con != null)
            //{
                decimal tp = 0, ttp = 0, pp = 0;
                var chartData = new object[days + 1];
                //var chartData = new object[drg.Count + 1];
                chartData[0] = new object[]
                {
                    "Consultation Date",
                    "Total Fee"
                };
                int count = 0;
                for (int i = 1; i <= days; i++)
                {
                    var aysData = con.Where(a => a.ConsultDate.Day.Equals(i));
                    count++;
                    tp = aysData.Sum(x => x.TotalPrice);

                    //ttp = aysData.Sum(x => x.TestTypePrice);
                    //pp = aysData.Sum(x => x.ProcedurePricee);
                    if (aysData != null)
                    {
                        chartData[i] = new object[] { i.ToString(), tp };
                    }

                    else
                    {
                        chartData[i] = new object[] { i.ToString(), 0 };
                    }
                }
                return chartData;
            //}
            
            //int count = 0;
            //foreach (var i in drg)
            //{
            //    count++;
            //    chartData[count] = new object[] { i.ConsultDate.ToString("D"), i.TotalPrice }; 
            //}
            
            //return chartData;
            //return null;
        }

        public object[] ProfitYear()
        {
            using (DataContext da = new DataContext())
            {
                var select = (from a in da.Consultations
                              group a by a.ConsultDate.Year into g
                              select new
                              {
                                  Year = g.Key,
                                  Price = g.Sum(a => a.TotalPrice),
                                  Test = g.Sum(a => a.TestTypePrice),
                                  ProcedurePrice = g.Sum(a => a.ProcedurePricee)
                                  //ff = g.Sum(a => a.TotalPrice),

                              });

                if (select != null)
                {
                    var chartData = new object[select.Count() + 1];
                    chartData[0] = new object[]
                    {
                        "Year",
                        "Consultation Price",
                        "Tests",
                        "Procedures"
                    };

                    int count = 0;
                    foreach (var i in select)
                    {
                        count++;
                        chartData[count] = new object[] { i.Year.ToString(), i.Price, i.Test, i.ProcedurePrice };
                    }
                    return chartData;
                }
            }
            return null;
        }

        public object[] ProfitMonth(int year)
        {
            using (DataContext da = new DataContext())
            {
                var select = (from a in da.Consultations
                              where a.ConsultDate.Year.Equals(year)
                              group a by a.ConsultDate.Month into g
                              select new
                              {
                                  Month = g.Key,
                                  Price = g.Sum(a => a.TotalPrice),
                                  Test = g.Sum(a => a.TestTypePrice),
                                  ProcedurePrice = g.Sum(a => a.ProcedurePricee)
                              });

                if (select != null)
                {
                    var chartData = new object[12 + 1];
                    chartData[0] = new object[]
                    {
                        "Month",
                        "Consultation Price",
                        "Tests",
                        "Procedures"
                    };

                    for (int i = 1; i <= 12; i++)
                    {
                        string monthname = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i);
                        var monthData = select.Where(a => a.Month.Equals(i)).FirstOrDefault();

                        if (monthData != null)
                        {
                            chartData[i] = new object[] { monthname, monthData.Price, monthData.Test, monthData.ProcedurePrice };
                        }

                        else
                        {
                            chartData[i] = new object[] { monthname, 0, 0, 0 };
                        }
                    }

                    return chartData;
                }
            }

            return null;
        }

        public object[] ProfitDays(int year, string month)
        {
            int monthNumber = DateTime.ParseExact(month, "MMMM", CultureInfo.InvariantCulture).Month;
            int days = DateTime.DaysInMonth(year, monthNumber);

            List<Consultation> con = new List<Consultation>();
            using (DataContext da = new DataContext())
            {
                con = (from a in da.Consultations
                       where a.ConsultDate.Year.Equals(year) && a.ConsultDate.Month.Equals(monthNumber)
                       select a).ToList();

                //var select = (from a in da.Consultations
                //              where a.ConsultDate.Year.Equals(year) && a.ConsultDate.Month.Equals(monthNumber)
                //              group a by a.ConsultDate.Day into g
                //              select new
                //              {
                //                  Day = g.Key,
                //                  Price = g.Sum(a => a.TotalPrice),
                //                  Test = g.Sum(a => a.TestTypePrice),
                //                  ProcedurePrice = g.Sum(a => a.ProcedurePricee)
                //              });
                //if (select != null)
                //{
                //    var chartData = new object[days + 1];
                //    chartData[0] = new object[]
                //    {
                //        "Day",
                //        "Consultation Price",
                //        "Tests",
                //        "Procedures"
                //    };

                //    for (int i = 1; i <= days; i++)
                //    {
                //        //var daysData = con.Where(a => a.ConsultDate.Day.Equals(i)).FirstOrDefault();
                //        var daysData = select.Where(a => a.Day.Equals(i)).FirstOrDefault();

                //        if (daysData != null)
                //        {
                //            chartData[i] = new object[] { i.ToString(), daysData.Price, daysData.Test, daysData.ProcedurePrice };
                //        }

                //        else
                //        {
                //            chartData[i] = new object[] { i.ToString(), 0, 0, 0 };
                //        }
                //    }
                //    return chartData;
                //}
                if (con != null)
                {
                    decimal tp = 0, ttp = 0, pp = 0;
                    var chartData = new object[days + 1];
                    chartData[0] = new object[]
                    {
                        "Day",
                        "Consultation Price",
                        "Tests",
                        "Procedures"
                    };

                    for (int i = 1; i <= days; i++)
                    {
                        var daysData = con.Where(a => a.ConsultDate.Day.Equals(i)).FirstOrDefault();
                        var aysData = con.Where(a => a.ConsultDate.Day.Equals(i));

                        tp = aysData.Sum(x => x.TotalPrice);
                        ttp = aysData.Sum(x => x.TestTypePrice);
                        pp = aysData.Sum(x => x.ProcedurePricee);

                        //if (daysData != null)
                        //{
                        //    chartData[i] = new object[] { i.ToString(), daysData.TotalPrice, daysData.TestTypePrice, daysData.ProcedurePricee };
                        //}
                        if (aysData != null)
                        {
                            chartData[i] = new object[] { i.ToString(), tp, ttp, pp };
                        }

                        else
                        {
                            chartData[i] = new object[] { i.ToString(), 0, 0, 0 };
                        }
                    }
                    return chartData;
                }
            }
            return null;
        }
    }
}
