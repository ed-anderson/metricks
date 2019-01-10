using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetricCalculations
{
    public interface ICalculations
    {
        double ProcessMassIntensity(double[] reagentMasses, double productMass);

        double EFactor(double[] reagentMasses, double productMass);

        double ReactionMassEfficiency(double[] reagentMasses, double productMass);

        double EffectiveMassYield(double[] reagentMasses, double productMass);
    }
}
