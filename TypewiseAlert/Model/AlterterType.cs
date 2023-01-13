using System;
using System.Collections.Generic;
using System.Text;

namespace TypewiseAlert
{
    public class AlterterType
    {
        public enum BreachType
        {
            NORMAL,
            TOO_LOW,
            TOO_HIGH
        };

    }
    public enum CoolingType
    {
        PASSIVE_COOLING,
        HI_ACTIVE_COOLING,
        MED_ACTIVE_COOLING
    };
    public enum AlertTarget
    {
        TO_CONTROLLER,
        TO_EMAIL
    };

    public enum Temp_UpperLimit
    {
        PASSIVE_COOLING = 35,
        HI_ACTIVE_COOLING = 45,
        MED_ACTIVE_COOLING = 40
    }
    public enum Temp_LowerLimit
    {
        PASSIVE_COOLING = 0,
        HI_ACTIVE_COOLING = 0,
        MED_ACTIVE_COOLING = 0
    }
}
