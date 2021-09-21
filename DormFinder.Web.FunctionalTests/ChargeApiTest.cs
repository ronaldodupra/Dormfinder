using System.Net.Http;
using System.Text;
using System.Text.Json;
using DormFinder.Web.Charges.Models;
using FluentAssertions;
using Xunit;

namespace DormFinder.Web.FunctionalTests
{
    public class ChargeApiTest : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly CustomWebApplicationFactory _factory;

        public ChargeApiTest(CustomWebApplicationFactory factory)
        {
            _factory = factory;
        }

        [Fact]
        public async void ShouldRetievePaginatedList()
        {
            //Arrange
            var client = _factory.CreateClient();

            //Act
            var response = await client.GetAsync("api/charges");

            //Assert
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var charges = JsonSerializer.Deserialize<PaginatedListTest<ChargeDto>>(responseContent, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            charges.Items.Should().NotBeEmpty();
        }

        [Fact]
        public async void ShouldRetrieveChargeById()
        {
            //Arrange
            var client = _factory.CreateClient();

            //Act
            var response = await client.GetAsync("api/charges/1");

            // Assert
            var responseContent = await response.Content.ReadAsStringAsync();

            var charge = JsonSerializer.Deserialize<ChargeDto>(responseContent, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            charge.Id.Should().Be(1);

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async void ShouldCreateCharge()
        {
            //Arrange
            var client = _factory.CreateClient();

            var dto = new CreateChargeDto()
            {
                BillingStatementOrder = 1,
                DefaultCharge = 100,
                Comments = "Description",
                IsVat = true
            };

            //Act
            var response = await client.PostAsync(
                "/api/charges",
                new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json"));

            //Assert
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var charge = JsonSerializer.Deserialize<ChargeDto>(responseContent, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            charge.Id.Should().BeOfType(typeof(int));
            charge.BillingStatementOrder.Should().Be(1);
        }

        [Fact]
        public async void ShouldUpdateCharge()
        {
            //Arrange
            var client = _factory.CreateClient();

            var dto = new CreateChargeDto()
            {
                BillingStatementOrder = 3,
                DefaultCharge = 2000,
                IsVat = true,
                Comments = "Update Charge"
            };

            //Act
            var response = await client.PutAsync(
                "/api/charges/2",
                new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json"));

            //Assert
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var charge = JsonSerializer.Deserialize<ChargeDto>(responseContent, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            charge.DefaultCharge.Should().Be(2000);
            charge.Id.Should().Be(2);
        }
    }
}
