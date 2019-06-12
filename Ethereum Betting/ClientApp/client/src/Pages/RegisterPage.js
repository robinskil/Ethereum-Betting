import React, { Component } from "react";
import {ExportedRegisterForm} from '../Components/Forms/RegisterForm'

export class RegisterPage extends Component{
        constructor(props) {
        super(props);
        this.state = {
        }
    }
    render() {
        return (
           <div>
               <ExportedRegisterForm/>
            </div>
        )
   }
}

