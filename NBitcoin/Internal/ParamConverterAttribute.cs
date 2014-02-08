using System;
using ServiceStack;

namespace NBitcoin.Internal
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    class ParamConverterAttribute : Attribute
    {
        public Type ConverterType { get; private set; }

        public ParamConverterAttribute(Type converterType)
        {
            ConverterType = converterType;
        }

        public string Convert(object value)
        {
            var converter = ConverterType.CreateInstance<IConverter>();
            return converter.Convert(value);
        }
    }
}
