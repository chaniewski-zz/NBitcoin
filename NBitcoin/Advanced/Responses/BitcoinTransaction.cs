namespace NBitcoin.Advanced
{
    public class BitcoinTransaction
    {
        public string Hex { get; set; }
        public string Txid { get; set; }
        public int Version { get; set; }
        public int Locktime { get; set; }
        public TransactionOutputInfo[] Vin { get; set; }
        public Destination[] Vout { get; set; }
    }
}
