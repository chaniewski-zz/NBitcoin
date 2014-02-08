using System.Linq;

namespace NBitcoin.Internal
{
    class StringArrayToStringConverter : IConverter
    {
        public string Convert(object value)
        {
            var input = value as string[];
            if (input == null || input.Length == 0)
            {
                return "[]";
            }

            return "[" + string.Join(",", input.Select(v => "\"" + v + "\"")) + "]";
        }
    }
}
