namespace NBitcoin.Advanced
{
    public class TransactionOutputInfo : TransactionOutput
    {
        public ScriptSignature ScriptSig { get; set; }
        public decimal? Sequence { get; set; }
    }
}
