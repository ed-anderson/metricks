using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metricks.Tests.Calculations
{
    [TestClass]
    public class ReactionMassEfficiencyTests
    {
        private MetricCalculations.Calculations calculations = new MetricCalculations.Calculations();

        [TestMethod]
        public void NullReagentMasses_ThrowsInvalidArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => {
                calculations.ReactionMassEfficiency(null, 5);
            });
        }

        [TestMethod]
        public void ZeroProductMass_ThrowsInvalidArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => {
                calculations.ReactionMassEfficiency(new double[] { 1, 2, 3 }, 0);
            });
        }

        [TestMethod]
        public void EmptyArray_ThrowsInvalidArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => {
                calculations.ReactionMassEfficiency(new double[0], 5);
            });
        }

        [TestMethod]
        public void ValidInputs_ReturnsCorrectValue()
        {
            var result = calculations.ReactionMassEfficiency(new double[] { 1.11, 2.22, 3.33 }, 9.99);

            Assert.AreEqual(150, result);
        }
    }
}
