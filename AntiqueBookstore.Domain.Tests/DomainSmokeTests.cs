using FluentAssertions;

namespace AntiqueBookstore.Domain.Tests
{
    public class DomainSmokeTests
    {
        [Fact]
        public void Domain_Project_Runs()
        {
            true.Should().BeTrue();
        }
    }
}
