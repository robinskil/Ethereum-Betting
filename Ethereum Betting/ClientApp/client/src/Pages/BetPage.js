import React from "react";
import BettingFactory from "../contracts/BettingFactory.json";
import PuzzleBet from "../contracts/PuzzleBet.json";
import { getBet, getSingleBet } from "../helpers/BettingFactory";
import { instantiateContract } from "../helpers/Bet.js";
import dayjs from "dayjs";

export class BetPage extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      factoryContract: null,
      bet: {
        winners: [],
        participators: []
      },
      loading: true
    };
  }

  componentDidMount = async () => {
    this.loadingAccountDetails();
  };

  mapToBet = unfBet => {
    return {
      owner: unfBet[0],
      betAmount: unfBet[1],
      friendsOnly: unfBet[2],
      open: unfBet[3],
      maxParticipators: unfBet[4],
      participators: unfBet[5],
      winners: unfBet[6],
      finished: unfBet[7],
      length: parseInt(unfBet[8], 10),
      creationTime: dayjs.unix(unfBet[9]).format("ddd MM, YYYY HH:MM")
    };
  };

  loadingAccountDetails = async () => {
    try {
      const bet = this.props.match.params.betId;
      console.log(bet);

      const instance = await instantiateContract(
        this.props.web3,
        PuzzleBet,
        bet
      );

      const singleBet = await getSingleBet(instance);
      console.log(singleBet);

      this.setState({
        factoryContract: instance,
        bet: this.mapToBet(singleBet)
      });
    } catch (error) {
      alert(error);
    } finally {
      this.setState({ loading: false });
    }
  };

  render() {
    const { betId } = this.props.match.params;
    const bet = this.state.bet;
    console.log(this.state);
    return (
      <div class="jumbotron jumbotron-fluid">
        <div class="container">
          <h1 class="display-6">Bet: {betId}</h1>
          <p class="lead">Bet owner: {bet.owner}</p>
          <p class="lead">Bet status: {bet.open ? "open" : "closed"}</p>
          <p class="lead">Bet amount: {bet.betAmount}</p>
          <p class="lead">Bet created at: {bet.creationTime}</p>
          <p class="lead">Bet length: {bet.length} minutes</p>
          <p class="lead">Max participators: {bet.maxParticipators}</p>
          <p class="lead">Finished: {bet.finished ? "yes" : "no"}</p>
          <p class="lead">Friends only: {bet.friendsOnly ? "yes" : "no"}</p>

          <p class="lead">
            Participators:
            {bet.participators.map(v => (
              <div>{v}</div>
            ))}
          </p>
          <p class="lead">
            Winners:
            {bet.winners.map(v => (
              <div>{v}</div>
            ))}
          </p>
        </div>
      </div>
    );
  }
}
