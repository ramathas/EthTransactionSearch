using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthereumTransaction.Services
{
    public class TransactionFromRPC
    {
        public string BlockHash { get; set; }
        public string BlockNumber { get; set; }
        public string Gas { get; set; }
        public string Hash { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Value { get; set; }
    }
}
