
import React, { Component } from "react";
import { Link } from 'react-router-dom'
import BettingFactory from "../contracts/BettingFactory.json";
//import WeatherBet from "../contracts/WeatherBet.json";

import { createContract, getOwnedBets } from "../helpers/BettingFactory";
//import { getRandomNumber , getBetAmount, getParticipators, instantiateWeatherContract, joinBet, createRandomNumber } from "../helpers/BetContract";
import { instantiateContract, getBetAmount, getParticipators, joinBet } from "../helpers/Bet.js";


class ViewAllBets extends Component {
    constructor(props) {
        super(props);
        this.state = {
            
        }
    
    }

  

    

    render() {
        return (
            <div>test</div>
            )
    }
}


export default ViewAllBets