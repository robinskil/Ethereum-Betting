using InteractorLayer.RequestModels;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace InteractorLayer.AuthenticationService
{
    public interface IUserAuthenticationInteractor
    {
        bool Login(LoginRequestModel loginModel, out ClaimsIdentity claimsID);
        bool Logout(string addressUser);
    }
}
