import React from "react";
import {
    BrowserRouter as Router,
    Route,
    Link
} from 'react-router-dom'


export default class LoginIndex extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            inputUsername: "",
            inputPassword: ""
        }

        this.onChangeUsername = this.onChangeUsername.bind(this);
        this.onChangePassword = this.onChangePassword.bind(this);
    }

    onChangeUsername(event) {
        this.setState({ inputUsername: event.target.value });
    }

    onChangePassword(event) {
        this.setState({ inputPassword: event.target.value });
    }

    render() {
        return (
            <div>
                <div class="jumbotron" style={{ padding: "2rem" }}>
                    <h1 class="display-4">Login To Your Account</h1>
                    <p class="lead">To log in, enter your username and password below.</p>
                    <hr class="my-4" />
                        <form>
                            <div class="form-group">
                                <label for="validationServer01">Username</label>
                                <input type="text" class="form-control" id="validationServer01" value={this.state.inputUsername} onChange={this.onChangeUsername} required />
                                    <div class="invalid-feedback">
                                        Please fill in your username.
                                    </div>
                            </div>
                            <div class="form-group">
                                <label for="validationServer01">Password</label>
                                <input type="text" class="form-control" id="validationServer01" value={this.state.inputPassword} onChange={this.onChangePassword} required />
                                    <div class="invalid-feedback">
                                        Please fill in your password.
                                    </div>  
                            </div>                   
                    <hr class="my-4" />
                    <button type="submit" class="btn btn-primary">Log In</button>
                        </form>
                </div>
            </div>
        );
    }

}
