using System.Threading.Tasks;
using Learnify.Models.TokenAuth;
using Learnify.Web.Controllers;
using Shouldly;
using Xunit;

namespace Learnify.Web.Tests.Controllers
{
    public class HomeController_Tests: LearnifyWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}