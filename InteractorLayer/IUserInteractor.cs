using InteractorLayer.RequestModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace InteractorLayer
{
    public interface IUserInteractor
    {
        bool Login(LoginRequestModel loginModel);
        bool CreateUser(CreateUserRequestModel createModel);
        bool DeleteUser(DeleteUserRequestModel deleteModel);
    }
}
