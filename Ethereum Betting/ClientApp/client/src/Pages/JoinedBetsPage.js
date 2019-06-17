import React, { Component } from "react";
import { Link } from 'react-router-dom'
import BettingFactory from "../contracts/BettingFactory.json";
import { instantiateContract, getBetAmount, getParticipators, joinBet, getWinnings, getWinners } from "../helpers/Bet";
import { getAllJoinedBets } from "../helpers/BettingFactory";
import PuzzleBet from "../contracts/PuzzleBet.json";

export default class JoinedBetsPage extends Component {

    constructor(props) {
        super(props);
        this.state = {
            accounts: null,
            factoryContract: null,
            loading: true
        }
        this.loadingAccountDetails = this.loadingAccountDetails.bind(this);
    }

    componentDidMount = async () => {
        this.loadingAccountDetails();
    }
    loadingAccountDetails = async () => {
        try {
            const web3 = this.props.web3;
            const accounts = await web3.eth.getAccounts();
            const networkId = await web3.eth.net.getId();
            const deployedNetwork = BettingFactory.networks[networkId];
            const instance = new web3.eth.Contract(
                BettingFactory.abi,
                deployedNetwork && deployedNetwork.address,
            );
            this.setState({ accounts, factoryContract: instance });
        }
        catch (error) {
            alert(error);
        }
        finally {
            this.setState({ loading: false });
        }
    }


    render() {
        if (this.state.loading) return (
            <div className="row justify-content-center">
                <div className="col-12">
                    <h3 style={{ textAlign: "center" }}>Make sure you are logged in onto metamask.</h3>
                </div>
                <div>
                    <div className="spinner-border text-primary" role="status">
                        <span className="sr-only">Loading...</span>
                    </div>
                </div>
            </div>
        )
        if (this.state.accounts == null || this.state.accounts[0] === undefined || this.state.factoryContract == null) {
            return (
                <div>
                    <p>Could not load any accounts , make sure you logged in onto metamask and have an account selected.</p>
                </div>
            )
        }
        return (
            <AllJoinedBets web3={this.props.web3} account={this.state.accounts[0]} factoryContract={this.state.factoryContract} />
        )
    }
}
class AllJoinedBets extends Component {
    constructor(props) {
        super(props)
        this.state = {
            loading: true,
            AllJoinedBets: null,
        }
    }

    componentDidMount = async () => {
        const bets = await getAllJoinedBets(this.props.factoryContract, this.props.account);
        this.setState({ AllJoinedBets: bets, loading: false });

        //const bets = await betApi.getMyBets();
        //this.setState({ bets, loading: false });
    }

    render() {
        if (this.state.loading) {
            return (
                <div>
                    Loading . . .
                </div>
            )
        }
        if (this.state.AllJoinedBets == null || this.state.AllJoinedBets.length < 1) {
            return (<div>
                No bets
            </div>
            )
        }


        return (

            <div>
                {this.state.AllJoinedBets.map(bet => {
                    return (
                        <BetInfo account={this.props.account} web3={this.props.web3} bet={bet} />

                    )
                })}
            </div>
        )
    }
}

class BetInfo extends Component {
    constructor(props) {
        super(props);
        this.state = {
            betAmount: null,
            participators: null,
            contract: null,
            canWithdraw: false
        }
        this.loadData = this.loadData.bind(this);
        this.loadData();
    }

    async loadData() {
        const instance = await instantiateContract(this.props.web3, PuzzleBet, this.props.bet);
        const betAmount = await getBetAmount(instance);
        const participators = await getParticipators(instance);
        console.log(this.props.bet);
        const winners = await getWinners(instance);
        let canWithdraw = false;
        //check if winners contains urself...
        console.log(winners);
        winners.forEach(element => {
            if (element == this.props.account) canWithdraw = true;
        });
        this.setState({ contract: instance, betAmount: betAmount, participators: participators, canWithdraw: canWithdraw });
    }

    withdrawMoney = async () => {
        const accounts = await this.props.web3.eth.getAccounts();
        await getWinnings(this.state.contract, accounts[0]);
        //await getWinnings(this.state.contract, await this.props.web3.eth.getAccounts()[0]);
    }

    render() {
        return (
            <div className="col-8" style={{ marginTop: "15px" }}>
                <div className="card bg-light mb-3">
                    <div className="card-body">
                        <h5 class="card-title">Puzzle Bet</h5>
                        <div className="tab-content" id="nav-tabContent">
                            <div className="tab-pane fade show active" id={"nav-main" + this.props.bet} role="tabpanel" aria-labelledby="nav-home-tab">
                                <h6 className="card-subtitle mb-2 text-muted" style={{ marginTop: "0px" }}>Contract Address: {this.props.bet}</h6>

                            </div>
                        </div>
                        <div style={{ marginTop: "15px" }}>
                            <Link to={"/puzzle/" + this.props.bet} className="btn btn-primary">
                                Go puzzle!
                            </Link>
                            {this.state.canWithdraw == true ? <button className="btn btn-primary" onClick={this.withdrawMoney} style={{ marginLeft: "15px" }}>
                                Try to withdraw winnings
                            </button> : null}

                        </div>
                    </div>
                </div>
            </div>
        )
    }
}

