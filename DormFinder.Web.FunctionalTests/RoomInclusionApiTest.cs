using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using static DormFinder.Web.Rooms.Model.RoomDto;

namespace DormFinder.Web.FunctionalTests
{
    public class RoomInclusionApiTest : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly CustomWebApplicationFactory _factory;

        public RoomInclusionApiTest(CustomWebApplicationFactory factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ShouldRetrieveRoomInclusions()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("api/RoomInclusion/1/getInclusion");

            // Assert
            response.EnsureSuccessStatusCode();
            
            var responseContent = await response.Content.ReadAsStringAsync();
            var roomInclusions = JsonSerializer.Deserialize<IEnumerable<RoomInclusionDto>>(responseContent, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            roomInclusions.Should().NotBeEmpty();
        }
    }
}
