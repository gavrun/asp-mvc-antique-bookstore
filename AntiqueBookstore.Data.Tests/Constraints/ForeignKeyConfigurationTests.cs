using AntiqueBookstore.Domain.Entities;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace AntiqueBookstore.Data.Tests.Constraints
{
    public class ForeignKeyConfigurationTests
    {
        [Fact]
        public void Author_BookAuthor_DeleteBehavior_Should_Be_Restrict()
        {
            // InMemory cannot enforce FK constraints
            // Verify EF model metadata at design-time 

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("FKConfigTest")
                .Options;

            using var context = new ApplicationDbContext(options);

            var model = context.Model;

            // BookAuthor join table must exist in model
            var bookAuthorEntity = model.FindEntityType(typeof(BookAuthor));
            bookAuthorEntity.Should().NotBeNull();

            // DeleteBehavior must be configured with restrict in model
            var fk = bookAuthorEntity
                .GetForeignKeys()
                .First(f => f.PrincipalEntityType.ClrType == typeof(Author));

            fk.DeleteBehavior.Should().Be(DeleteBehavior.Restrict);
        }
    }
}
