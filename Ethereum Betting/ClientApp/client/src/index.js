import React from "react";
import ReactDOM from "react-dom";
import "./index.css";
import * as serviceWorker from "./serviceWorker";
import Wrapper from "./Pages/IndexPage";
import { StateProvider } from "./state";
import { mainReducer, initialState } from "./reducers";
import dayjs from "dayjs";
// import * as locale from 'dayjs/locale/nl';

// dayjs.setLocale(locale)

ReactDOM.render(
  <StateProvider initialState={initialState} reducer={mainReducer}>
    <Wrapper />
  </StateProvider>,
  document.getElementById("root")
);

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: http://bit.ly/CRA-PWA
serviceWorker.unregister();
