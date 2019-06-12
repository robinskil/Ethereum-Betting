export const login = () => ({ type: "LOGIN" });

export const logout = () => ({ type: "LOGOUT" });

export const authInitialState = {
  isAuthenticated: false
};

export const authReducer = (state = authInitialState, action) => {
  switch (action.type) {
    case "LOGIN":
      return {
        ...state,
        isAuthenticated: true
      };
    case "LOGOUT":
      return {
        ...state,
        ...authInitialState
      };
    default:
      return state;
  }
};
