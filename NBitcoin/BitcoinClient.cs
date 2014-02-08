using System.Configuration;
using NBitcoin.Advanced;
using NBitcoin.Configuration;
using NBitcoin.Internal;
using NBitcoin.Requests;

namespace NBitcoin
{
    public class BitcoinClient : IBitcoinClient
    {
        public string LastRequestJson { get; private set; }

        public IAdvanced Advanced { get; private set; }

        public Response<Empty> BackupWallet(string targetPath, string id = null)
        {
            var request = Request.FromObject(new BackupWalletRequest { TargetPath = targetPath }, id);
            return _jsonRpcClient.InvokeMethod<Response<Empty>>(request);
        }

        public Response<Empty> EncryptWallet(string passphrase, string id = null)
        {
            var request = Request.FromString("encryptwallet", passphrase, id);
            return _jsonRpcClient.InvokeMethod<Response<Empty>>(request);
        }

        public Response<string> GetAccount(string bitcoinAddress, string id = null)
        {
            var request = Request.FromString("getaccount", bitcoinAddress, id);
            return _jsonRpcClient.InvokeMethod<Response<string>>(request);
        }

        public Response<string> GetAccountAddress(string account, string id = null)
        {
            var request = Request.FromString("getaccountaddress", account, id);
            return _jsonRpcClient.InvokeMethod<Response<string>>(request);
        }

        public Response<string[]> GetAddressesByAccount(string account, string id = null)
        {
            var request = Request.FromString("getaddressesbyaccount", account, id);
            return _jsonRpcClient.InvokeMethod<Response<string[]>>(request);
        }

        public Response<GetInfo> GetInfo(string id = null)
        {
            var request = Request.FromObject(new GetInfoRequest(), id);
            return _jsonRpcClient.InvokeMethod<Response<GetInfo>>(request);
        }

        public Response<string> GetNewAddress(string account = null, string id = null)
        {
            var request = Request.FromObject(new GetNewAddressRequest {Account = account}, id);
            return _jsonRpcClient.InvokeMethod<Response<string>>(request);
        }

        public Response<ValidateAddress> ValidateAddress(string bitcoinAddress, string id = null)
        {
            var request = Request.FromObject(new ValidateAddressRequest(bitcoinAddress), id);
            return _jsonRpcClient.InvokeMethod<Response<ValidateAddress>>(request);
        }

        private readonly IJsonRpcClient _jsonRpcClient;

        private static readonly NBitcoinSection Config = (NBitcoinSection) ConfigurationManager.GetSection("nBitcoin");

        public BitcoinClient(IJsonRpcClient jsonRpcClient = null) : this(Config.User, Config.Password, Config.Host, Config.Port, jsonRpcClient)
        { }

        public BitcoinClient(string user, string password, IJsonRpcClient jsonRpcClient = null)
            : this(user, password, "http://127.0.0.1", 8332, jsonRpcClient)
        { }

        public BitcoinClient(string user, string password, string host, int port, IJsonRpcClient jsonRpcClient = null)
        {
            _jsonRpcClient = jsonRpcClient ??
                             new JsonRpcHttpClient(user, password, host, port, json => LastRequestJson = json);
            Advanced = new Advanced.Advanced(_jsonRpcClient);
        }
    }
}
