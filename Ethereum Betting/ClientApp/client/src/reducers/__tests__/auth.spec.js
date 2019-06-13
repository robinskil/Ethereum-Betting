import { authReducer, authInitialState } from "../auth";

describe("auth reducer", () => {
  it("should return the inital state", () => {
    const result = authReducer(undefined, {});

    expect(result).toEqual({ isAuthenticated: false });
  });

  it("should handle LOGIN action type", () => {
    const loginAction = {
      type: "LOGIN"
    };

    const result = authReducer(authInitialState, loginAction);

    expect(result).toEqual({ isAuthenticated: true });
  });

  it("should handle the LOGOUT action type", () => {
    const logoutAction = {
      type: "LOGOUT"
    };

    const result = authReducer({ isAuthenticated: true }, {});

    expect(result).toEqual({ isAuthenticated: true });

    const nextResult = authReducer(undefined, logoutAction);

    expect(nextResult).toEqual({ isAuthenticated: false });
  });
});
