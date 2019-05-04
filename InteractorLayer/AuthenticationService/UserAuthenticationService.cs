using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DataAccesLayer.Repositories;
using DomainLayer.Models;
using InteractorLayer.RequestModels;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace InteractorLayer.AuthenticationService
{
    public class UserAuthenticationService : UserManager , IUserAuthenticationInteractor
    {
        private IUserRepository UserRepository { get; }
        public UserAuthenticationService(IUserRepository repository)
        {
            UserRepository = repository;
        }

        /// <summary>
        /// Validates a user given address and password with our database.
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns>True if valid details given, false if failed or invalid details</returns>
        public bool Login(LoginRequestModel loginModel, out ClaimsIdentity claimsID)
        {
            User u = UserRepository.GetUser(loginModel.Address);
            if (Hashing.ValidateText(loginModel.Password, u.Password))
            {
                claimsID = new ClaimsIdentity(GetLoginClaims(u), CookieAuthenticationDefaults.AuthenticationScheme);
                if(!AddUserToOnline(u)) throw new Exception("Something went wrong during adding user to the online cache");
                return true;
            }
            claimsID = default;
            return false;
        }
        public bool Logout(string addressUser)
        {
            return RemoveUserFromOnline(addressUser);
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
                new Claim(ClaimTypes.Role, "GeneralUser"),
                new Claim(ClaimTypes.NameIdentifier,user.UserAddress)
            };
        }
    }
}
