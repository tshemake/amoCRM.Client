using System;
using System.Collections.Generic;
using System.Text;

namespace amoCRM.Library.Helpers
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class ParameterAttribute : Attribute
    {
        public ParameterAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; protected set; }
    }
}
