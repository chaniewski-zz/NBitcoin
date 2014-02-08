using System;

namespace NBitcoin.Internal
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    class OptionalParameterAttribute : Attribute
    {
    }
}
