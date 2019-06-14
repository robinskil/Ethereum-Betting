import React from "react";
import {
  BrowserRouter as Router,
  Route,
  Link,
  withRouter
} from "react-router-dom";
import * as userApi from "../ApiHelpers/UserApi";
import Web3 from "web3";
import { StateContext } from "../../state";
import { login as loginType } from "../../reducers/auth";

class LoginForm extends React.Component {
  static contextType = StateContext;
  constructor(props) {
    super(props);
    this.state = {
      inputPassword: "",
      accounts: null
    };

    this.onChangePassword = this.onChangePassword.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  loadingAccountDetails = async () => {
    try {
      const web3 = new Web3(Web3.givenProvider, null);
      const accounts = await web3.eth.getAccounts();
      this.setState({ accounts });
    } catch (error) {
      alert(error);
    } finally {
      this.setState({ loading: false });
      //this.createLoginLayout();
    }
  };

  componentDidMount = async () => {
    this.loadingAccountDetails();
  };

  onChangePassword(event) {
    this.setState({ inputPassword: event.target.value });
  }

  async handleSubmit(event) {
    console.log("licck");
    event.preventDefault();

    let userPassword = this.state.inputPassword;
    let userAddress = this.state.accounts[0];
    let login = await userApi.LoginUser(userAddress, userPassword);
    const [_, dispatch] = this.context;
    console.log(login.succes, login.msg);
    if (login.success == true) {
      alert(login.msg);
      userApi.setLoggedIn();
      dispatch(loginType());
      this.props.history.push("/");
      this.render();
    } else {
      alert(login.msg);
    }
  }

  render() {
    return (
      <div>
        <div class="jumbotron" style={{ padding: "2rem" }}>
          <h1 class="display-4">Login To Your Account</h1>
          <p class="lead">To log in, enter your password below.</p>
          <hr class="my-4" />
          <form>
            <div class="form-group">
              <label for="validationServer01">Password</label>
              <input
                type="password"
                class="form-control"
                id="validationServer01"
                value={this.state.inputPassword}
                onChange={this.onChangePassword}
                required
              />
              <div class="invalid-feedback">Please fill in your password.</div>
            </div>
            <hr class="my-4" />
            <button className="btn btn-primary" onClick={this.handleSubmit}>
              Log In
            </button>
          </form>
        </div>
      </div>
    );
  }
}

export const ExportedLoginForm = withRouter(LoginForm);
