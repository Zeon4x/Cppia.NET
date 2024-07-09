using System;
using System.Collections.Generic;
using System.Text;

namespace Cppia.NET
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum)]
    public class CppiaTypeAttribute : Attribute
    {
        public string? Name { get; }

        public CppiaTypeAttribute(string name)
        {
            Name = name;
        }

        public CppiaTypeAttribute() { }
    }
}
