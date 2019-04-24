using DataAccesLayer.EF;
using DataAccesLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Unit_Testing_Ethereum_Betting
{
    public class TestUserRepository
    {
        UserRepository UserRepository;
        public TestUserRepository()
        {
            //var options = new DbContextOptions<EthereumBettingContext>();
            //options.UseSqlServer("");
            //UserRepository = new UserRepository(new EthereumBettingContext(options));
        }
        [Fact]
        public void Test()
        {
            
        }
    }
}
