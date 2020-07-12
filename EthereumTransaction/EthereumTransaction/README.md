This project is developed with .NET core for back end and React for from end.

In react used the Home Component to implement the search functionality by Address and Block number.
This Component just making a API call to server to retrive the transaction by Address and Block number.

Created a EthereumTransaction Controller with a HTTPGET method returns List of transaction.

Controller make the API call to https://mainnet.infura.io/v3  and retrive the transactions.
method eth_getBlockByNumber is used to make rpc .  
https://infura.io/docs/ethereum/json-rpc/eth-getBlockByNumber

using .NET core inbuild dependancy injection container to resolve the dependancies.

