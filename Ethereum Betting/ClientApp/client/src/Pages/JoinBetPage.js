import React from "react";
import {
    BrowserRouter as Router,
    Route,
    Link
} from 'react-router-dom'

export default class JoinBetPage extends React.Component {

    render() {
        return (
            <div class="jumbotron" style={{ padding: "2rem" }}>
                <h1 class="display-4">Search For Bets</h1>
                <p class="lead">Search and join bets by address.</p>
                <hr class="my-4" />
                <form class="search_form">
                    <p class="lead" label for="betAddress">Bet Address</p>
                    <input id="betAddress" name="betAdress" type="text" />
                </form>
                <Link style={{ marginTop: "30px" }} class="btn btn-primary" to="/LearnMore" role="button">Learn more</Link>
            </div>

        );
    }
}