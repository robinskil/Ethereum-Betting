import React from "react";
import {
    BrowserRouter as Router,
    Route,
    Link
} from 'react-router-dom'

export default class JoinBetPage extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            accounts: null,
            address: undefined,
            contract: null
        }
        this.onChangeAddress = this.onChangeAddress.bind(this);
        this.submitForm = this.submitForm.bind(this);
    }

    submitForm(event) {
        event.preventDefault();
        this.tryJoinBet();
    }
    
    onChangeAddress = (event) => {
        console.log(event.target.value);
        const address = event.target.value;
        this.setState({ address: address });
        //this.validateInput(address);
    }
    

    render() {
        return (
            <div>
                <div className="row justify-content-center slide-in-blurred-left">
                    <form onSubmit={this.submitForm}>
                        <div class="form-group">
                            <label for="validationServer01">Join bet by Address</label>
                            <input type="text" class="form-control is-invalid" id="joinInput" value={this.state.address} onChange={this.onChangeAddress} />
                            <div class="invalid-feedback" id="joinFeedback">
                                Please fill in an existing bet address.
                            </div>
                        </div>
                        <button className="btn btn-primary" id="joinButton" disabled>
                            Join
                        </button>
                    </form>
                </div>
            </div>
        )
    }
}
