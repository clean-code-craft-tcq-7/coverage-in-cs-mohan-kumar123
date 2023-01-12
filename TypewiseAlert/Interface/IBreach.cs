using System;
using System.Collections.Generic;
using System.Text;

namespace TypewiseAlert.Interface
{
    public interface IBreach
    {
        AlterterType.BreachType classifyTemperatureBreach(CoolingType coolingType, double temperatureInC);
    }
}
