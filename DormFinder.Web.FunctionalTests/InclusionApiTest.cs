using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using DormFinder.Web.Entities;
using FluentAssertions;
using Xunit;

namespace DormFinder.Web.FunctionalTests
{
    public class InclusionApiTest : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly CustomWebApplicationFactory _factory;

        public InclusionApiTest(CustomWebApplicationFactory factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ShouldRetrieveInclusions()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("api/inclusion");

            // Assert
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var inclusions = JsonSerializer.Deserialize<IEnumerable<Inclusion>>(responseContent, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            inclusions.Should().NotBeEmpty();
        }
    }
}
