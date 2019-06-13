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
    public class UserInteractor : IUserInteractor
    {
        IUserRepository UserRepository { get; }
        public UserInteractor(EthereumBettingContext context)
        {
            //DI this object
            UserRepository = new UserRepository(context);
            //throw new NotImplementedException("No DI into the Authentication service");
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
                return true;
            }
            claimsID = default;
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
                new Claim(ClaimTypes.Role, "GeneralUser"),
                new Claim(ClaimTypes.NameIdentifier,user.UserAddress)
            };
        }

        /// <summary>
        /// Creates a user on our database
        /// </summary>
        /// <param name="createModel"></param>
        /// <returns></returns>
        public bool CreateUser(CreateUserRequestModel createModel)
        {
            if (createModel.Username != null)
            {
                return UserRepository.CreateUser(new User()
                {
                    UserAddress = createModel.Address,
                    Password = Hashing.HashText(createModel.Password),
                    //Add support for generating name
                    GeneratedName = createModel.Username
                });
            }
            else
            {
                return UserRepository.CreateUser(new User()
                {
                    UserAddress = createModel.Address,
                    Password = Hashing.HashText(createModel.Password),
                    //Add support for generating name
                    GeneratedName = RandomNameGenerator.GenerateName(s => CheckIfNameExists(s))
                });
            }
        }

        public bool ChangePassword(ChangePasswordRequestModel changePasswordModel)
        {
            User user = UserRepository.GetUser(changePasswordModel.Address);
            if (user != null)
            {
                if (Hashing.ValidateText(changePasswordModel.OldPassword, user.Password))
                {
                    user.Password = Hashing.HashText(changePasswordModel.NewPassword);
                    return UserRepository.ChangePassword(user);
                }
            }

            return false;
        }

        public bool CheckIfNameExists(string name)
        {
            return UserRepository.CheckIfNameExist(name);
        }

        public bool CheckIfAddressExists(string address)
        {
            return UserRepository.CheckIfAddressExists(address);
        }

        /// <summary>
        /// Deletes a user from our database.
        /// </summary>
        /// <param name="deleteModel"></param>
        /// <returns></returns>
        public bool DeleteUser(DeleteUserRequestModel deleteModel)
        {
            //GetUser can return null, MARU , CHECK THIS!
            User user = UserRepository.GetUser(deleteModel.Address);
            if(user != null)
            {
                if (Hashing.ValidateText(deleteModel.Password, user.Password))
                {
                    //Delete user requires an address is string form not an object.
                    return UserRepository.DeleteUser(user);
                }
            }
            return false;
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
