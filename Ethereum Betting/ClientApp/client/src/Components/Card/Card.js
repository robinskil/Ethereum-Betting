import React from "react";
import "./style.css";

export class Card extends React.Component {
    render() {
        const { title, subtitle, children } = this.props;

        return <div className="custom-card card">
            <div className="card-body">
                <h5 className="card-title">{title}</h5>
                {
                    subtitle && (<h6 className="card-subtitle mb-2 text-muted">subtitle</h6>)
                }
                {children}
            </div>
        </div>
    }
}
