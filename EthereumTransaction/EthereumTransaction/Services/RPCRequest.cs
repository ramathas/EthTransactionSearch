using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthereumTransaction.Services
{
    /// <summary>
    /// this is model class to make the request to https://mainnet.infura.io/v3
    /// </summary>
    public class RPCRequest
    {
        public string jsonrpc { get; set; }
        public string method { get; set; }

        public object[] @params { get; set; }

        public int id { get; set; }
    }
}
