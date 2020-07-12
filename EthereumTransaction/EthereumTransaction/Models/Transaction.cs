using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthereumTransaction
{
    public class Transaction
    {
        public string BlockHash { get; set; }
        public int BlockNumber { get; set; }
        public string Gas { get; set; }
        public string Hash { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public decimal Value { get; set; }
        

    }
}
