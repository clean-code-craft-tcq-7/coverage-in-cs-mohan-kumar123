using System;
using System.Collections.Generic;
using System.Text;
using TypewiseAlert.Interface;

namespace TypewiseAlert.ConcreteClass
{
    public class EmailFactory : ProcessFactory
    {
        private readonly AlterterType.BreachType _breachType;

        public EmailFactory(AlterterType.BreachType breachType)
        {
            _breachType = breachType;
        }
        public override ITriggerProcessor CreateProcessExecutor()
        {
           return new Email(_breachType);
        }
    }
}
