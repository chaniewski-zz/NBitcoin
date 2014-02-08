using System.Collections.Generic;
using NBitcoin.Advanced.Requests;
using NBitcoin.Internal;

namespace NBitcoin.Advanced
{
    internal class Advanced : IAdvanced
    {
        public Response<string> AddMultisigAddress(int numberOfSignaturesRequired, string[] keys, string account = null, string id = null)
        {
            var request = Request.FromObject(new AddMultisigAddressRequest
            {
                NumberOfSignaturesRequired = numberOfSignaturesRequired,
                Keys = keys,
                Account = account
            }, id);

            return _jsonRpcClient.InvokeMethod<Response<string>>(request);
        }

        public Response<string> AddNode(string node, AddNodeOperation operation, string id = null)
        {
            var request = Request.FromObject(new AddNodeRequest { Node = node, Operation = operation }, id);
            return _jsonRpcClient.InvokeMethod<Response<string>>(request);
        }
        
        public Response<CreateMultiSig> CreateMultiSig(int numberOfSignaturesRequired, string[] keys, string id = null)
        {
            var request = Request.FromObject(new CreateMultiSigRequest
            {
                NumberOfSignaturesRequired = numberOfSignaturesRequired,
                Keys = keys
            }, id);
            return _jsonRpcClient.InvokeMethod<Response<CreateMultiSig>>(request);
        }

        public Response<string> CreateRawTransaction(TransactionOutput[] outputsToSpend, Dictionary<string, decimal> destinations, string id = null)
        {
            var request = Request.FromObject(new CreateRawTransactionRequest
            {
                OutputsToSpend = outputsToSpend,
                Destinations = destinations
            }, id);
            return _jsonRpcClient.InvokeMethod<Response<string>>(request);
        }

        public Response<BitcoinTransaction> DecodeRawTransaction(string hexString, string id = null)
        {
            var request = Request.FromString("decoderawtransaction", hexString, id);
            return _jsonRpcClient.InvokeMethod<Response<BitcoinTransaction>>(request);
        }

        public Response<string> DumpPrivKey(string bitcoinAddress, string id = null)
        {
            var request = Request.FromString("dumpprivkey", bitcoinAddress, id);
            return _jsonRpcClient.InvokeMethod<Response<string>>(request);
        }

        public Response<NodeInfo[]> GetAddedNodeInfo(bool showConnectedInformation, string nodeAddress, string id = null)
        {
            var request = Request.FromObject(new GetAddedNodeInfoRequest { Dns = showConnectedInformation, Node = nodeAddress }, id);
            return _jsonRpcClient.InvokeMethod<Response<NodeInfo[]>>(request);
        }

        private readonly IJsonRpcClient _jsonRpcClient;

        public Advanced(IJsonRpcClient jsonRpcClient)
        {
            _jsonRpcClient = jsonRpcClient;
        }
    }
}
