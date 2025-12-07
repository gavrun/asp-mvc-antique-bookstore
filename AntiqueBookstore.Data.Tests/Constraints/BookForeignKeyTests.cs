using AntiqueBookstore.Domain.Entities;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace AntiqueBookstore.Data.Tests.Constraints
{
    public class BookForeignKeyTests
    {
        [Fact]
        public void BookStatus_DeleteBehavior_Should_Be_Restrict()
        {
            using var context = new ApplicationDbContext(
                new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("book_fk1").Options);

            var entity = context.Model.FindEntityType(typeof(Book));
            var fk = entity.GetForeignKeys()
                           .First(f => f.PrincipalEntityType.ClrType == typeof(BookStatus));

            fk.DeleteBehavior.Should().Be(DeleteBehavior.Restrict);
        }

        [Fact]
        public void BookCondition_DeleteBehavior_Should_Be_Restrict()
        {
            using var context = new ApplicationDbContext(
                new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("book_fk2").Options);

            var entity = context.Model.FindEntityType(typeof(Book));
            var fk = entity.GetForeignKeys()
                           .First(f => f.PrincipalEntityType.ClrType == typeof(BookCondition));

            fk.DeleteBehavior.Should().Be(DeleteBehavior.Restrict);
        }
    }
}
