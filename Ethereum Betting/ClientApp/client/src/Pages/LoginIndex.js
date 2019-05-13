import React from "react";
import {
    BrowserRouter as Router,
    Route,
    Link
} from 'react-router-dom'


export default class LoginIndex extends React.Component {

    render() {
        return (
            <div>
                <div class="jumbotron" style={{ padding: "2rem" }}>
                    <h1 class="display-4">Login To Your Account</h1>
                    <p class="lead">To log in, enter your username and password below.</p>
                    <hr class="my-4" />
                </div>

                <form>
                    <div class="form-group">
                        <label for="exampleInputUsername1">Username</label>
                        <input type="username" class="form-control" id="exampleInputUsername1" aria-describedby="usernameHelp" placeholder="Enter Username" />
                        <small id="usernameHelp" class="form-text text-muted">We'll never share your address with anyone else.</small>
                    </div>

                    <div class="form-group">
                        <label for="exampleInputPassword1">Password</label>
                        <input type="password" class="form-control" id="exampleInputPassword1" placeholder="Password" />
                    </div>

                    <div class="form-group form-check">
                        <input type="checkbox" class="form-check-input" id="exampleCheck1" />
                        <label class="form-check-label" for="exampleCheck1">Check me out</label>
                    </div>

                    <button type="submit" class="btn btn-primary">Submit</button>
                </form>
            </div>







        );
    }

}
