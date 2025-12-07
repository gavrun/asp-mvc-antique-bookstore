using AntiqueBookstore.Domain.Entities;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace AntiqueBookstore.Data.Tests.Constraints
{
    public class CustomerEmailTests
    {
        [Fact]
        public void Customer_Email_Should_Have_Unique_Index()
        {
            using var context = new ApplicationDbContext(
                new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("cust_idx").Options);

            var entity = context.Model.FindEntityType(typeof(Customer));
            var indexes = entity.GetIndexes();

            indexes.Should().Contain(i => i.IsUnique && i.Properties.Any(p => p.Name == "Email"));
        }
    }
}
