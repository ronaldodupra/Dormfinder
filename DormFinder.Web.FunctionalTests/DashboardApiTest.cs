using System;
using System.Threading.Tasks;
using Xunit;

namespace DormFinder.Web.FunctionalTests
{
    public class DashboardApiTest : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly CustomWebApplicationFactory _factory;

        public DashboardApiTest(CustomWebApplicationFactory factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ShouldRetrieveRoomChart()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task ShouldRetrieveRoomChartByFilter()
        {
            throw new NotImplementedException();
        }
    }
}
