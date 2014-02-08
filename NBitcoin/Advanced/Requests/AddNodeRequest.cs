using NBitcoin.Internal;

namespace NBitcoin.Advanced.Requests
{
    class AddNodeRequest
    {
        public string Node { get; set; }

        [ParamConverter(typeof(EnumToStringConverter))]
        public AddNodeOperation Operation { get; set; }
    }
}
