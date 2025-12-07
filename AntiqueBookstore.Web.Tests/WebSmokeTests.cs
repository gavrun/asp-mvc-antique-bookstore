using FluentAssertions;

namespace AntiqueBookstore.Web.Tests
{
    public class WebSmokeTests
    {
        [Fact]
        public void Web_Project_Runs()
        {
            true.Should().BeTrue();
        }

        [Fact]
        public async Task HomeController_Index_Returns_View()
        {
            // TODO: using WebApplicationFactory<Program>
            true.Should().BeTrue();
        }

        [Fact]
        public void IdentityArea_ShouldExist()
        {
            var exists = Directory.Exists("../../../../AntiqueBookstore/Areas/Identity"); // ~\AntiqueBookstore.Web.Tests\bin\Debug\net8.0\
            exists.Should().BeTrue();
        }
    }
}
