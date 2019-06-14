import React from 'react';
import * as signalR from '@aspnet/signalr';
import "../Chatting/Chat.css"

export default class BetChatComponent extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            ChatToggled: false,
            UserAddress: null
        }
        console.log(this.state.UserAddress);
    }
    /*
     * TODO, Make this method use web3
     */

    componentDidMount = async () => {
        this.setState({ UserAddress: await this.GetUserAddress() })
    }
    GetUserAddress = async () => {
        try {
            const accounts = await this.props.web3.eth.getAccounts();
            console.log(accounts[0]);
            return accounts[0];
        }
        catch(error){
            alert(error);
            return null;
        }
    }

    ToggleChat = () => {
        this.setState({ ChatToggled: !this.state.ChatToggled });
    }

    render() {
        if (this.state.UserAddress != null) {
            return (
                <div>
                    <button class="btn btn-primary button_halfway" type="button" onClick={this.ToggleChat}>Toggle Chat</button>
                    {this.state.ChatToggled ? <BetChat betAddress={this.props.betAddress} UserAddress={this.state.UserAddress} className="align-content-center" /> : null}
                </div>
            )
        }
        else return (
            <div>
                <h1>Error get user address, please reload the page and make sure you're connected on metamask</h1>
            </div>
            )
    }
}

class BetChat extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            Connecting: false,
            Connected: false,
            Connection: null
        }
    }

    componentDidMount = () => {
        this.ConnectToChat();
    }

    SetConnection = (connection) => {
        console.log("Connected")
        this.setState({ Connected: true, Connection: connection, Connecting : false });
    }

    FailedConnection = () => {
        console.log("Failed to Connect")
        this.setState({ Connected: false, Connection: null, Connecting: false });
    }

    ConnectToChat = async () => {
        this.setState({ Connecting: true });
        var succes = false;
        var connection = new signalR.HubConnectionBuilder().withUrl("/BetChat").build();
        await connection.start().then(function () {
            console.log("Connected");
            succes = true;
            //
            //console.log(connection)
        }).catch(function (err) {
            console.error(err.toString());
            succes = false;
        })
        if (succes) this.SetConnection(connection);
        else this.FailedConnection();
        this.ConnectToGroup(connection);
    }

    ConnectToGroup = (connection) => {
        connection.invoke("JoinBetChat", this.props.UserAddress, this.props.betAddress).catch(function (err) {
            return console.error(err.toString());
        });
    }

    render() {
        return (
            <div className="col-4">
                {!this.state.Connecting && this.state.Connection != null ? <ChatBody UserAddress={this.props.UserAddress} betAddress={this.props.betAddress} connection={this.state.Connection} /> : <h1>Connecting...</h1>}
            </div>
        )
    }
}

class ChatBody extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            Messages: []
        }
        this.ReceiveActions(this.props.connection);
        this.SendFunctionMessage = this.SendActions(this.props.connection);
    }

    ReceiveActions = (connection) => {
        connection.on("ReceiveMessage", (message) => {
            this.ReceivedMessage(message, "Anonymous");
        })
    }

    SendActions = (connection) => {
        return (message) => {
            if (message && message !== "") {
                connection.invoke("SendMessage", this.props.UserAddress, this.props.betAddress, message).catch(function (err) {
                    return console.error(err.toString());
                });
            }
            else console.log("failed to send empty message")
        }
    }

    render() {
        return (
            <div className="card chat_position swing-in-right-fwd">
                <div class="card-header">
                    Chat On Contract : {this.props.betAddress}
                </div>
                <div class="card-body msg_card_body">
                    {this.state.Messages.map(message => {
                        console.log(message.Type);
                        if (message.Type == "Sender") return (
                            <SendChatMessage message={message.Message} time={message.Time} sender={message.Sender} />
                        ); else return <ReceivedChatMessage message={message.Message} time={message.Time} sender={message.Sender} />
                        
                    })}
                </div>
                <div class="card-footer">
                    <SendTextArea SendFunction={this.SendMessage} />
                </div>
            </div>
        )
    }

    ReceivedMessage = (message, sender) => {
        var arrayMessages = this.state.Messages;
        arrayMessages.push({ Sender: sender, Time: new Date(), Message: message, Type: "Receiver" })
        this.setState({ Messages: arrayMessages });
    }

    SendMessage = (message) => {
        if (message && message !== "") {
            this.SendFunctionMessage(message);
            var arrayMessages = this.state.Messages;
            arrayMessages.push({ Sender: "You", Time: new Date(), Message: message, Type: "Sender" })
            this.setState({ Messages: arrayMessages });
        }
    }
}

class ReceivedChatMessage extends React.Component {
    render() {
        return (
            <div class="d-flex justify-content-start mb-4 slide-in-blurred-left" style={{ marginRight: "10px" }}>
                <div class="msg_cotainer" style={{ minWidth: 100 }}>
                    {this.props.message}
                    <span class="msg_time">{this.props.time.getHours() + ":" + this.props.time.getMinutes() + " by " + this.props.sender}</span>
                </div>
            </div>
        )
    }
}

class SendChatMessage extends React.Component {
    render() {
        return (
            <div class="d-flex justify-content-end mb-4 slide-in-blurred-right" style={{ marginLeft: "10px" }}>
                <div class="msg_cotainer_send" style={{ minWidth: 100 }}>
                    {this.props.message}
                    <span class="msg_time_send">{this.props.time.getHours() + ":" + this.props.time.getMinutes() + " by " + this.props.sender}</span>
                </div>
            </div>
        )
    }
}

class SendTextArea extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            text: ""
        }
        console.log(this.props.SendFunction);
    }

    Type = (e) => {
        this.setState({ text: e.target.value })
    }

    SendMessage = () => {
        this.props.SendFunction(this.state.text);
        this.setState({ text: "" });
    }

    EnterKey = (e) => {
        if (e.keyCode == 13) { this.SendMessage();}
    }

    render() {
        return (
            <div class="input-group">
                <textarea onChange={this.Type} name="" value={this.state.text} class="form-control type_msg" placeholder="Type your message..." onKeyUp={this.EnterKey}></textarea>
                <div class="input-group-append" onClick={this.SendMessage} >
                    <span class="input-group-text send_btn"><i class="fas fa-location-arrow"></i></span>
                </div>
            </div>
        )
    }
}