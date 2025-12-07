using AntiqueBookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AntiqueBookstore.Data.Tests
{
    public class SchemaSmokeTests
    {
        [Fact]
        public void ApplicationDbContext_ModelBuilds()
        {
            // Arrange: use EF Core in-memory provider
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("SchemaSmokeTestDB")
                .Options;

            // Act: force EF Core constructing full metadata model, creating context must not throw
            using var context = new ApplicationDbContext(options);

            var model = context.Model;

            // Assert
            Assert.NotNull(model);
        }

        [Fact]
        public void Entities_Discovered_ByModel()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("SchemaEntityDiscoveryTestDB")
                .Options;

            using var context = new ApplicationDbContext(options);

            var model = context.Model;

            // Example types
            Assert.NotNull(model.FindEntityType(typeof(AntiqueBookstore.Domain.Entities.Book)));
            Assert.NotNull(model.FindEntityType(typeof(AntiqueBookstore.Domain.Entities.Author)));
        }

        [Fact]
        public void CanInitializeContext_AndAddEntity()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("ContextInitializeTestDB")
                .Options;

            using var context = new ApplicationDbContext(options);

            // Try adding something minimal to ensure model is usable
            context.Books.Add(new AntiqueBookstore.Domain.Entities.Book
            {
                //Id = 1,
                Title = "Test Book",
                PublicationDate = 2000,
                ConditionId = 1,
                StatusId = 1
            });

            // Adding must not throw
            context.SaveChanges();
        }

        [Fact]
        public void Model_HasExpectedRelationships()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("RelationshipSmokeTestDB")
                .Options;

            using var context = new ApplicationDbContext(options);

            var model = context.Model;

            var book = model.FindEntityType(typeof(Book));
            var author = model.FindEntityType(typeof(Author));
            var bookAuthor = model.FindEntityType(typeof(BookAuthor));

            Assert.NotNull(book);
            Assert.NotNull(author);
            Assert.NotNull(bookAuthor);

            Assert.NotNull(book.FindNavigation(nameof(Book.BookAuthors)));
            Assert.NotNull(author.FindNavigation(nameof(Author.BookAuthors)));

            var baKey = bookAuthor.FindPrimaryKey();
            Assert.Equal(2, baKey.Properties.Count); // Composite key BookId + AuthorId
        }

        [Fact]
        public void SeedData_IsAppliedCorrectly()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("SeedTestDB")
                .Options;

            using var context = new ApplicationDbContext(options);

            // Seed data is stored only in design-time model (for EF migrations)
            var designModel = context.GetService<IDesignTimeModel>().Model;

            var bookEntity = designModel.FindEntityType(typeof(Book));
            Assert.NotNull(bookEntity);
            var bookSeeds = bookEntity.GetSeedData();
            Assert.NotEmpty(bookSeeds);
        }
    }
}
