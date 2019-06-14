using DataAccesLayer.EF;
using DataAccesLayer.Repositories;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using InteractorLayer;
using InteractorLayer.RequestModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;

namespace Unit_Testing_Ethereum_Betting
{
    public class TestUserRepository
    {
        UserRepository UserRepository;
        EthereumBettingContext context;
        public TestUserRepository()
        {
            var options = new DbContextOptions<EthereumBettingContext>();
            UserRepository = new UserRepository(new EthereumBettingContext(options));
        }
        //[Fact]
        //public void CreateUser(CreateUserRequestModel createModel)
        //{
        //    //Arragne
        //    User testUser = new User();
        //    testUser.UserAddress = "0x10A05744B5DE85997e7af016Cdf4C62A15A443B4";
        //    testUser.Password = "test";
        //    testUser.GeneratedName = "test";
        //    //Act
        //    UserRepository.CreateUser(testUser);
        //    //Assert
        //    Assert.True(context.Users.Any(p => p.UserAddress == testUser.UserAddress));
        //}
    }
}
