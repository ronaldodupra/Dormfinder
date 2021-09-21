using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using DormFinder.Web.Rooms.Model;
using FluentAssertions;
using Xunit;

namespace DormFinder.Web.FunctionalTests
{
    public class RentApiTest : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly CustomWebApplicationFactory _factory;

        public RentApiTest(CustomWebApplicationFactory factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ShouldRetrieveRooms()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("api/rent");

            // Assert
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var rooms = JsonSerializer.Deserialize<IEnumerable<RentRoomDto>>(responseContent, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            rooms.Should().NotBeEmpty();
        }

        [Fact]
        public async Task ShouldRetrieveRoomsByFilters()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("api/rent/location=Mandaluyong&minprice=5000&maxprice=10000");

            // Assert
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var rooms = JsonSerializer.Deserialize<IEnumerable<RentRoomDto>>(responseContent, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            rooms.Should().NotBeEmpty();
        }
    }
}
