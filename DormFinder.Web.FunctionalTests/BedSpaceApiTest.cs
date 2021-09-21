using System;
using System.Threading.Tasks;
using Xunit;

namespace DormFinder.Web.FunctionalTests
{
    public class BedSpaceApiTest : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly CustomWebApplicationFactory _factory;

        public BedSpaceApiTest(CustomWebApplicationFactory factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ShouldRetrieveBedSpacesByRoom()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task ShouldRetrieveBedSpaceById()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task ShouldCreateBedSpace()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task ShouldUpdateBedSpace()
        {
            throw new NotImplementedException();
        }
    }
}
