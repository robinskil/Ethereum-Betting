import React from "react";
import {
    BrowserRouter as Router,
    Route,
    Link,
    withRouter
} from 'react-router-dom'
import * as userApi from '../ApiHelpers/UserApi'
import Web3 from 'web3'

class AchievementsLayout extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
        }

    }


    render() {
        return (
            <div className="jumbotron" style={{ padding: "2rem" }}>
            <h1 className="display-4">Achievements</h1>
            <thead classNameName="thead-dark"></thead>
            <table  id='bets' className="table">
                <thead classNameName="thead-dark">
                    <tr>
                    </tr>
                </thead>
               <tbody>
               </tbody>
            </table>
            </div>
        );
    }
}

export const ExportedAchievementsLayout = withRouter(AchievementsLayout);