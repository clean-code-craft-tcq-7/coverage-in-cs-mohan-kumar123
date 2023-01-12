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
            sampleData = new SampleData() { lowerLimit = 0, upperLimit = 35 };

            if (coolingType != CoolingType.PASSIVE_COOLING)
            {
                CheckHighActiveCooling(coolingType);
            }
            return sampleData;
        }
        public SampleData CheckHighActiveCooling(CoolingType coolingType)
        {
            sampleData = new SampleData() { lowerLimit = 0, upperLimit = 45 };

            if (coolingType != CoolingType.HI_ACTIVE_COOLING)
            {
                CheckMedActiveCooling(coolingType);
            }
            return sampleData;
        }
        public SampleData CheckMedActiveCooling(CoolingType coolingType)
        {
                sampleData = new SampleData() { lowerLimit = 0, upperLimit = 40 };
                return sampleData;
        }

    }
}
