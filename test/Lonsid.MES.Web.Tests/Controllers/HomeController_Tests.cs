using System.Threading.Tasks;
using Lonsid.MES.Web.Controllers;
using Shouldly;
using Xunit;

namespace Lonsid.MES.Web.Tests.Controllers
{
    public class HomeController_Tests: MESWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}
