import React, { Component } from "react";
import * as userApi from "../../helpers/UserApi";
import Web3 from "web3";
import {
    withRouter
} from 'react-router-dom'



class RegisterForm extends Component {
    constructor(context) {
        super(context);
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

    handleUserNameChange(event) {
        this.setState({ 
            userName: event.target.value
        });
    }

    checkUserName(event) {
        let username = event.target.value
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
    
    async handleSubmit(event) {
        event.preventDefault()
        let userAdress = this.state.accounts[0];
        let userPassword = this.state.password;
        let userName = this.state.userName;
        var charNumberRegex = /^[a-zA-Z0-9-]+$/;

        if(this.state.confirmPassword != this.state.password || userPassword == null)
        {
            alert("Password should be the same in both fields!");
        } 
        else if(this.state.isActive == true && userAdress != null && userPassword != null)
        {
            let createUser = await userApi.CreateUser(userAdress, userPassword);
            alert(createUser.msg);

            console.log(createUser.success);
            if(createUser.success)
            {
                console.log(createUser.success);
                this.props.history.push('/Login')
            }       
        }
        else if(this.state.isActive == false && userAdress != null && userPassword != null)
        {
            if(userName != null && !userName.match(charNumberRegex))
            {
                alert("Username and/or password should only exist of letters and numbers and '-'");
            }
            else 
            {
                let createUser = await userApi.CreateUser(userAdress, userPassword, userName);
                alert(createUser.msg);

                console.log(createUser.success);
                if(createUser.success)
                {
                    console.log(createUser.success);
                    this.props.history.push('/Login')
                }         
            }
            
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
                    <input type="username" className="form-control" id="username" 
                    value={this.state.userName} 
                    onChange={this.handleUserNameChange} 
                    onBlur={this.checkUserName}
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

export const ExportedRegisterForm = withRouter(RegisterForm);