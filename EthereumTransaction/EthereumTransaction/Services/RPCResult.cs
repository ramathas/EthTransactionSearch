using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthereumTransaction.Services
{
    public class RPCResult
    {
        public TransactionFromRPC[] transactions { get; set; }
    }
}
