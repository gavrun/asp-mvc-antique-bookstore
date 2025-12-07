using AntiqueBookstore.Domain.Entities;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace AntiqueBookstore.Data.Tests.Validation
{
    public class EntityValidationTests
    {
        // Helper context
        private ApplicationDbContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new ApplicationDbContext(options);
        }

        // Validate EF required-field enforcement
        [Fact]
        public void Saving_Book_Without_Required_Fields_Should_Fail()
        {
            using var context = CreateContext();
            
            var model = context.Model;

            var entity = model.FindEntityType(typeof(Book));
            entity.Should().NotBeNull();

            var title = entity.FindProperty(nameof(Book.Title));
            title.IsNullable.Should().BeFalse("Title is required in configuration");

            var condition = entity.FindProperty(nameof(Book.ConditionId));
            condition.IsNullable.Should().BeFalse();

            var status = entity.FindProperty(nameof(Book.StatusId));
            status.IsNullable.Should().BeFalse();
        }
    }
}
