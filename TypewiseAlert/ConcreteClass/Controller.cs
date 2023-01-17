using System;
using System.Collections.Generic;
using System.Text;
using TypewiseAlert.Interface;

namespace TypewiseAlert.ConcreteClass
{
    public class Controller : ITriggerProcessor
    {
        private readonly AlterterType.BreachType _breachType;
        private bool IsControllerTriggered = false;
        private readonly ITriggerProcessor _triggerProcessor;

        public Controller(AlterterType.BreachType breachType)
        {
            _breachType = breachType;
        }

        public Controller()
        {

        }

        public Controller(ITriggerProcessor triggerProcessor)
        {
            _triggerProcessor = triggerProcessor;
        }

        public AlterterType.BreachType GetBranchtype()
        {
            return _breachType;
        }

        public bool IsProcesstriggered()
        {
            return IsControllerTriggered;
        }

        public void Triggerprocess()
        {
            const ushort header = 0xfeed;
            Console.WriteLine("{0} : {1}\n", header, _breachType.ToString());
            IsControllerTriggered = true;
        }
    }
}
