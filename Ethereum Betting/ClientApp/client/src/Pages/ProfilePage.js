import React, { Component } from "react";
import SimpleStorageContract from "../contracts/SimpleStorage.json";
import * as userApi from "../Components/ApiHelpers/UserApi";
import Web3 from "web3";
import {
    BrowserRouter as Router,
    Route,
    Link
} from 'react-router-dom'
import { ExportedMenuBar } from "../Components/MenuBar";   
import { ExportedProfileLayout } from "../Components/Layouts/ProfileLayout";
import { ExportedBetHistoryLayout } from "../Components/Layouts/BetHistoryLayout";
import { ExportedAchievementsLayout } from "../Components/Layouts/AchievementsLayout.js";
import { ExportedUserSettingsLayout } from "../Components/Layouts/UserSettingsLayout";
import { type } from "os";
import { ExportedFriendsLayout } from "../Components/Layouts/FriendsLayout.js";


export class ProfilePage extends Component{
        constructor(props) {
        super(props);
        this.state = {
            layout: <ExportedProfileLayout/>
        }

        this.handleClick = this.handleClick.bind(this);
    }

    handleClick(event) {
        if(event.target.getAttribute('href') == "#profile")
        {
            this.setState({
                layout: <ExportedProfileLayout/>
            })
        }
        else if (event.target.getAttribute('href') == "#bethistory")
        {
            this.setState({
                layout: <ExportedBetHistoryLayout web3={this.props.web3}/>
            })
        }
        else if (event.target.getAttribute('href') == "#friends")
        {
            this.setState({
                layout: <ExportedFriendsLayout />
            })
        }
        else if (event.target.getAttribute('href') == "#achievements")
        {
            this.setState({
                layout: <ExportedAchievementsLayout/>
            })
        }
        else if (event.target.getAttribute('href') == "#usersettings")
        {
            this.setState({
                layout: <ExportedUserSettingsLayout/>
            })
        }

        this.render();
    }

    render() {
        return (
            <div>   
                <div class="row">
                        <div class="col-3">
                        <div class="list-group">
                        <a href="#profile" class="list-group-item list-group-item-action" onClick={this.handleClick}>Profile</a>
                        <a href="#bethistory" class="list-group-item list-group-item-action" onClick={this.handleClick}>Bet History</a>
                        <a href="#achievements" class="list-group-item list-group-item-action disabled" onClick={this.handleClick} >Achievements</a>
                        <a href="#friends" class="list-group-item list-group-item-action" onClick={this.handleClick} >Friends</a>
                        <a href="#usersettings" class="list-group-item list-group-item-action" onClick={this.handleClick}>User Settings</a>
                </div>
                </div>
                    <div class="col-9">
                        {this.state.layout}
                    </div>
                </div>
            </div>
            )
   }
}