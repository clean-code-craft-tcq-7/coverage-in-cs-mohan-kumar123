using System;
using System.Collections.Generic;
using System.Text;

namespace TypewiseAlert.Interface
{
    public interface ITriggerProcessor
    {
        void Triggerprocess();
        AlterterType.BreachType GetBranchtype();
        bool IsProcesstriggered();
    }
}
