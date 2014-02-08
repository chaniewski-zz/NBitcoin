namespace NBitcoin.Advanced.Requests
{
    class CreateMultiSigRequest
    {
        public int NumberOfSignaturesRequired { get; set; }
        public string[] Keys { get; set; } 
    }
}
