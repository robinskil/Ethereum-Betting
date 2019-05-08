import React from "react";
import { Card } from "../Components/Card/Card";
import { Link } from "react-router-dom"

export class ViewBetsPage extends React.Component {
    render() {
        return <div>
            <Card title="Bet 1">
                <p className="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                <Link to="">View bet</Link>
            </Card>
        </div>
    }
}
