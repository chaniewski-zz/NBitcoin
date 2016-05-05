using System;
using NBitcoin.Internal;

namespace NBitcoin.Requests
{
    class GetBalanceRequest
    {
        [OptionalParameter]
        public string Account { get; private set; }
        
        [OptionalParameter]
        public int? Minconf { get; private set; }

        public GetBalanceRequest()
        {
        }

        public GetBalanceRequest(string account, int? minConfirmations = null)
        {
            Account = account;
            Minconf = minConfirmations;
        }
    }
}
