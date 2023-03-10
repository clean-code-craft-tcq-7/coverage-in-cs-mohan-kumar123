using System;
using TypewiseAlert.Interface;
using TypewiseAlert.Model;

namespace TypewiseAlert.ConcreteClass
{
    public class BreachClassifier : IBreach
    {
        SampleData sampleData = new SampleData();
        public AlterterType.BreachType classifyTemperatureBreach(CoolingType coolingType, double temperatureInC)
        {
            SampleData sampleData = CheckPassiveCooling(coolingType);

            return inferBreach(temperatureInC, sampleData.lowerLimit, sampleData.upperLimit);
        }
        public static AlterterType.BreachType inferBreach(double value, double lowerLimit, double upperLimit)
        {
            if (value < lowerLimit)
            {
                return AlterterType.BreachType.TOO_LOW;
            }
            if (value > upperLimit)
            {
                return AlterterType.BreachType.TOO_HIGH;
            }
            return AlterterType.BreachType.NORMAL;
        }
        public SampleData CheckPassiveCooling(CoolingType coolingType)
        {
            GetLimit(coolingType);
            if (coolingType != CoolingType.PASSIVE_COOLING)
            {
                CheckHighActiveCooling(coolingType);
            }
            return sampleData;
        }
        public SampleData CheckHighActiveCooling(CoolingType coolingType)
        {
            GetLimit(coolingType);

            if (coolingType != CoolingType.HI_ACTIVE_COOLING)
            {
                CheckMedActiveCooling(coolingType);
            }
            return sampleData;
        }
        public SampleData CheckMedActiveCooling(CoolingType coolingType)
        {
            GetLimit(coolingType);
            return sampleData;
        }

        private void GetLimit(CoolingType coolingType)
        {
            sampleData = new SampleData() { lowerLimit = (int)Enum.Parse(typeof(Temp_LowerLimit), coolingType.ToString()), upperLimit = (int)Enum.Parse(typeof(Temp_UpperLimit), coolingType.ToString()) };
        }
    }
}
