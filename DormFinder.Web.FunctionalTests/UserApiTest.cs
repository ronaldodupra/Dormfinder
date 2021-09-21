using System;
using System.Threading.Tasks;
using Xunit;

namespace DormFinder.Web.FunctionalTests
{
    public class UserApiTest : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly CustomWebApplicationFactory _factory;

        public UserApiTest(CustomWebApplicationFactory factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ShouldRetrieveCurrentUser()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task ShouldRetrieveUserImage()
        {
            throw new NotImplementedException();
        }
    }
}
