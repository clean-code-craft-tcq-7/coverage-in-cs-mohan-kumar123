using System;
using TypewiseAlert.ConcreteClass;
using TypewiseAlert.Interface;
using static TypewiseAlert.AlterterType;

namespace TypewiseAlert
{
    public class TypewiseAlert : ITypewiseAlert
    {
        public BreachType breachType = new BreachType();
        public bool IsCheckActiviated = false;
        public bool IsAlertActivated = false;
        public void checkAndAlert(AlertTarget alertTarget, BatteryCharacter batteryChar, double temperatureInC, ITriggerProcessor _triggerProcessor = null)
        {
            IBreach breach = new BreachClassifier();
             breachType = breach.classifyTemperatureBreach(batteryChar.coolingType, temperatureInC);
            
            switch (alertTarget)
            {
                case AlertTarget.TO_CONTROLLER:
                    _triggerProcessor.Triggerprocess();
                    this.IsCheckActiviated = true;
                    break;
                case AlertTarget.TO_EMAIL:
                    _triggerProcessor.Triggerprocess();
                    this.IsAlertActivated = true;
                    break;
            }
        }
    }
}
