using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace platform_api.Tests.integrationTests
{
    public class integrationTests 
        : IClassFixture<WebApplicationFactory<platform_api.Startup>>
    {
        private readonly WebApplicationFactory<platform_api.Startup> _factory;

        public integrationTests(WebApplicationFactory<platform_api.Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        //[InlineData("/")] //This will throw an error
        [InlineData("/version")]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("application/json; charset=utf-8", 
                response.Content.Headers.ContentType.ToString());
        }
    }
}