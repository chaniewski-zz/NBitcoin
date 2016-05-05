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

        public Response<BlockInfo> GetBlock(string blockHash, string id = null)
        {
            var request = Request.FromString("getblock", blockHash, id);
            return _jsonRpcClient.InvokeMethod<Response<BlockInfo>>(request);
        }

        public Response<long> GetBlockCount(string id = null)
        {
            var request = Request.FromString("getblockcount", null, id);
            return _jsonRpcClient.InvokeMethod<Response<long>>(request);
        }

        //public Response<string> GetBlockHash(string index)
        //{
            
        //}

        //public Response<BlockData> GetBlockTemplate()
        //{
            
        //}

        public Response<int> GetConnectionCount(string id = null)
        {
            var request = Request.FromString("getconnectioncount", id);
            return _jsonRpcClient.InvokeMethod<Response<int>>(request);
        }

        public Response<decimal> GetDifficulty(string id = null)
        {
            var request = Request.FromString("getdifficulty", id);
            return _jsonRpcClient.InvokeMethod<Response<decimal>>(request);
        }

        public Response<bool> GetGenerate(string id = null)
        {
            var request = Request.FromString("getgenerate", id);
            return _jsonRpcClient.InvokeMethod<Response<bool>>(request);
        }

        public Response<decimal> GetHashesPerSec(string id = null)
        {
            var request = Request.FromString("gethashespersec", id);
            return _jsonRpcClient.InvokeMethod<Response<decimal>>(request);
        }

        private readonly IJsonRpcClient _jsonRpcClient;

        public Advanced(IJsonRpcClient jsonRpcClient)
        {
            _jsonRpcClient = jsonRpcClient;
        }
    }
}
