import React, { Component } from 'react';
import TextField from 'material-ui/TextField';

export class Home extends Component {
  static displayName = Home.name;

    constructor(props) {
        super(props);
        this.state = { transactions: [], blockNumber:"" , address:"", ValidationError: "", loading: true };
    }

    static renderTransactionsTable(transactions) {
        return ( 
            
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Block Hash</th>
                        <th>Block Number</th>
                        <th>Gas</th> 
                        <th>Hash</th>
                        <th>From</th>
                        <th>To</th>
                        <th>Value</th>
                        
                    </tr>
                </thead>
                <tbody>
                        {transactions.map(transaction =>
                            <tr key={transaction.blockHash}>
                             <td>{transaction.blockHash}</td>
                            <td>{transaction.blockNumber}</td>
                                <td>{transaction.gas}</td>
                                <td>{transaction.hash}</td>
                            <td>{transaction.from}</td>
                            <td>{transaction.to}</td>
                            <td>{transaction.value}</td>
                        </tr>
                    )}
                </tbody>
                </table>              
                
        );
    }
    render() {

        let contents = this.state.loading
            ? <p><em></em></p>
            : Home.renderTransactionsTable(this.state.transactions);

        return (
          <div>
            <h1>Ethereum Transaction</h1>
                <p>Search the Transaction by Block Number and Address:</p>
                <p aria-live="polite">Enter Block Number: </p>
                <input value={this.state.blockNumber} onChange={event => this.setState({ blockNumber: event.target.value })} placeholder="Block Number" />
                <p > </p>               
                <p aria-live="polite">Address: </p>
                <input value={this.state.address} onChange={event => this.setState({ address: event.target.value })}  placeholder="Address" />
                <p > </p>
                <p aria-live="polite"> <strong>{this.state.ValidationError}</strong></p>
                
                <button className="btn btn-primary" onClick={async () => await this.SearchTrans()} > Search </button>
                <br/>
                {contents}            
          </div>
        );
    }    


    async SearchTrans() {   
        if (this.state.blockNumber != null && this.state.blockNumber != '' && this.state.address != null && this.state.address != '') {
            this.setState({ ValidationError: '' });
            this.populateTransactionData();
        }
        else {
            this.setState({ ValidationError: 'Please enter address and Block number' });
            this.setState({ transactions: [] });
        }        
    }

    async populateTransactionData() {        
        const response = await fetch('EthereumTransaction' + '/' + this.state.blockNumber+'/' + this.state.address);
        const trans = await response.json();          
        this.setState({ transactions: trans, loading: false });
    }   
}
