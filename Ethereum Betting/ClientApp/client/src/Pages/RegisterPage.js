import React, { Component } from "react";
import SimpleStorageContract from "../contracts/SimpleStorage.json";
import getWeb3 from "../utils/getWeb3";
import {
    BrowserRouter as Router,
    Route,
    Link
} from 'react-router-dom'
import MenuBar from "../Components/MenuBar";

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
    render() {
        return (
        <div>
            <h2>Create your account</h2>
            <form>
                <div className="form-group">
                    <label for="email">Email</label>
                    <input type="text" className="form-control" id="email"/>
                </div>
                <div className="form-group">
                    <label for="password">Password</label>
                    <input type="password" className="form-control" id="password" />
                </div>
                <div className="form-group">
                    <label for="cpassword">Confirm password</label>
                    <input type="cpassword" className="form-control" id="cpassword" />
                </div>
                <button className="btn btn-primary">Register</button>
            </form>
        </div>
        )
    }
}