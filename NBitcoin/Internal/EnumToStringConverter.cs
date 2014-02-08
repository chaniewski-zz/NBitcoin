using System;

namespace NBitcoin.Internal
{
    public class EnumToStringConverter : IConverter
    {
        public string Convert(object value)
        {
            var @enum = value as Enum;
            if (@enum == null)
                return null;

            return value.ToString().ToLower();
        }
    }
}
