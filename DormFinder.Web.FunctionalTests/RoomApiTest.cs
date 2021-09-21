using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DormFinder.Web.Models;
using DormFinder.Web.Rooms.Models;
using FluentAssertions;
using Xunit;
using DormFinder.Web.Rooms.Model;

namespace DormFinder.Web.FunctionalTests
{
    public class RoomApiTest : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly CustomWebApplicationFactory _factory;

        public RoomApiTest(CustomWebApplicationFactory factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ShouldRetrieveRoomsByBuildingFloor()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task ShouldRetrieveRoomById()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("api/rooms/1");

            // Assert
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var room = JsonSerializer.Deserialize<RoomDto>(responseContent, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            room.Id.Should().Be(1);
        }

        [Fact]
        public async Task ShouldUpdateRoom()
        {
            //Arrange
            var client = _factory.CreateClient();

            var dto = new CreateRoomDto()
            {
                Area = 100,
                RoomName = "Room 101",
                RoomNumber = "101",
                Description = "Acme Tower, 1st Floor, Room 101"
            };

            //Act
            var response = await client.PutAsync(
                "/api/charges/2",
                new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json"));

            //Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task ShouldRetrieveRoomByContract()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task ShouldCreateRoom()
        {
            //Arrange
            var client = _factory.CreateClient();            

            var dto = new CreateRoomDto()
            {
                Area = 100,
                RoomName = "Room 401",
                RoomNumber = "401",
                Description = "Acme Tower, 4th Floor, Room 401",
                Occupant = 4,
                FileEntries = new CreateRoomDto.FileEntryDto[] { },
                RoomInclusions = new int[] { },
                floorId = 1,
                type = 1,
                BasicRent = 5000,
                AdvanceRent = 1000,
                BuildingId = 1,
                SecurityDeposit = 1000
            };

            //Act
            var response = await client.PostAsync(
                "/api/rooms",
                new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json"));

            //Assert
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var room = JsonSerializer.Deserialize<RoomDto>(responseContent, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            room.Id.Should().BeOfType(typeof(int));
        }

        [Fact]
        public async Task ShouldRetrieveRooms()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("api/rooms/rooms");

            // Assert
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var rooms = JsonSerializer.Deserialize<IEnumerable<RoomDto>>(responseContent, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            rooms.Should().NotBeEmpty();
        }

        [Fact]
        public async Task ShouldRetrievePaginatedList()
        {
            //Arrange
            var client = _factory.CreateClient();

            //Act
            var response = await client.GetAsync("api/rooms/byBuildingFloor");

            //Assert
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var rooms = JsonSerializer.Deserialize<PaginatedListTest<RoomDto>>(responseContent, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            rooms.Items.Should().NotBeEmpty();
        }
    }
}
