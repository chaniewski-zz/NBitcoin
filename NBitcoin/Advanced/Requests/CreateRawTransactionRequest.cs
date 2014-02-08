using System.Collections.Generic;

namespace NBitcoin.Advanced.Requests
{
    class CreateRawTransactionRequest
    {
        public TransactionOutput[] OutputsToSpend { get; set; }
        public Dictionary<string, decimal> Destinations { get; set; }
    }
}
