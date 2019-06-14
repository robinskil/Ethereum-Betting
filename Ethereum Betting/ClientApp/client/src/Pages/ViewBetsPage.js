//import React from "react";
//import { Card } from "../Components/Card/Card";
//import { Link } from "react-router-dom"
//import { betApi } from "../helpers/BetApi";

//export class ViewBetsPage extends React.Component {

//    state = {
//        bets: []
//    }

//    async componentDidMount() {
//        const bets = await betApi.getMyBets();
//        this.setState({ bets });
//    }

//    render() {
//        const { bets } = this.state;

//        return (<div>
//            <h1>My bets</h1>
//            <div className="container">
//                <div className="row">
//                    {
//                        bets.map(bet =>
//                            <div className="col-sm">
//                                <Card title={bet.title}>
//                                    <p className="card-text">Amount: {bet.amount} <br/> Duration: {bet.duration}</p>
//                                    <Link to="">View bet</Link>
//                                </Card>
//                            </div>
//                          )
//                    }
//                </div>
//            </div>
//            </div>
//        )
//    }
//}
