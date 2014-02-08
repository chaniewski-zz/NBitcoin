namespace NBitcoin.Requests
{
    internal class ValidateAddressRequest
    {
        public string BitcoinAddress { get; set; }

        public ValidateAddressRequest(string bitcoinAddress)
        {
            BitcoinAddress = bitcoinAddress;
        }
    }
}
