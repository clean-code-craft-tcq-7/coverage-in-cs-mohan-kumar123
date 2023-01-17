using TypewiseAlert.Interface;

namespace TypewiseAlert
{
    public interface ITypewiseAlert
    {
        void checkAndAlert(AlertTarget alertTarget, BatteryCharacter batteryChar, double temperatureInC, ITriggerProcessor _triggerProcessor);
    }
}