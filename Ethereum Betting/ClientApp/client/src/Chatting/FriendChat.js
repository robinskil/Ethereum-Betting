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
        console.log(this.state);
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
            <div> TEst

                      <button class="btn btn-primary open-button" type="button" onClick={this.Toggle}>Friends</button>
                      {this.state.Toggled ? <FriendsList />: null}
                
     
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

            <div className="Friends-List-Body slide-top">
                <div class="card-header">
                    friends online
                </div>
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
                        <th><i className="fa fa-fw fa-user"></i>Name</th>
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

