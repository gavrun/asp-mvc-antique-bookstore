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
    }
}
