namespace NBitcoin.Advanced
{
    public class NodeInfo
    {
        public string AddedNode { get; set; }
        public bool? Connected { get; set; }
        public AddressInfo[] Addresses { get; set; }
    }
}
