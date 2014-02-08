using NBitcoin.Internal;

namespace NBitcoin.Advanced.Requests
{
    internal class AddMultisigAddressRequest
    {
        public int NumberOfSignaturesRequired { get; set; }

        public string[] Keys { get; set; }
        
        [OptionalParameter]
        public string Account { get; set; }
    }
}
