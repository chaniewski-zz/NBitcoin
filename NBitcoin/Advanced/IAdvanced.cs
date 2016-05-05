using System.Collections.Generic;
using NBitcoin.Internal;

namespace NBitcoin.Advanced
{
    public interface IAdvanced
    {
        Response<string> AddMultisigAddress(int numberOfSignaturesRequired, string[] keys, string account = null, string id = null);
        Response<string> AddNode(string node, AddNodeOperation operation, string id = null);
        Response<CreateMultiSig> CreateMultiSig(int numberOfSignaturesRequired, string[] keys, string id = null);
        Response<string> CreateRawTransaction(TransactionOutput[] outputsToSpend, Dictionary<string, decimal> destinations, string id = null);
        Response<BitcoinTransaction> DecodeRawTransaction(string hexString, string id = null);
        Response<string> DumpPrivKey(string bitcoinAddress, string id = null);
        Response<NodeInfo[]> GetAddedNodeInfo(bool showConnectedInformation, string nodeAddress, string id = null);
        Response<BlockInfo> GetBlock(string blockHash, string id = null);
        Response<long> GetBlockCount(string id = null);
    }
}