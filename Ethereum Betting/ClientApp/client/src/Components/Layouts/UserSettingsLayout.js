import React from "react";
import {
    BrowserRouter as Router,
    Route,
    Link,
    withRouter
} from 'react-router-dom'
import * as userApi from '../ApiHelpers/UserApi'
import Web3 from 'web3'

class UserSettingsLayout extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            accounts: null,
            oldPassword: "",
            newPassword: "",
            confirmNewPassword: "",
            deletePassword: ""
        }

        this.handleOldPasswordChange = this.handleOldPasswordChange.bind(this);
        this.handleNewPasswordChange = this.handleNewPasswordChange.bind(this);
        this.handleConfirmNewPasswordChange = this.handleConfirmNewPasswordChange.bind(this);
        this.handleDeletePasswordChange = this.handleDeletePasswordChange.bind(this);
        this.onChangePasswordSubmit = this.onChangePasswordSubmit.bind(this);
        this.onDeleteSubmit = this.onDeleteSubmit.bind(this);
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
    
    handleOldPasswordChange(event) {
        this.setState({ 
            oldPassword: event.target.value
        });
    }

    handleNewPasswordChange(event) {
        this.setState({
            newPassword: event.target.value
        })
    }

    handleConfirmNewPasswordChange(event) {
        this.setState({
            confirmNewPassword: event.target.value
        })
    }

    handleDeletePasswordChange(event) {
        this.setState({
            deletePassword: event.target.value
        })
    }
    
    async onChangePasswordSubmit(event) {
        event.preventDefault()
        if(this.state.oldPassword == "")
        {
            alert("Field(s) must not be empty!!")
        }
        else if(this.state.newPassword.length < 6)
        {
            alert("Password must be at least 6 characters long!")
        }
        else if(this.state.oldPassword == this.state.newPassword)
        {
            alert("Please use a new password!")
        }
        else if (this.state.newPassword != this.state.confirmNewPassword)
        {
            alert("Passwords must match!")
        }
        else 
        {
            let address = this.state.accounts[0];
            let oldPassword = this.state.oldPassword;
            let newPassword = this.state.newPassword;
            let ChangePassword = await userApi.ChangePassword(address, oldPassword, newPassword);
            if(ChangePassword.success)
            {
                this.props.history.push('/Profile');
                alert(ChangePassword.msg)
            }
            else{
                alert(ChangePassword.msg)
            }
        }
    }

    async onDeleteSubmit(event) {
        event.preventDefault()
        if(this.state.deletePassword == "")
        {
            alert("Field must not be empty!")
        } 
        else
        {
            let address = this.state.accounts[0];
            let password = this.state.deletePassword;
            let DeleteUser = await userApi.DeleteUser(address, password);
            if(DeleteUser.success)
            {
                this.props.history.push('/');
                alert(DeleteUser.msg);  
            }
            else
            {
                alert(DeleteUser.msg);  
            }
        } 
    }

    render() {
        return (
            <div>
            <div class="jumbotron" style={{ padding: "2rem" }}>
            <h1 class="display-4">Change password</h1>
            <p class="lead">Please fill in your old password and your new password.</p>
            <hr class="my-4" />
            <form>
                <div class="form-group">
                    <label for="validationServer01">Old password</label>
                    <input type="password" class="form-control" id="validationServer01" value={this.state.oldPassword} onChange={this.handleOldPasswordChange} required />
                    <div class="invalid-feedback">
                        Please fill in your password.
                    </div>
                    <label for="validationServer01">New password</label>
                    <input type="password" class="form-control" id="validationServer01"  value={this.state.newPassword} onChange={this.handleNewPasswordChange} required />
                    <div class="invalid-feedback">
                        Please fill in your password.
                    </div>
                    <label for="validationServer01">Confirm new password</label>
                    <input type="password" class="form-control" id="validationServer01" value={this.state.confirmNewPassword} onChange={this.handleConfirmNewPasswordChange} required />
                    <div class="invalid-feedback">  
                        Please fill in your password.
                    </div>
                    <hr class="my-4"/>   
                    <button className="btn btn-primary" onClick={this.onChangePasswordSubmit} >Change Password</button>
                </div>                       
            </form>
            </div>

            <div class="jumbotron" style={{ padding: "2rem" }}>
            <h1 class="display-4">Delete Account</h1>
            <p class="lead"> Fill in your password to delete your account.</p>
            <hr class="my-4" />
            <form>
                <div class="form-group">
                    <label for="validationServer01">Password</label>
                    <input type="password" class="form-control" id="validationServer01" value={this.state.deletePassword} onChange={this.handleDeletePasswordChange} required />
                    <div class="invalid-feedback">
                        Please fill in your password.
                    </div>
                    <hr class="my-4"/>  
                    <button className="btn btn-primary" onClick={this.onDeleteSubmit} >Delete User</button>
                </div>                       
            </form>
            </div>
        </div>
        );
    }
}

export const ExportedUserSettingsLayout = withRouter(UserSettingsLayout);