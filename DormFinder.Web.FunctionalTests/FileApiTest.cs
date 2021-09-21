using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace DormFinder.Web.FunctionalTests
{
    public class FileApiTest : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly CustomWebApplicationFactory _factory;

        public FileApiTest(CustomWebApplicationFactory factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ShouldRetrieveFileById()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task ShouldUploadFile()
        {
            // Arrange
            var client = _factory.CreateClient();
            var fileName = "dog-puppy-on-garden.jpg";

            using var file1 = File.OpenRead($"./{fileName}");
            using var content = new StreamContent(file1);

            // Act
            using var formData = new MultipartFormDataContent();
            formData.Add(content, "file", fileName);

            var response = await client.PostAsync("api/files", formData);

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
