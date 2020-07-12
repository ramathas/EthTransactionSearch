using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthereumTransaction.Services
{
    /// <summary>
    /// this is model class to receive the response from API https://mainnet.infura.io/v3
    /// </summary>
    public class RPCResponse
    {
        public string jsonrpc { get; set; }
        public int id { get; set; }
        public RPCResult result { get; set; }
    }
}
