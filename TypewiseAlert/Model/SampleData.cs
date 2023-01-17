using System;
using System.Collections.Generic;
using System.Text;

namespace TypewiseAlert.Model
{
    public class SampleData
    {
        public int lowerLimit { get; set; }
        public int upperLimit { get; set; }

        public override bool Equals(object obj)
        {
            return this.upperLimit == ((SampleData)obj).upperLimit;
        }
        
    }
}
