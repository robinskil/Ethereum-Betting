import React, { Component } from "react";
import SimpleStorageContract from "../contracts/SimpleStorage.json";
import getWeb3 from "../utils/getWeb3";
import {
    BrowserRouter as Router,
    Route,
    Link,
    NavLink
} from 'react-router-dom'
import { ExportedMenuBar } from "../Components/MenuBar";
import CreateBet from "../Pages/CreateBetPage";
import BetChatComponent from "../Chatting/BetChatComponent";
import PuzzlePage from "../Pages/PuzzlePage";
import FriendChat from "../Chatting/FriendChat";
import { ViewBetsPage } from "./ViewBetsPage.js";
import { FriendPage } from "./FriendPage.js";

import LoginIndex from "../Pages/LoginIndex";
import JoinBetPage from "../Pages/JoinBetPage";
import { RegisterPage } from "./RegisterPage.js";
import { ProfilePage } from "./ProfilePage.js";


class Wrapper extends Component {
    state = { storageValue: 0, web3: null, accounts: null, contract: null };

    componentDidMount = async () => {
        try {
            // Get network provider and web3 instance.
            const web3 = await getWeb3();

            // Use web3 to get the user's accounts.
            const accounts = await web3.eth.getAccounts();

            // Get the contract instance.
            const networkId = await web3.eth.net.getId();
            const deployedNetwork = SimpleStorageContract.networks[networkId];
            const instance = new web3.eth.Contract(
                SimpleStorageContract.abi,
                deployedNetwork && deployedNetwork.address,
            );

            // Set web3, accounts, and contract to the state, and then proceed with an
            // example of interacting with the contract's methods.
            this.setState({ web3, accounts, contract: instance }, this.runExample);
        } catch (error) {
            // Catch any errors for any of the above operations.
            alert(
                `Failed to load web3, accounts, or contract. Check console for details.`,
            );
            console.error(error);
        }
    };

    runExample = async () => {
        const { accounts, contract } = this.state;

        // Stores a given value, 5 by default.
        // await contract.methods.set(5).send({ from: accounts[0] });

        // Get the value from the contract to prove it worked.
        const response = await contract.methods.get().call();

        // Update state with the result.
        this.setState({ storageValue: response });
    };

    render() {
        if (!this.state.web3) {
            return <div>Loading Web3, accounts, and contract...</div>;
        }
        return (
            <div className="App">
                <Router>
                    <div className="container">
                        <ExportedMenuBar />
                        <Route exact path="/" component={IndexPage} />
                        <Route path="/about" component={null} />
                        <Route path="/topics" component={null} />
                        <Route exact path="/PuzzlePage" component={PuzzlePage} />



                        <Route path="/CreateBet" component={() => { return (<CreateBet web3={this.state.web3} />) }} />
                        <Route path="/view-bets" component={ViewBetsPage} />
                        <Route path="/friends" component={FriendPage} />

                        <Route path="/Login" component={() => { return (<LoginIndex web3={this.state.web3} />) }} />
                        <Route path="/JoinBet" component={() => { return (<JoinBetPage web3={this.state.web3} />) }} />
                        <Route path="/Register" component={() => { return (<RegisterPage web3={this.state.web3} />) }} />
                        <Route path="/Profile" component={() => { return (<ProfilePage web3={this.state.web3} />) }} />

                    </div>
                </Router>


                <BetChatComponent betAddress={"123"} web3={this.state.web3} />
                <FriendChat/>
            </div>
        );
    }
}

class IndexPage extends Component {
    render() {

        return (
            <div class="jumbotron" style={{ padding: "2rem" }}>
                <h1 class="display-3">Welcome to Ethereum Betting!</h1>
                <p class="lead">Fully anonymous betting in your own control.</p>
                <hr class="my-4" />
                <div className="row justify-content-center">
                    <img width="50%" src="https://en.bitcoinwiki.org/upload/en/images/7/7a/Ethereum11.png" />
                </div>
                <Link style={{ marginTop: "30px" }} class="btn btn-primary" to="/LearnMore" role="button">Learn more</Link>
            </div>
        );
    }

}

export default Wrapper;
