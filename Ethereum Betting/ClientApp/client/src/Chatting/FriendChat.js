import React from "react";
import * as signalR from '@aspnet/signalr';

export default class FriendChat extends React.Component {
    constructor(props) {
        super(props);
        this.ConnectToServer()

    }

    ConnectToServer = async () => {
        var connection = new signalR.HubConnectionBuilder().withUrl("/friendChat").build();
        connection.start().then(function () {
            console.log("Connected");
        }).catch(function (err) {
            console.error(err.toString());
        });
    }

    render() {
        return (
                <div> TEst</div>

            )
    }
}

class FriendChatComponent extends React.Component {
    
}