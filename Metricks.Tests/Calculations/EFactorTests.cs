using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metricks.Tests.Calculations
{
    [TestClass]
    public class EFactorTests
    {
        private MetricCalculations.Calculations calculations = new MetricCalculations.Calculations();

        [TestMethod]
        public void NullReagentMasses_ThrowsInvalidArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => {
                calculations.EFactor(null, 5);
            });
        }

        [TestMethod]
        public void ZeroProductMass_ThrowsInvalidArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => {
                calculations.EFactor(new double[] { 1, 2, 3 }, 0);
            });
        }

        [TestMethod]
        public void EmptyArray_ThrowsInvalidArgumentException()
        {
            var result = calculations.EFactor(new double[0], 5);

            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void ValidInputs_ReturnsCorrectValue()
        {
            var result = calculations.EFactor(new double[] { 1.11, 2.22, 3.33 }, 4.44);

            Assert.AreEqual(0.5, result);
        }
    }
}
