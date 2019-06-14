import React, { Component } from "react";
import { BrowserRouter as Router, Route, Link, withRouter } from "react-router-dom";
import * as userApi from "./ApiHelpers/UserApi";
import { StateContext } from "../state";
import { login, logout } from "../reducers/auth";

class MenuBar extends Component {
  constructor(props) {
    super(props);
    this.state = {
    }
    this.handleLogOut = this.handleLogOut.bind(this);
  }

  static contextType = StateContext;

  componentDidMount() {
    const [_, dispatch] = this.context;

    if (userApi.IsAuthenticated()) {
      dispatch(login());
    }
  }

  handleLogOut(event) {
    const [_, dispatch] = this.context;

    event.preventDefault();
    dispatch(logout());
    userApi.setLoggedOut();
    this.props.history.push("/");
    window.location.reload();
  }

  render() {
    const [
      {
        auth: { isAuthenticated }
      }
    ] = this.context;
    console.log(isAuthenticated);
    return (
      <nav
        className="navbar navbar-expand-lg navbar-light bg-light"
        style={{ marginBottom: "15px" }}
      >
        <Link className="navbar-brand" to="/">
          <img
            src="https://cdn4.iconfinder.com/data/icons/cryptocoins/227/ETH-512.png"
            width="30"
            height="30"
            className="d-inline-block align-top"
            alt=""
          />
          Ethereum Betting
        </Link>
        <button
          className="navbar-toggler"
          type="button"
          data-toggle="collapse"
          data-target="#navbarNavDropdown"
          aria-controls="navbarNavDropdown"
          aria-expanded="false"
          aria-label="Toggle navigation"
        >
          <span className="navbar-toggler-icon" />
        </button>

        <div
          className="collapse navbar-collapse justify-content-end"
          id="navbarNavDropdown"
        >
          <ul className="navbar-nav">
            <li className="nav-item">
              <Link className="nav-link" to="/GettinStarted">
                Getting Started
              </Link>
            </li>
            {isAuthenticated && (
              <li className="nav-item">
                <Link className="nav-link" to="/Profile">
                  Profile
                </Link>
              </li>
            )}
            {!isAuthenticated && (
              <li className="nav-item">
                <Link className="nav-link" to="/Login">
                  Login
                </Link>
              </li>
            )}
            {!isAuthenticated && (
              <li className="nav-item">
                <Link className="nav-link" to="/Register">
                  Register
                </Link>
              </li>
            )}
            <li className="nav-item dropdown">
              <a
                className="nav-link dropdown-toggle"
                href="#"
                id="navbarDropdownMenuLink"
                data-toggle="dropdown"
                aria-haspopup="true"
                aria-expanded="false"
              >
                Bets
              </a>
              <div
                className="dropdown-menu"
                aria-labelledby="navbarDropdownMenuLink"
              >
                <Link className="dropdown-item" to="/CreateBet">
                  Create a bet
                </Link>
                <Link className="dropdown-item" to="/JoinBet">
                  Join a bet
                </Link>
                <Link className="dropdown-item" to="/PuzzlePage">
                  Puzzle
                </Link>
              </div>
            </li>
            {isAuthenticated && (
              <li className="nav-item">
                <Link className="nav-link" onClick={this.handleLogOut}>
                  Logout
                </Link>
              </li>
            )}
          </ul>
        </div>
      </nav>
    );
  }
}

//<Link className="dropdown-item" to="/JoinBet">Join a bet</Link>
//    <Link className="dropdown-item" to="/ViewBets">View your bets</Link>

export const ExportedMenuBar = withRouter(MenuBar)