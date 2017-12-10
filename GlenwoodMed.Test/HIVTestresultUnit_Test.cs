using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlenwoodMed.BusinessLogic.Business;
using GlenwoodMed.Service.RepositoryClass;
using GlenwoodMed.Model.ViewModels;

namespace GlenwoodMed.Test
{
    public class busin
    {
        HIVTestResultBusiness Hbus = new HIVTestResultBusiness();
        HIVTestResultModel ee = new HIVTestResultModel();
        public busin(int TestId, string PatientName, DateTime Date, DateTime DOB, string TestigLocation, string Gender, DateTime NextAppointment, string HIVtestType, string Status, int PatientId)
        {
           
            ee.TestId = TestId;
            ee.PatientName = PatientName;
            ee.Date = Date;
            ee.DOB = DOB;
            ee.TestigLocation = TestigLocation;
            ee.Gender = Gender;
            ee.NextAppointment = NextAppointment;
            ee.HIVtestType = HIVtestType;
            ee.Status = Status;
            ee.PatientId = PatientId;

        }
        public HIVTestResultModel CreateTest()
        {
            //Hbus.Create(HIVTestResultModel ob,int pId);

            
            ee.TestId = 21314007;
            ee.PatientName = "marlin";
            ee.Date = Convert.ToDateTime("11/06/2015");
            ee.DOB = Convert.ToDateTime("11/06/1950");
            ee.TestigLocation = "Steve biko";
            ee.Gender = "Male";
            ee.NextAppointment = Convert.ToDateTime("11/07/2015");
            ee.HIVtestType = "i dont know";
            ee.Status = "Negative";
            ee.PatientId = 123;
            return ee;
        }

    }
    [TestClass]
    public class HIVTestresultUnit_Test
    {
        HIVTestResultBusiness testsbusinss = new HIVTestResultBusiness();
        HIVTestResultModel ee = new HIVTestResultModel();
        [TestMethod]
        public void CreateMethodtest()
        {
            ee.TestId = 21314007;
            ee.PatientName = "marlin";
            ee.Date = Convert.ToDateTime("11/06/2015");
            ee.DOB = Convert.ToDateTime("11/06/1950");
            ee.TestigLocation = "Steve biko";
            ee.Gender = "Male";
            ee.NextAppointment = Convert.ToDateTime("11/07/2015");
            ee.HIVtestType = "i dont know";
            ee.Status = "Negative";
            ee.PatientId = 123;

            busin test = new busin(21314007, "marlin", Convert.ToDateTime("11/06/2015"), Convert.ToDateTime("11/06/1950"), "Steve biko", "Male", Convert.ToDateTime("11/07/2015"), "i dont know", "Negative", 123);
            var result = test.CreateTest();
            //Assert.AreEqual<HIVTestResultModel>(ee,test,"test is not corrrect");
        }
    }



    public class CustomMaths
    {
        public int Number1 { get; set; }
        public int Number2 { get; set; }

        public CustomMaths(int num1, int num2)
        {
            Number1 = num1;
            Number2 = num2;
        }
        public int Add()
        {
            return Number1 + Number2;
        }
        public int Sub()
        {
            return Number1 - Number2;
        }
    }


    [TestClass]
    public class TestMathsClass
    {
        [TestMethod]
        public void TestAdd()
        {
            //Arrange
            CustomMaths maths = new CustomMaths(6, 5);

            //Act
            int result = maths.Add();

            //Assert
            Assert.AreEqual<int>(12, result);
        }

        [TestMethod]
        public void TestSub()
        {
            //Arrange
            CustomMaths maths = new CustomMaths(6, 5);

            //Act
            int result = maths.Sub();

            //Assert
            Assert.AreEqual<int>(1, result);
        }
    }
}
