import React, { Component } from "react";
import SimpleStorageContract from "../contracts/SimpleStorage.json";
import {CreateUser} from "../helpers/UserApi";
import * as userApi from "../helpers/UserApi";
import Web3 from "web3";
import {
    BrowserRouter as Router,
    Route,
    Link
} from 'react-router-dom'
import MenuBar from "../Components/MenuBar";
import { type } from "os";

export class ProfilePAge extends Component{
        constructor(props) {
        super(props);
        this.state = {
        }
    }

    render() {
        return (
            <div>
                <div className="jumbotron" style={{ padding: "2rem" }}>
                    <h1 className="display-4">Create your account</h1>
                    <p className="lead">Enter your username and your password to create your account.</p>
                    <hr className="my-4" />          
                </div>
                <form>
                    <div className="form-group">
                        <label for="username">Username</label>
                        <input type="username" className="form-control" id="username" 
                        value={this.state.userName} 
                        onChange={this.handleUserNameChange} 
                        disabled = {this.state.isActive} />
                    </div>
                    <div className="form-group form-check">
                            <input type="checkbox" className="form-check-input" id="checkbox" 
                            onChange={this.handleCheck} />
                            <label className="form-check-label" for="checkbox">Random Generated Username</label>
                    </div>
                    <div className="form-group">
                        <label for="password">Password</label>
                        <input type="password" className="form-control" id="password" 
                        value={this.state.password} 
                        onChange={this.handlePasswordChange} />
                    </div>
                    <div className="form-group">
                        <label for="confirmPassword">Confirm password</label>
                        <input type="password" className="form-control" id="confirmPassword" 
                        value={this.state.confirmPassword} 
                        onChange={this.handleConfirmPasswordChange} />
                    </div>
                    <button className="btn btn-primary" onClick={this.handleSubmit}>Register</button>
                </form>
            </div>
            )
   }
}