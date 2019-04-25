using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using DataAccesLayer.EF;
using DataAccesLayer.Repositories;
using DomainLayer.Models;
using InteractorLayer.NameGenerator;
using InteractorLayer.RequestModels;
using Microsoft.AspNetCore.Authentication.Cookies;

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
                Password = BCryptHash.HashText(createModel.Password),
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
        /// Validates a user given address and password with our database.
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns>True if valid details given, false if failed or invalid details</returns>
        public bool Login(LoginRequestModel loginModel, out ClaimsIdentity claimsID)
        {
            User u = UserRepository.GetUser(loginModel.Address);
            if (BCryptHash.ValidateText(loginModel.Password, u.Password))
            {
                claimsID = new ClaimsIdentity(GetLoginClaims(u), CookieAuthenticationDefaults.AuthenticationScheme);
                return true;
            }
            claimsID = default(ClaimsIdentity);
            return false;
        }

        /// <summary>
        /// Generates security claims for a general user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private IList<Claim> GetLoginClaims(User user)
        {
            return new Claim[]
            {
                new Claim(ClaimTypes.Sid,user.UserAddress),
                new Claim("Nickname" , user.GeneratedName),
                new Claim(ClaimTypes.Role, "GeneralUser")
            };
        }


    }
}
