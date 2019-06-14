import React from "react";
import * as signalR from '@aspnet/signalr';
import "../Chatting/FriendChat.css";




export default class FriendsChat extends React.Component {
    constructor(props) {
        super(props);
        this.ConnectToServer()
        this.state = {
            Toggled: false,
          
        }

    }
    Toggle = () => {
        this.setState({ Toggled: !this.state.Toggled });
        console.log(this.state.Toggled);
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
        if (this.state.Toggled == true) {
            return (
                <div>
                    <FriendsList />
                    <button class="btn btn-primary open-button" type="button" onClick={this.Toggle}>Friends</button>
                    </div>
                )
        }
        return (
            <div>
                      <button class="btn btn-primary open-button" type="button" onClick={this.Toggle}>Friends</button>

                
                
     
            </div>


            )
    }
}


class FriendsList extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            Friends: []
        }

    }

    render() {

        return (

            <div className="Friends-List-Body swing-in-right-fwd">
                <div >
                    <FilterableContactTable contacts={CONTACTS} />
                </div>
            </div>

        )
    }
    


}


class FilterableContactTable extends React.Component {
    constructor(props) {
        super(props);
        
        this.state = {
            filterText: '',
            contacts: [
                { key: 1, name: 'test 1'}

            ]
        };
        this.handleFilterTextInput = this.handleFilterTextInput.bind(this);
        this.addContact = this.addContact.bind(this);
    }

    addContact(contact) {
        var timestamp = new Date().getTime();
        contact['key'] = timestamp;
        console.log('BEFORE: this.state.contacts: ' + this.state.contacts.length);
        // update the state object
        this.state.contacts.push(contact);
        // set the state
        this.setState({ contacts: this.state.contacts });
    }

    handleFilterTextInput(filterText) {
        //Call to setState to update the UI
        this.setState({
            filterText: filterText
        });
     
    }

    render() {
        return (
            <div>
               
                <SearchBar
                    filterText={this.state.filterText}
                    onFilterTextInput={this.handleFilterTextInput}
                />
                <NewContactRow addContact={this.addContact} />
                <ContactTable
                    contacts={this.state.contacts}
                    filterText={this.state.filterText}
                />
            </div>
        );
    }
}
class ContactRow extends React.Component {

    constructor(props) {
        super(props);

        this.state = {
            open: false,

          
        }

    }



    render() {
        if (this.state.open == true) {
            return (
                <ChatBody FriendsName={this.props.contact.name} ToggleChat={this.openChat} />
                )
        }
            return (
                <tr>
                    <td onClick={this.openChat} >{this.props.contact.name}</td>
                    
                    
                
                </tr>

            );
        }
    
    openChat = () => {
        this.setState({ open: !this.state.open });
        console.log(this.state);

    }
}
class ChatBody extends React.Component {


    render() {
        return (
            <div className="card chat_positionz">
           
                <div className="card-header">
                    <div className="button-position">
                        <button className="button" onClick={this.props.ToggleChat}></button>
                    </div>
                    Chat with : {this.props.FriendsName}
                  
                </div>  
                <div class="card-body msg_card_body ">
                  test
                </div>
                <div class="card-footer">
                    <SendTextArea SendFunction={this.SendMessage} />
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
        if (e.keyCode == 13) { this.SendMessage(); }
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

//class ReceivedChatMessage extends React.Component {
//    render() {
//        return (
//            <div class="d-flex justify-content-start mb-4 slide-in-blurred-left" style={{ marginRight: "10px" }}>
//                <div class="msg_cotainer" style={{ minWidth: 100 }}>
//                    {this.props.message}
//                    <span class="msg_time">{this.props.time.getHours() + ":" + this.props.time.getMinutes() + " by " + this.props.sender}</span>
//                </div>
//            </div>
//        )
//    }
//}

//class SendChatMessage extends React.Component {
//    render() {
//        return (
//            <div class="d-flex justify-content-end mb-4 slide-in-blurred-right" style={{ marginLeft: "10px" }}>
//                <div class="msg_cotainer_send" style={{ minWidth: 100 }}>
//                    {this.props.message}
//                    <span class="msg_time_send">{this.props.time.getHours() + ":" + this.props.time.getMinutes() + " by " + this.props.sender}</span>
//                </div>
//            </div>
//        )
//    }
//}


class ContactTable extends React.Component {

    constructor(props) {
        super(props);
  
        this.state = {
            open: false,
        }

    }
    render() {
        var rows = [];
        this.props.contacts.forEach((contact) => {
            if (contact.name.indexOf(this.props.filterText) === -1) {
                return;
            }
            rows.push(<ContactRow key={contact.key} contact={contact} />);
        });
        return (
            <table className='table table-hover'>
                <thead>
                    <tr>
                        <th><i className="fa fa-fw fa-user"></i>Friends</th>
                    </tr>
                </thead>
                <tbody>{rows}</tbody>
            </table>
        );
    }
  
}

class SearchBar extends React.Component {
    constructor(props) {
        super(props);
        this.handleFilterTextInputChange = this.handleFilterTextInputChange.bind(this);
    }

    handleFilterTextInputChange(e) {
        this.props.onFilterTextInput(e.target.value);
    }

    render() {
        return (
            <div>
            <form>
                <input
                    className="form-control"
                    type="text"
                    placeholder="Search friend"     
                    value={this.props.filterText}
                    onChange={this.handleFilterTextInputChange}
                />
                </form>
            </div>
        );
    }
}

class NewContactRow extends React.Component {
    constructor(props) {
        super(props);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleSubmit(event) {
        event.preventDefault();
        const target = event.target;
        const name = target.name.value;


        var contact = {
            name: name,
    
        };
        this.props.addContact(contact);
    }

    render() {
        return (

            <form className="form-inline" onSubmit={this.handleSubmit}>
                <div>
                    <div >
                        <input type="text" name="name" className="form-control" id="nameInput" placeholder="add friend" />
                        <button type="submit" className="btn btn-primary"><i className="fa fa-fw fa-plus"></i>Add</button>
                    </div>
               
           
                </div>
            </form>

        )
    }
}

var CONTACTS = [
    { key: 1, name: 'test 1' },
    { key: 2, name: 'test 2' },
    { key: 3, name: 'test 3' },
    { key: 4, name: 'test 4' },
    { key: 5, name: 'test 5' },

];

