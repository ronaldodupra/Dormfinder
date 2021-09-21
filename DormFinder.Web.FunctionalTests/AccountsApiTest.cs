using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DormFinder.Web.Models;
using DormFinder.Web.Models.Request;
using FluentAssertions;
using Xunit;

namespace DormFinder.Web.FunctionalTests
{
    public class AccountsApiTest : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly CustomWebApplicationFactory _factory;

        public AccountsApiTest(CustomWebApplicationFactory factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ShouldCreateUser()
        {
            // Arrange
            var client = _factory.CreateClient();
            var dto = new RegisterModel()
            {
                Email = "johndoe@example.com",
                FirstName = "John",
                LastName = "Doe",
                City = "Manila",
                Password = "12345678",
                UserType = "Tenant"
            };

            // Act
            var response = await client.PostAsync(
                "/api/account/register",
                new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json"));

            // Assert
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var user = JsonSerializer.Deserialize<UserModel>(responseContent, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            user.FirstName.Should().Be("John");
            user.Address.City.Should().Be("Manila");
        }
    }
}
