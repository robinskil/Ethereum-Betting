import React from "react";
import {
    withRouter
} from 'react-router-dom'

class FriendsLayout extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            rows: [            
                { id: 1, username: 'Antonijn' },
                { id: 2, username: 'Robijn' },
                { id: 3, username: 'Sin(θ) = dee' },
                { id: 4, username: 'Stefano' },
                { id: 5, username: 'Marijuana' }
            ]
        }

        this.renderTableBody = this.renderTableBody.bind(this);
    }

    renderTableBody() {
        return this.state.rows.map((friend, index) => {
            const { id, username } = friend
            return (
               <tr key={id}>
                  <td>{id}</td>
                  <td>{username}</td>
               </tr>
            )
         })
    }

    render() {
        return (
            <div className="jumbotron" style={{ padding: "2rem" }}>
            <h1 className="display-4">Friends</h1>
            <thead classNameName="thead-dark"></thead>
            <table  id='bets' className="table">
                <thead classNameName="thead-dark">
                    <tr>
                    <th scope="col">Id</th>
                    <th scope="col">Username</th>
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

export const ExportedFriendsLayout = withRouter(FriendsLayout);