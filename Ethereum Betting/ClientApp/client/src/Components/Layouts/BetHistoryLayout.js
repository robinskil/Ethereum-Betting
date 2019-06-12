import React from "react";
import {
    BrowserRouter as Router,
    Route,
    Link,
    withRouter
} from 'react-router-dom'
import * as userApi from '../../helpers/UserApi'
import Web3 from 'web3'

class BetHistoryLayout extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            rows: [            
                { betID: 1, created: '01-Jun-2019', end: '01-Jun-2019', stake: '1000',  result: "Won"},
                { betID: 2, created: '01-Jun-2019', end: '02-Jun-2019', stake: '1000', result: "Loss" },
                { betID: 3, created: '02-Jun-2019', end: '03-Jun-2019', stake: '15000', result: "Won" },
                { betID: 4, created: '03-Jun-2019', end: '05-Jun-2019', stake: '250', result: "Won" }
            ]
        }

        this.renderTableBody = this.renderTableBody.bind(this);
    }

    renderTableBody() {
        return this.state.rows.map((bet, index) => {
            const { betID, created, end, stake, result } = bet
            return (
               <tr key={betID}>
                  <td>{betID}</td>
                  <td>{created}</td>
                  <td>{end}</td>
                  <td>{stake}</td>
                  <td>{result}</td>
               </tr>
            )
         })
    }

    render() {
        return (
            <div className="jumbotron" style={{ padding: "2rem" }}>
            <h1 className="display-4">Bet history</h1>
            <thead classNameName="thead-dark"></thead>
            <table  id='bets' className="table">
                <thead classNameName="thead-dark">
                    <tr>
                    <th scope="col">Bet Adress</th>
                    <th scope="col">Created</th>
                    <th scope="col">Ends</th>
                    <th scope="col">Stake</th>
                    <th scope="col">Result</th>
                    </tr>
                </thead>
               <tbody>
                  {this.renderTableBody()}
               </tbody>
            </table>
            </div>
        );
    }
}

export const ExportedBetHistoryLayout = withRouter(BetHistoryLayout);