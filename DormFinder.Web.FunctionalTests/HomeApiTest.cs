using Xunit;

namespace DormFinder.Web.FunctionalTests
{
    public class HomeApiTest : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly CustomWebApplicationFactory _factory;

        public HomeApiTest(CustomWebApplicationFactory factory)
        {
            _factory = factory;
        }
    }
}
