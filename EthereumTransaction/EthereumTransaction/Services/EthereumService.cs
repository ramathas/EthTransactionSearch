using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Numerics;
using System.Threading.Tasks;

namespace EthereumTransaction.Services
{
    public class EthereumService : IEthereumService
    {
        private readonly IConfiguration Configuration;
        private string Ethereum_Project_ID;
        private string Ethereum_Base_URL;
        public EthereumService(IConfiguration configuration)
        {
            Configuration = configuration;
            Ethereum_Project_ID = Configuration["Ethereum_Project_ID"];
            Ethereum_Base_URL = configuration["Ethereum_Base_URL"];
        }

        public async Task<IEnumerable<Transaction>> GetTransactionByAddressAndBlock(int blockNumber, string address)
        {
            List<Transaction> transactions = new List<Transaction>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Ethereum_Base_URL + "/" + Ethereum_Project_ID);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var request = new RPCRequest
                {
                    jsonrpc = "2.0",
                    method = "eth_getBlockByNumber",
                    @params = new object[] { $"0x{Convert.ToString(blockNumber, 16).ToUpper()}", true },
                    id = 1
                };

                string json = JsonConvert.SerializeObject(request, Formatting.None);
                var httpContent = new StringContent(json);

                HttpResponseMessage response = await client.PostAsync(client.BaseAddress, httpContent);
                var responseObj = JsonConvert.DeserializeObject<RPCResponse>(response.Content.ReadAsStringAsync().Result);
                                
                // possibly can consider automapper here.
                transactions = responseObj.result.transactions.Where(t => t.From == address).Select(t => new Transaction
                {
                    BlockHash = t.BlockHash,
                    BlockNumber = blockNumber,
                    Gas = Convert.ToInt64(t.Gas, 16).ToString(),
                    Hash = t.Hash,
                    From = t.From,
                    To = t.To,
                    Value = 0 //decimal.Divide(Convert.ToInt64(t.Value, 16) , 1000000000000000000) // value in response is converted to Wei
                }).ToList();                
            }

            return transactions;
        }
    }
}
