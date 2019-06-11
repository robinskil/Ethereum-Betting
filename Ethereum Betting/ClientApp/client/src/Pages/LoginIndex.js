import React from "react";
import {
    BrowserRouter as Router,
    Route,
    Link
} from 'react-router-dom'
import { ExportedLoginForm } from '../Components/Forms/LoginForm'


export default class LoginIndex extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
        }
    }

    render() {
        return (
            <div>
                <ExportedLoginForm />
            </div>
        );
    }

}


