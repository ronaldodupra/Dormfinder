using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DormFinder.Web.Models;
using FluentAssertions;
using Xunit;

namespace DormFinder.Web.FunctionalTests
{
    public class LeadApiTest : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly CustomWebApplicationFactory _factory;

        public LeadApiTest(CustomWebApplicationFactory factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ShouldCreateLead()
        {
            // Arrange
            var client = _factory.CreateClient();
            var dto = new AddLeadModel()
            {
                Email = "johndoe@example.com",
                FirstName = "John",
                LastName = "Doe",
                Number = "09190123415",
                Message = "Hi, I'd like to rent your room",
                RoomId = 1
            };

            // Act
            var response = await client.PostAsync(
                "api/leads",
                new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json"));

            // Assert
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var lead = JsonSerializer.Deserialize<LeadModel>(responseContent, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            lead.Id.Should().BeOfType(typeof(int));
            lead.Email.Should().Be("johndoe@example.com");
        }

        [Fact]
        public async Task ShouldRetrieveLeadById()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("api/leads/1");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task ShouldRetrievePaginatedList()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("api/leads");

            // Assert
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var leads = JsonSerializer.Deserialize<PaginatedListTest<LeadModel>>(responseContent, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            leads.Items.Should().NotBeEmpty();
        }
    }
}
