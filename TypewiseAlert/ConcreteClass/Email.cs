using System;
using System.Collections.Generic;
using System.Text;
using TypewiseAlert.Interface;

namespace TypewiseAlert.ConcreteClass
{
    public class Email : ITriggerProcessor
    {
        private readonly AlterterType.BreachType _breachType;
        private bool IsEmailTriggered = false;
        public Email(AlterterType.BreachType breachType)
        {
            _breachType = breachType;
        }
        public void Triggerprocess()
        {
            string recepient = "a.b@c.com";
            SendEmailForTooLow(_breachType, recepient);
        }
        public void SendEmailForTooLow(AlterterType.BreachType breachType, string recepient)
        {
            if (breachType == AlterterType.BreachType.TOO_LOW)
            {
                SendEmail("too low", recepient);
            }
            else
            {
                SendEmailForTooHigh(breachType, recepient);
            }
           
        }
        public void SendEmailForTooHigh(AlterterType.BreachType breachType, string recepient)
        {
            if (breachType != AlterterType.BreachType.NORMAL)
            {
                SendEmail("too High", recepient);
            }
        }
        public void SendEmail(string range, string recepient)
        {
            Console.WriteLine("To: {0}\n", recepient);
            Console.WriteLine("Hi, the temperature is {0}\n", range);
            TripOnTheMail();
        }
        public AlterterType.BreachType GetBranchtype()
        {
            return _breachType;
        }

        public bool IsProcesstriggered()
        {
            return IsEmailTriggered;
        }

        public void TripOnTheMail()
        {
            IsEmailTriggered = true;
        }

    }
}
