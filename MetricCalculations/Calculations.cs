using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetricCalculations
{
    public class Calculations
    {
        public double ProcessMassIntensity(double[] reagentMasses, double productMass)
        {
            if (reagentMasses == null)
            {
                throw new ArgumentException("regentMasses is null");
            }
            
            if (productMass == 0)
            {
                throw new ArgumentException("productMasses is 0");
            }

            return reagentMasses.Sum() / productMass;
        }

        public double EFactor(double[] reagentMasses, double productMass)
        {
            if (reagentMasses == null)
            {
                throw new ArgumentException("regentMasses is null");
            }

            if (productMass == 0)
            {
                throw new ArgumentException("productMasses is 0");
            }

            return (reagentMasses.Sum() / productMass) - 1;
        }

        public double ReactionMassEfficiency(double[] reagentMasses, double productMass)
        {
            if (reagentMasses == null)
            {
                throw new ArgumentException("regentMasses is null");
            }

            if (productMass == 0)
            {
                throw new ArgumentException("productMasses is 0");
            }

            return (productMass / reagentMasses.Sum()) * 100;
        }

        public double EffectiveMassYield(double[] reagentMasses, double productMass)
        {
            if (reagentMasses == null)
            {
                throw new ArgumentException("regentMasses is null");
            }

            if (productMass == 0)
            {
                throw new ArgumentException("productMasses is 0");
            }

            return (productMass / reagentMasses.Sum()) * 100;
        }
    }
}
