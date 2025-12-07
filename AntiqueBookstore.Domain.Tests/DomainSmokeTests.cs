using AntiqueBookstore.Domain.Entities;
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

        [Fact]
        public void Basic_Domain_Model_Instantiates()
        {
            var book = new AntiqueBookstore.Domain.Entities.Book();
            var order = new AntiqueBookstore.Domain.Entities.Order();
            var employee = new AntiqueBookstore.Domain.Entities.Employee();

            book.Should().NotBeNull();
            order.Should().NotBeNull();
            employee.Should().NotBeNull();
        }
    }
}
