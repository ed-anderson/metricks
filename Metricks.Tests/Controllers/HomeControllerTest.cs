using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Metricks;
using Metricks.Controllers;
using MetricCalculations;
using Moq;

namespace Metricks.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Here you can find references to papers describing each metric used on this website.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Calculate()
        {
            // Arrange
            double expectedResultPMI = 7.5;
            double expectedResultEFactor = 6.5;
            double expectedResultRME = 40;
            double expectedResultEMY = 66.67;

            var mockCalculations = new Mock<ICalculations>();
            
            HomeController controller = new HomeController(mockCalculations.Object);

            // Act
            mockCalculations.Setup(x => x.ProcessMassIntensity(It.IsAny<double[]>(), It.IsAny<double>())).Returns(expectedResultPMI);
            mockCalculations.Setup(x => x.EFactor(It.IsAny<double[]>(), It.IsAny<double>())).Returns(expectedResultEFactor);
            mockCalculations.Setup(x => x.ReactionMassEfficiency(It.IsAny<double[]>(), It.IsAny<double>())).Returns(expectedResultRME);
            mockCalculations.Setup(x => x.EffectiveMassYield(It.IsAny<double[]>(), It.IsAny<double>())).Returns(expectedResultEMY);

            ViewResult result = controller.Calculate(new Models.MetricRequestViewModel()) as ViewResult;

            // Assert
            Assert.AreEqual($"{expectedResultPMI}", result.ViewBag.ResultProcessMassIntensity);
            Assert.AreEqual($"{expectedResultEFactor}", result.ViewBag.ResultEFactor);
            Assert.AreEqual($"{expectedResultRME} %", result.ViewBag.ResultReactionMassEfficiency);
            Assert.AreEqual($"{expectedResultEMY} %", result.ViewBag.ResultEffectiveMassYield);
        }
    }
}
