using Xunit;

namespace DormFinder.Web.FunctionalTests
{
    public class ExternalSigninApiTest : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly CustomWebApplicationFactory _factory;

        public ExternalSigninApiTest(CustomWebApplicationFactory factory)
        {
            _factory = factory;
        }
    }
}
