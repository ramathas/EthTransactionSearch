using System.Collections.Generic;
using System.Threading.Tasks;

namespace EthereumTransaction.Services
{
    public interface IEthereumService
    {
        Task<IEnumerable<Transaction>> GetTransactionByAddressAndBlock(int blockNumber, string address);
    }
}