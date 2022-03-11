using ContactManagementSystemModel;
using ContactManagementSystemWeb.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ContactManagementSystemWebTests.Controllers
{
    public class ContactControllerTests
    {
        [Fact]
        public async Task IndexTest_ReturnsViewResultWithListOfContacts()
        {
            var mockConfig = new Mock<IConfiguration>();
            mockConfig.SetupGet(x => x[It.Is<string>(s => s == "BaseUrl")]).Returns("https://localhost:7100/api/");
            var controller = new ContactController(mockConfig.Object);

            var result = await controller.Index();
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Contact>>(viewResult.ViewData.Model);
            //Assert.Equal(1, model.Count());   //This test will pass only till records count in db is 1. That's why commented it out
            Assert.Equal("Manish Kumar", model.First(m => m.Id == 1).Name);
        }
    }
}
