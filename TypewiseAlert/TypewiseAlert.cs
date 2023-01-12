using System;
using TypewiseAlert.ConcreteClass;
using TypewiseAlert.Interface;
using static TypewiseAlert.AlterterType;

namespace TypewiseAlert
{
    public class TypewiseAlert : ITypewiseAlert
    {
        public BreachType breachType = new BreachType();
        public ProcessFactory processFactory = null;
        public void checkAndAlert(AlertTarget alertTarget, BatteryCharacter batteryChar, double temperatureInC)
        {
            IBreach breach = new BreachClassifier();
             breachType = breach.classifyTemperatureBreach(batteryChar.coolingType, temperatureInC);
            
            switch (alertTarget)
            {
                case AlertTarget.TO_CONTROLLER:
                    processFactory = new ControllerFactory(breachType);
                    break;
                case AlertTarget.TO_EMAIL:
                    processFactory = new EmailFactory(breachType);
                    break;
            }
            processFactory.CreateProcessExecutor().Triggerprocess();
        }
    }
}
