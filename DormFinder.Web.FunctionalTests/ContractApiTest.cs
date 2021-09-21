using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DormFinder.Web.Models;
using FluentAssertions;
using Xunit;

namespace DormFinder.Web.FunctionalTests
{
    public class ContractApiTest : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly CustomWebApplicationFactory _factory;

        public ContractApiTest(CustomWebApplicationFactory factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ShouldCreateContract()
        {
            //Arrange
            var client = _factory.CreateClient();

            var dto = new AddContractModel
            {
                RentalEffectivityDate = DateTime.Now,
                RentalEndDate = DateTime.Now.AddMonths(3),
                MoveInDate = DateTime.Now,
                MoveOutDate = DateTime.Now.AddMonths(3),
                ReservationStartDate = DateTime.Now,
                ReservationExpirationDate = DateTime.Now.AddMonths(3),
                AllowableReservationDays = 1,
                EarlyTerminationFee = 300.00,
                BasicRent = 2500.00,
                Status = "Available",
                tenantName = "John",
                UnitNumber = "001",
                BedSpaceNumber = "01",
                SecurityDeposit = 1500.00,
                RFIDDeposit = 1000.00
            };

            //Act
            var response = await client.PostAsync(
                "/api/contracts",
                new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json"));

            //Assert
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var contract = JsonSerializer.Deserialize<ContractModel>(responseContent, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            contract.Id.Should().BeOfType(typeof(int));
            contract.tenantName.Should().Be("John");
        }

        [Fact]
        public async Task ShouldRetrieveContactById()
        {
            //Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("api/contracts/1");

            // Assert
            var responseContent = await response.Content.ReadAsStringAsync();

            var contract = JsonSerializer.Deserialize<ContractModel>(responseContent, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            contract.Id.Should().Be(1);

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task ShouldUpdateContract()
        {
            //Arrange
            var client = _factory.CreateClient();

            var dto = new UpdateContractModel()
            {
                tenantName = "Odin Borson"
            };

            //Act
            var response = await client.PutAsync(
                "/api/contracts/2",
                new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json"));

            //Assert
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var contract = JsonSerializer.Deserialize<ContractModel>(responseContent, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            contract.tenantName.Should().Be("Odin Borson");
        }

        [Fact]
        public async Task ShouldRetrievePaginatedList()
        {
            //Arrange
            var client = _factory.CreateClient();

            //Act
            var response = await client.GetAsync("api/contracts");

            //Assert
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var contracts = JsonSerializer.Deserialize<PaginatedListTest<ContractModel>>(responseContent, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            contracts.Items.Should().NotBeEmpty();
        }

        [Fact]
        public async Task ShouldApproveContract()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.PostAsync("api/contracts/1/approve", null);

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
