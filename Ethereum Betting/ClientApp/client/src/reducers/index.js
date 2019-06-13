import { authReducer, authInitialState } from "./auth";

export const initialState = {
  auth: authInitialState
};

export const mainReducer = ({ auth }, action) => ({
  auth: authReducer(auth, action)
});
