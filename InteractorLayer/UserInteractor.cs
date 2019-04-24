using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.EF;
using DataAccesLayer.Repositories;
using InteractorLayer.RequestModels;

namespace InteractorLayer
{
    public class UserInteractor : IUserInteractor
    {
        public IUserRepository UserRepository { get; set; }
        public UserInteractor(EthereumBettingContext context)
        {
            //DI this object
            UserRepository = new UserRepository(context);
        }
        public bool CreateUser(CreateUserRequestModel createModel)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(DeleteUserRequestModel deleteModel)
        {
            throw new NotImplementedException();
        }

        public bool Login(LoginRequestModel loginModel)
        {
            throw new NotImplementedException();   
        }
    }
}
