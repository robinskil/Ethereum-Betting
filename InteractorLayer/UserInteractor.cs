using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DataAccesLayer.EF;
using DataAccesLayer.Repositories;
using DomainLayer.Models;
using InteractorLayer.AuthenticationService;
using InteractorLayer.NameGenerator;
using InteractorLayer.RequestModels;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace InteractorLayer
{
    public class UserInteractor : UserAuthenticationService, IUserInteractor
    {
        public IUserRepository UserRepository { get; set; }
        public UserInteractor(EthereumBettingContext context) : base(null)
        {
            //DI this object
            UserRepository = new UserRepository(context);
            throw new NotImplementedException("No DI into the Authentication service");
        }

        /// <summary>
        /// Creates a user on our database
        /// </summary>
        /// <param name="createModel"></param>
        /// <returns></returns>
        public bool CreateUser(CreateUserRequestModel createModel)
        {
            return UserRepository.CreateUser(new User()
            {
                UserAddress = createModel.Address,
                Password = Hashing.HashText(createModel.Password),
                //Add support for generating name
                GeneratedName = RandomNameGenerator.GenerateName(s => CheckIfNameExists(s))
            });
        }

        public bool CheckIfNameExists(string name)
        {
            return UserRepository.CheckIfNameExist(name);
        }

        /// <summary>
        /// Deletes a user from our database.
        /// </summary>
        /// <param name="deleteModel"></param>
        /// <returns></returns>
        public bool DeleteUser(DeleteUserRequestModel deleteModel)
        {
            return UserRepository.DeleteUser(deleteModel.Address);
        }

        /// <summary>
        /// Should call the database layer to translate names to addresses
        /// </summary>
        /// <param name="addresses"></param>
        /// <returns></returns>
        public Task<IEnumerable<string>> AddressesToName(IEnumerable<string> addresses)
        {
            throw new NotImplementedException();
        }
    }
}
