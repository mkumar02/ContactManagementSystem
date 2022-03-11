using ContactManagementSystemWeb.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace ContactManagementSystemWebTests
{
    public class ContactControllerTests
    {
        [Fact]
        public async Task IndexTest()
        {
            var mockConfig = new Mock<IConfiguration>();
            mockConfig.SetupGet(x => x[It.Is<string>(s => s == "BaseUrl")]).Returns("https://localhost:7100/api/");
            var controller = new ContactController(mockConfig.Object);

            var result = await controller.Index();
            var viewResult = Assert.IsType<ViewResult>(result);
        }
    }
}
