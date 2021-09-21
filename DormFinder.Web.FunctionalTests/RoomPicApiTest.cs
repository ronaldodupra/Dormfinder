using System;
using System.Threading.Tasks;
using Xunit;

namespace DormFinder.Web.FunctionalTests
{
    public class RoomPicApiTest : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly CustomWebApplicationFactory _factory;

        public RoomPicApiTest(CustomWebApplicationFactory factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ShouldUpdateThumbnail()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task ShouldRemoveImage()
        {
            throw new NotImplementedException();
        }
    }
}
