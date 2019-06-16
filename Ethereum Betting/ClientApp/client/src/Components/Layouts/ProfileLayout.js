import React from "react";
import {
    BrowserRouter as Router,
    Route,
    Link,
    withRouter
} from 'react-router-dom'
import * as userApi from '../ApiHelpers/UserApi'
import Web3 from 'web3'
import BettingFactory from '../../contracts/BettingFactory.json'
import * as betFactory from "../../helpers/BettingFactory";
import * as betApi from '../../helpers/Bet'
import PuzzleBet from "../../contracts/PuzzleBet.json";
import {Card} from '../Card/Card'

class ProfileLayout extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            accounts: null,
            factoryContract: null,
            joinedBets: null,
            ownedBets: null,
            totalBets: null,
            wonBets: null,
            lostBets: null,
            loading: true,
            

        }
    }

    componentDidMount = async => {
        this.loadWeb3Properties();
    }

    loadWeb3Properties = async () => {
    try {
      const web3 = this.props.web3;
      const accounts = await web3.eth.getAccounts();
      const networkId = await web3.eth.net.getId();
      const deployedNetwork = BettingFactory.networks[networkId];
      const instance = new web3.eth.Contract(
        BettingFactory.abi,
        deployedNetwork && deployedNetwork.address
      );

      const joinedBets = await betFactory.getAllJoinedBets(instance, accounts[0]);
      const ownedBets = await betFactory.getOwnedBets(instance, accounts[0]);
      const totalBets = joinedBets.length;

      this.getJoinedBetsInfo(joinedBets, accounts[0])
  
      this.setState({ 
        accounts, 
        factoryContract: instance, 
        joinedBets,
        ownedBets,
        totalBets,
    });
        } catch (error) {
        alert(error);
        } finally {
        this.setState({ loading: false });
        }
    };

    async getJoinedBetsInfo(joinedBets, address)
    {
        console.log("joinedbets: ")
        console.log(joinedBets)
        var wonBets = 0;
        var lostBets = 0;
        for(const bet in joinedBets)
        {
            const betInstance = await betApi.instantiateContract(this.props.web3, PuzzleBet, joinedBets[bet])
            const finished = await betApi.finished(betInstance)
            console.log("finished: " + finished)
            if(finished)
            {
                const winner = await betApi.getWinners(betInstance)
                console.log("winner; ")
                console.log(winner)
                if (winner == address)
                {
                    wonBets += 1
                }
            }
        }

        lostBets = joinedBets.length - wonBets;

        this.setState({
            wonBets,
            lostBets
        })
    }

    render() {
        return (
            <div>
                <div class="row">
                    <div className="profile-card card text-center" style={{width: "15rem", height: "10rem"}}>
                    <div className="card-header">
                    <h3 className="card-title">Total Bets</h3>
                    </div>
                    <div className="card-body">
                        <h5 className="card-title">{this.state.totalBets}</h5>
                    </div>
                    </div>

                    <div className="profile-card card text-center" style={{width: "15rem", height: "10rem"}}>
                    <div className="card-header">
                    <h3 className="card-title">Won Bets</h3>
                    </div>
                    <div className="card-body">
                        <h5 className="card-title">{this.state.wonBets}</h5>
                    </div>
                    </div>

                    <div className="profile-card card text-center" style={{width: "15rem", height: "10rem"}}>
                    <div className="card-header">
                    <h3 className="card-title">Lost Bets</h3>
                    </div>
                    <div className="card-body">
                        <h5 className="card-title">{this.state.lostBets}</h5>
                    </div>
                    </div>

                    <div className="profile-card card text-center" style={{width: "15rem", height: "10rem"}}>
                    <div className="card-header">
                    <h3 className="card-title">Bet Win/Lose Ratio</h3>
                    </div>
                    <div className="card-body">
                        <h5 className="card-title">{this.state.wonBets / this.state.lostBets}</h5>
                    </div>
                    </div>

                    <div className="profile-card card text-center" style={{width: "15rem", height: "10rem"}}>
                    <div className="card-header">
                    <h3 className="card-title">Total amount won</h3>
                    </div>
                    <div className="card-body">
                        <h5 className="card-title">13000</h5>
                    </div>
                    </div>

                    <div className="profile-card card text-center" style={{width: "15rem", height: "10rem"}}>
                    <div className="card-header">
                    <h3 className="card-title">Total amount lost</h3>
                    </div>
                    <div className="card-body">
                        <h5 className="card-title">400</h5>
                    </div>
                    </div>
                </div>
            </div>
        );
    }
}

export const ExportedProfileLayout = withRouter(ProfileLayout);