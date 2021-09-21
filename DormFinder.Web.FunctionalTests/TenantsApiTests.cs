using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DormFinder.Web.Models;
using Xunit;

namespace DormFinder.Web.FunctionalTests
{
    public class TenantsApiTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly CustomWebApplicationFactory _factory;

        public TenantsApiTests(CustomWebApplicationFactory factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ShouldGetTenantById()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("api/tenants/1");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task ShouldCreateTenant()
        {
            // Arrange
            var client = _factory.CreateClient();
            var dto = new CreateTenantDto()
            {
                ContractId = 1,
                RoomId = 1,
                UserId = 1
            };

            // Act
            var response = await client.PostAsync(
                "api/tenants",
                new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json"));

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task ShouldRetrieveList()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("api/tenants");

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
