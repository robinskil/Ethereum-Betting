using InteractorLayer.RequestModels;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace InteractorLayer
{
    public interface IUserInteractor
    {
        bool CheckIfNameExists(string name);
        bool Login(LoginRequestModel loginModel, out ClaimsIdentity claimsID);
        bool CreateUser(CreateUserRequestModel createModel);
        bool DeleteUser(DeleteUserRequestModel deleteModel);
    }
}
