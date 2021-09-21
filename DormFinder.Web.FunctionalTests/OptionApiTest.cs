using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using DormFinder.Web.Models;
using FluentAssertions;
using Xunit;

namespace DormFinder.Web.FunctionalTests
{
    public class OptionApiTest : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly CustomWebApplicationFactory _factory;

        public OptionApiTest(CustomWebApplicationFactory factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ShouldRetrieveCities()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("api/options/cities");

            // Assert
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var cities = JsonSerializer.Deserialize<ICollection<CityDto>>(responseContent, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            cities.Should().NotBeEmpty();
        }

        [Fact]
        public async Task ShouldRetrieveProvinces()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("api/options/provinces");

            // Assert
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var provinces = JsonSerializer.Deserialize<ICollection<ProvinceDto>>(responseContent, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            provinces.Should().NotBeEmpty();
        }
    }
}
