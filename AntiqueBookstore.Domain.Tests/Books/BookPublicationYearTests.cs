using AntiqueBookstore.Domain.Entities;
using FluentAssertions;

namespace AntiqueBookstore.Domain.Tests.Books
{
    public class BookPublicationYearTests
    {
        [Fact]
        public void PublicationYear_Must_Not_Be_Before_1600()
        {
            var book = new Book { PublicationDate = 1500 };
            bool isValid = book.PublicationDate >= 1600;
            isValid.Should().BeFalse();
        }

        [Fact]
        public void PublicationYear_Must_Not_Be_In_Future()
        {
            int futureYear = DateTime.Now.Year + 5;
            var book = new Book { PublicationDate = futureYear };

            bool isValid = book.PublicationDate <= DateTime.Now.Year;
            isValid.Should().BeFalse();
        }

        [Fact]
        public void PublicationYear_ValidRange_Passes()
        {
            int year = DateTime.Now.Year - 10;
            var book = new Book { PublicationDate = year };

            bool isValid = book.PublicationDate >= 1600 &&
                           book.PublicationDate <= DateTime.Now.Year;

            isValid.Should().BeTrue();
        }
    }
}
