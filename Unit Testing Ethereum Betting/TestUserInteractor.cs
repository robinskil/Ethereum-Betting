using DataAccesLayer.EF;
using DataAccesLayer.Repositories;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using InteractorLayer;
using Ethereum_Betting.Controllers;
using InteractorLayer.RequestModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using System.Linq;

namespace Unit_Testing_Ethereum_Betting
{
    public class TestUserInteractor
    {
        UserInteractor UserInteractor;
        EthereumBettingContext context;
        public TestUserInteractor()
        {
            var optionsBuilder = new DbContextOptionsBuilder<EthereumBettingContext>();

            optionsBuilder.UseInMemoryDatabase();

            context = new EthereumBettingContext(optionsBuilder.Options);

            UserInteractor = new UserInteractor(context);
        }

        [Fact]
        public async void CreateUser()
        {
            //Arrange
            User user = new User(){
                UserAddress = "0x10A05744B5DE85997e7af016Cdf4C62A15A443B4",
                GeneratedName = "test",
                Password = "test"
            };

            CreateUserRequestModel createModel = new CreateUserRequestModel(){
                Address = "0x10A05744B5DE85997e7af016Cdf4C62A15A443B4",
                Username = "test",
                Password = "test"
            };

            //Act
            UserInteractor.CreateUser(createModel);

            //Assert
            Assert.True(context.Users.Any(u => u == user));
        }
        
        [Fact]
        public async void ChangePassword()
        {
            //Arrange
            ChangePasswordRequestModel changePasswordModel = new ChangePasswordRequestModel()
            {
                Address = "0x10A05744B5DE85997e7af016Cdf4C62A15A443B4",
                OldPassword = "test",
                NewPassword = "newTest"
            };

            User user = await context.Users.FirstAsync(u => u.UserAddress == changePasswordModel.Address);
            if(user == null)
            {
                CreateUserForTest();
            }

            //Act
            UserInteractor.ChangePassword(changePasswordModel);

            //Assert
            Assert.True(Hashing.Equals("newTest", user.Password));
        }

        [Fact]
        public async void DeleteUser()
        {
            //Arrange
            DeleteUserRequestModel deleteModel = new DeleteUserRequestModel(){
                Address = "0x10A05744B5DE85997e7af016Cdf4C62A15A443B4",
                Password = "test"
            };


            User user = await context.Users.FirstAsync(u => u.UserAddress == deleteModel.Address);
            if (user == null)
            {
                CreateUserForTest();
            }

            //Act
            UserInteractor.DeleteUser(deleteModel);

            //Assert
            Assert.False(context.Users.Any(u => u == user));
        }
        public void CreateUserForTest()
        {
            CreateUserRequestModel createModel = new CreateUserRequestModel()
            {
                Address = "0x10A05744B5DE85997e7af016Cdf4C62A15A443B4",
                Username = "test",
                Password = "test"
            };

            UserInteractor.CreateUser(createModel);
        }

            //Arrange
            //Act
            //Assert
    }
}
