using NBitcoin.Advanced;
using NBitcoin.Internal;

namespace NBitcoin
{
    public interface IBitcoinClient
    {
        string LastRequestJson { get; }
        Response<Empty> BackupWallet(string targetPath, string id = null);
        Response<GetInfo> GetInfo(string id = null);
        Response<string> GetNewAddress(string account = null, string id = null);
        Response<ValidateAddress> ValidateAddress(string bitcoinAddress, string id = null);
        IAdvanced Advanced { get; }
        Response<Empty> EncryptWallet(string passphrase, string id = null);
        Response<string> GetAccount(string bitcoinAddress, string id = null);
        Response<string> GetAccountAddress(string account, string id = null);
        Response<string[]> GetAddressesByAccount(string account, string id = null);
        Response<decimal?> GetTotalBalance(string id = null);
        Response<decimal?> GetAccountBalance(string account, int? minConfirmations = null, string id = null);
    }
}