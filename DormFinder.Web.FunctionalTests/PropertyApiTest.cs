using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using DormFinder.Web.Buildings.Models;
using DormFinder.Web.Rooms.Model;
using FluentAssertions;
using Xunit;

namespace DormFinder.Web.FunctionalTests
{
    public class PropertyApiTest : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly CustomWebApplicationFactory _factory;

        public PropertyApiTest(CustomWebApplicationFactory factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ShouldRetrievePropertyById()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("api/property/1");

            // Assert
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var property = JsonSerializer.Deserialize<RoomPropertyDto>(responseContent, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            property.Should().NotBeNull();
        }

        [Fact]
        public async Task ShouldRetrieveSimilarProperties()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task ShouldRetrievePropertyByLocation()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("api/property/filter=Metro Manila");

            // Assert
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var properties = JsonSerializer.Deserialize<IEnumerable<BuildingPropertyDto>>(responseContent, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            properties.Should().NotBeEmpty();
        }
    }
}
