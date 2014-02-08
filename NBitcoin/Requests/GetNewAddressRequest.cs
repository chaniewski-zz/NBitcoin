using NBitcoin.Internal;

namespace NBitcoin.Requests
{
    class GetNewAddressRequest
    {
        [OptionalParameter]
        public string Account { get; set; }
    }
}
