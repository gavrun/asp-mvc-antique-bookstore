using AntiqueBookstore.Domain.Entities;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace AntiqueBookstore.Data.Tests.Relationships
{
    public class BookAuthorRelationshipTests
    {
        // InMemory cannot enforce FK constraints

        // Helper context
        private ApplicationDbContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new ApplicationDbContext(options);
        }

        [Fact]
        public void Book_Should_Have_Authors_Via_BookAuthor_Link()
        {
            using var context = CreateContext();

            // Insert minimal Book
            var book = new Book
            {
                Title = "Test",
                PublicationDate = 2000,
                ConditionId = 1,
                StatusId = 1,
                PurchasePrice = 10
            };

            var author = new Author
            {
                FirstName = "John",
                LastName = "Writer"
            };

            context.Books.Add(book);
            context.Authors.Add(author);
            context.SaveChanges();

            // Create link
            context.Add(new BookAuthor
            {
                BookId = book.Id,
                AuthorId = author.Id
            });

            context.SaveChanges();

            var loaded = context.Books
                .Include(b => b.BookAuthors)
                .ThenInclude(ba => ba.Author)
                .First();

            // Verify many-to-many relationship
            loaded.BookAuthors.Should().ContainSingle();
            loaded.BookAuthors.First().Author.LastName.Should().Be("Writer");
        }
    }
}
