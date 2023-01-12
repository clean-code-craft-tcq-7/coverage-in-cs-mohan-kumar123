using System;
using System.Collections.Generic;
using System.Text;

namespace TypewiseAlert.Interface
{
    public abstract class ProcessFactory
    {
       public abstract ITriggerProcessor CreateProcessExecutor();
    }
}
