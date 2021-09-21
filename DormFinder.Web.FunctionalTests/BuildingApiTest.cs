using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DormFinder.Web.Buildings.Models;
using FluentAssertions;
using Xunit;

namespace DormFinder.Web.FunctionalTests
{
    public class BuildingApiTest : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly CustomWebApplicationFactory _factory;

        public BuildingApiTest(CustomWebApplicationFactory factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ShouldCreateNewBuilding()
        {
            // Arrange
            var client = _factory.CreateClient();
            var dto = new CreateBuildingDto()
            {
                Name = "Acme",
                BuildingType = "Condominium",
                Address = new CreateBuildingDto.AddressDto()
                {
                    Province = "Metro Manila",
                    City = "Mandaluyong City",
                    AddressLine1 = "154 San Pedro St."
                },
            };

            // Act
            var response = await client.PostAsync(
                "/api/buildings",
                new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json"));

            // Assert
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var building = JsonSerializer.Deserialize<BuildingDto>(responseContent, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            building.Name.Should().Be("Acme");
        }

        [Fact]
        public async Task ShouldUpdateBuilding()
        {
            // Arrange
            var client = _factory.CreateClient();
            var dto = new UpdateBuildingDto()
            {
                Name = "Acme Towers II",
                BuildingType = "Condominium",
                Address = new UpdateBuildingDto.AddressDto()
                {
                    Province = "Metro Manila",
                    City = "Mandaluyong City",
                    AddressLine1 = "154 San Pedro St."
                },
            };

            // Act
            var response = await client.PutAsync(
                "/api/buildings/2",
                new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json"));

            // Assert
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var building = JsonSerializer.Deserialize<BuildingDto>(responseContent, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            building.Name.Should().Be("Acme Towers II");
        }

        [Fact]
        public async Task ShouldRetrieveBuilding()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetStringAsync("/api/buildings/1");

            // Assert
            var building = JsonSerializer.Deserialize<BuildingDto>(response, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            building.Id.Should().Be(1);
        }

        [Fact]
        public async Task ShouldRetrieveAllBuildings()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/api/buildings");

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
