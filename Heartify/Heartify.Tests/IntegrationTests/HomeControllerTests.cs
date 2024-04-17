using Heartify.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Heartify.Tests.IntegrationTests
{
    [TestFixture]
    public class HomeControllerTests
    {
        private HomeController homeController;

        [OneTimeSetUp]
        public void SetUp()
        {
            this.homeController = new HomeController(null);
        }

        [Test]
        public void Error500_ShouldReturnCorrectView()
        {
            var statusCode = 500;

            var result = this.homeController.Error(statusCode);

            Assert.IsNotNull(result);

            var viewResult = result as ViewResult;
            Assert.IsNotNull(viewResult);
        }
    }
}
