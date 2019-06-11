import React from "react";
import {
    BrowserRouter as Router,
    Route,
    Link,
    withRouter
} from 'react-router-dom'
import * as userApi from '../../helpers/UserApi'
import Web3 from 'web3'
import {Card} from '../Card/Card'

class ProfileLayout extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
        }
    }

    render() {
        return (
            <div>
                <div class="row">
                    <div className="profile-card card text-center" style={{width: "15rem", height: "10rem"}}>
                    <div className="card-header">
                    <h3 className="card-title">Total Bets</h3>
                    </div>
                    <div className="card-body">
                        <h5 className="card-title">15</h5>
                    </div>
                    </div>

                    <div className="profile-card card text-center" style={{width: "15rem", height: "10rem"}}>
                    <div className="card-header">
                    <h3 className="card-title">Won Bets</h3>
                    </div>
                    <div className="card-body">
                        <h5 className="card-title">10</h5>
                    </div>
                    </div>

                    <div className="profile-card card text-center" style={{width: "15rem", height: "10rem"}}>
                    <div className="card-header">
                    <h3 className="card-title">Lost Bets</h3>
                    </div>
                    <div className="card-body">
                        <h5 className="card-title">5</h5>
                    </div>
                    </div>

                    <div className="profile-card card text-center" style={{width: "15rem", height: "10rem"}}>
                    <div className="card-header">
                    <h3 className="card-title">Bet Win/Lose Ratio</h3>
                    </div>
                    <div className="card-body">
                        <h5 className="card-title">2</h5>
                    </div>
                    </div>

                    <div className="profile-card card text-center" style={{width: "15rem", height: "10rem"}}>
                    <div className="card-header">
                    <h3 className="card-title">Total amount won</h3>
                    </div>
                    <div className="card-body">
                        <h5 className="card-title">13000</h5>
                    </div>
                    </div>

                    <div className="profile-card card text-center" style={{width: "15rem", height: "10rem"}}>
                    <div className="card-header">
                    <h3 className="card-title">Total amount lost</h3>
                    </div>
                    <div className="card-body">
                        <h5 className="card-title">400</h5>
                    </div>
                    </div>
                </div>
            </div>
        );
    }
}

export const ExportedProfileLayout = withRouter(ProfileLayout);