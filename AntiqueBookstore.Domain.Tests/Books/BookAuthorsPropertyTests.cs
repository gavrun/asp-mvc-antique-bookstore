using AntiqueBookstore.Domain.Entities;
using FluentAssertions;

namespace AntiqueBookstore.Domain.Tests.Books
{
    public class BookAuthorsPropertyTests
    {
        [Fact]
        public void Authors_Property_Returns_All_Authors_From_BookAuthors()
        {
            // Arrange
            var author1 = new Author { FirstName = "John", LastName = "Doe" };
            var author2 = new Author { FirstName = "Jane", LastName = "Smith" };

            var book = new Book
            {
                Title = "TestBook",
                PublicationDate = 2000,
                ConditionId = 1,
                StatusId = 1,
                BookAuthors =
                {
                    new BookAuthor { Author = author1 },
                    new BookAuthor { Author = author2 }
                }
            };

            // Act
            var authors = book.Authors.ToList();

            // Assert
            authors.Should().HaveCount(2, "a book with two BookAuthor links must expose two authors");
            authors.Should().Contain(a => a.LastName == "Doe");
            authors.Should().Contain(a => a.LastName == "Smith");
        }
    }
}
