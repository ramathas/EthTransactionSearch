using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EthereumTransaction.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace EthereumTransaction.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EthereumTransactionController : ControllerBase
    {

        private readonly ILogger<EthereumTransactionController> _logger;
        private IConfiguration _configuration;
        private IEthereumService _service;

        public EthereumTransactionController(ILogger<EthereumTransactionController> logger, IEthereumService service, IConfiguration config)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _configuration = config ?? throw new ArgumentNullException(nameof(config));
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]
        [Route("{blockNumber}/{address}")]
        public async Task<IEnumerable<Transaction>> Get(int blockNumber, string address)
        {            
            var returnValue = await _service.GetTransactionByAddressAndBlock(blockNumber, address);
            return returnValue;           
        }        
    }
}