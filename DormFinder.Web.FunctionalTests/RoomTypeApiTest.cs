using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using DormFinder.Web.Entities;
using Xunit;

namespace DormFinder.Web.FunctionalTests
{
    public class RoomTypeApiTest : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly CustomWebApplicationFactory _factory;

        public RoomTypeApiTest(CustomWebApplicationFactory factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ShouldRetrieveRoomTypes()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("api/roomType");

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
