using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBitcoin.Advanced
{
    public class BlockInfo
    {
        public string Hash { get; set; }
        public long Confirmations { get; set; }
        public int Size { get; set; }
        public int Height { get; set; }
        public int Version { get; set; }
        public string MerkleRoot { get; set; }
        public string[] Tx { get; set; }
        public long Time { get; set; }
        public long Nonce { get; set; }
        public string Bits { get; set; }
        public decimal Difficulty { get; set; }
        public string PreviousBlockHash { get; set; }
    }
}
