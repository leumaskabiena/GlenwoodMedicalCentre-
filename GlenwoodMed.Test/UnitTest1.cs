using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GlenwoodMedicalCentre.Controllers;
using GlenwoodMed.BusinessLogic.Business;
using System.Web.Mvc;
using GlenwoodMed.Model.ViewModels;
using System.Collections.Generic;
using GlenwoodMed.Data;
using Moq;
namespace GlenwoodMed.Test
{
    [TestClass]
    public class UnitTest1
    {
        //private Mock<IRepository> _mockRepository;
        //private ModelStateDictionary _modelState;
        //private RepositoryService _service;

        //[TestInitialize]
        //public void Initialize()
        //{
        //    _mockRepository = new Mock<IRepository>();
        //    _modelState = new ModelStateDictionary();
        //    _service = new RepositoryService(new ModelStateWrapper(_modelState), _mockRepository.Object);
        //}

        [TestMethod]
        public void TestMethod1()
        {
            //Arrange ( Create objects and prepare everything needed to test functionality )
            SimpleTest maths = new SimpleTest();

            //Act ( Execute and get the output )
            int result = maths.Add(6, 5);

            //Assert ( Compare final output with expected Output )
            Assert.AreEqual<int>(11, result);
        }

        [TestMethod]
        public void PatientList()
        {
            //Arrange ( Create objects and prepare everything needed to test functionality )
            PatientBusiness pb = new PatientBusiness();
            //DataContext da = new DataContext();
            //Act ( Execute and get the output )
            List<PatientModel> model = pb.GetAllPatients();

            //Assert ( Compare final output with expected Output )
            Assert.AreEqual(pb.GetAllPatients(), model);
        }

        [TestMethod]
        public void TestDetailsForRedirect()
        {
            PatientController controller = new PatientController();
            var result = controller.ViewPatient(0) as RedirectToRouteResult;
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("Patient", result.RouteValues["controller"]);
        }

        //[TestMethod]
        //public void TestReturnViewPatient()
        //{
        //    PatientController controller = new PatientController();
        //    ViewResult result1 = (ViewResult)controller.ViewPatient(2);
        //    Assert.AreEqual("ViewPatient", result1.Model);
        //}
    }
}
