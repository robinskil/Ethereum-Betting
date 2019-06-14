using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing; 
using Xunit;
using Ethereum_Betting;
using System.Threading.Tasks;

namespace Unit_Testing_Ethereum_Betting
{
    public class TestLoginController : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        public readonly HttpClient Client;

        public TestLoginController(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            Client = factory.CreateClient();
        }

        [Fact]
        public async Task Test1()
        {

            // Act
            var response = await Client.GetAsync("/login");
            
            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.StartsWith("http://localhost/Identity/Account/Login", response.Headers.Location.OriginalString);
        }
    }
}
