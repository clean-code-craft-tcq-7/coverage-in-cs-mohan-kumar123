using System;
using System.Collections.Generic;
using System.Text;
using TypewiseAlert.Interface;

namespace TypewiseAlert.ConcreteClass
{
    public class ControllerFactory : ProcessFactory
    {
        private readonly AlterterType.BreachType _breachType;

        public ControllerFactory(AlterterType.BreachType breachType)
        {
            _breachType = breachType;
        }
        public override ITriggerProcessor CreateProcessExecutor()
        {
            return new Controller(_breachType);
        }
    }
}
