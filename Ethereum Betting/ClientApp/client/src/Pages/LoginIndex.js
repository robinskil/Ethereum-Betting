import React from "react";
import {
    BrowserRouter as Router,
    Route,
    Link
} from 'react-router-dom'
import { ExportedLoginForm } from '../Components/Forms/LoginForm'
import { StateContext } from "../state";


export default class LoginIndex extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
        }
    }
    
    static contextType = StateContext;

    render() {
        const [
            {
              auth: { isAuthenticated }
            }
          ] = this.context;
        return (
            <div>
                {!isAuthenticated &&
                    <ExportedLoginForm />
                }
                {isAuthenticated &&
                    <h1>You are already logged in!</h1>
                }
            </div>
        );
    }

}


