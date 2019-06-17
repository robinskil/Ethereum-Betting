﻿using InteractorLayer.AuthenticationService;
using InteractorLayer.RequestModels;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace InteractorLayer
{
    public interface IUserInteractor
    {
        bool Login(LoginRequestModel loginModel, out ClaimsIdentity claimsID);
        bool CheckIfNameExists(string name);
        bool CheckIfAddressExists(string address);
        bool CheckPassword(string address, string password);
        bool ChangePassword(ChangePasswordRequestModel changePasswordModel);
        bool CreateUser(CreateUserRequestModel createModel);
        bool DeleteUser(DeleteUserRequestModel deleteModel);
        string GetUserName(string adress);
        Task<IEnumerable<string>> AddressesToName(IEnumerable<string> addresses);
    }
}
