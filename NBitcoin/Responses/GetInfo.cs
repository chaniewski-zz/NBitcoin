namespace NBitcoin
{
    public class GetInfo
    {
        public long Version { get; set; }
        public long ProtocolVersion { get; set; }
        public long WalletVersion { get; set; }
        public decimal Balance { get; set; }
        public long Blocks { get; set; }
        public int TimeOffset { get; set; }
        public long Connections { get; set; }
        public string Proxy { get; set; }
        public decimal Difficulty { get; set; }
        public bool TestNet { get; set; }
        public long KeyPoolOldest { get; set; }
        public long KeyPoolSize { get; set; }
        public decimal PayTxFee { get; set; }
        public string Errors { get; set; }
    }
}
