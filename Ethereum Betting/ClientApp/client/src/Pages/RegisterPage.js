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

export class RegisterPage extends Component{
        constructor(props) {
        super(props);
        this.state = {
        }
    }

    render() {
        return (
           <div>
               <RegisterForm/>
            </div>
        )
   }
}

export class RegisterForm extends Component {
    constructor(props) {
        super(props);
        this.state = {
            isActive: false,
            userAdress: null,
            userName: null,
            password: null,
            confirmPassword: null,
            accounts: null
        }

        this.loadingAccountDetails = this.loadingAccountDetails.bind(this);
        this.handleUserNameChange = this.handleUserNameChange.bind(this);
        this.handlePasswordChange = this.handlePasswordChange.bind(this);
        this.handleConfirmPasswordChange = this.handleConfirmPasswordChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleCheck = this.handleCheck.bind(this);
        this.testSubmit = this.testSubmit.bind(this);
    }

    componentDidMount = async () => {
        this.loadingAccountDetails();
    }

    loadingAccountDetails = async () => {
        try {
            const web3 = new Web3(Web3.givenProvider, null);
            const accounts = await web3.eth.getAccounts();
            this.setState({ accounts });
        }
        catch (error) {
            alert(error);
        }
        finally {
            this.setState({ loading: false });
        }
    }

    testSubmit (event) {
        event.preventDefault();
        alert("Accounts: " + this.state.accounts)
    }

    handleUserNameChange(event) {
        this.setState({ 
            userName: event.target.value
        });
    }

    handlePasswordChange(event) {
        this.setState({ 
            password: event.target.value
        });
    }

    handleConfirmPasswordChange(event) {
        this.setState({ 
            confirmPassword: event.target.value
        });
    }
    
    handleSubmit(event) {
        event.preventDefault()
        console.log('userValues: '  + this.state.accounts + ", " + this.state.isActive + ", " + this.state.userName + ", " + this.state.password + ", " + this.state.confirmPassword);
        let userAdress = this.state.accounts[0];
        let userPassword = this.state.password;
        console.log(userAdress + ", " + userPassword);
        if(this.state.confirmPassword != this.state.password)
        {
            alert("Password should be the same in both fields!");
        } else if(this.state.isActive == true && userAdress != null && userPassword != null){
            userApi.CreatUser(userAdress, userPassword);
        }

    }

    handleCheck(event){
        let isActive = event.target.checked;
        console.log(this.isActive);
        this.setState({
            isActive: isActive
        })
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
                    <input type="username" className="form-control" id="username" value={this.state.userName} onChange={this.handleUserNameChange} disabled = {this.state.isActive} />
                </div>
                <div className="form-group form-check">
                        <input type="checkbox" className="form-check-input" id="checkbox" onChange={this.handleCheck} />
                        <label className="form-check-label" for="checkbox">Random Generated Username</label>
                </div>
                <div className="form-group">
                    <label for="password">Password</label>
                    <input type="password" className="form-control" id="password" value={this.state.password} onChange={this.handlePasswordChange} />
                </div>
                <div className="form-group">
                    <label for="confirmPassword">Confirm password</label>
                    <input type="password" className="form-control" id="confirmPassword" color="#72A4D2" value={this.state.confirmPassword} onChange={this.handleConfirmPasswordChange} />
                </div>
                <div className="form-group form-check">
                        <input type="checkbox" className    ="form-check-input" id="exampleCheck1" />
                        <label className="form-check-label" for="exampleCheck1">I agree with <a href="/">the terms of agreement</a></label>
                </div>
                <button className="btn btn-primary" onClick={this.handleSubmit}>Register</button>
                <button className="btn btn-primary" onClick={this.testSubmit}>Get Accounts</button>
            </form>
        </div>
        )
    }
}