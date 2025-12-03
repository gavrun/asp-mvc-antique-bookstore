using FluentAssertions;

namespace AntiqueBookstore.Data.Tests
{
    public class DataSmokeTests
    {
        [Fact]
        public void Data_Project_Runs()
        {
            true.Should().BeTrue();
        }
    }
}
