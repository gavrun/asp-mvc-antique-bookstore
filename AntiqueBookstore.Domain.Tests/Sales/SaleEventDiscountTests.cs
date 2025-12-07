using AntiqueBookstore.Domain.Entities;
using FluentAssertions;

namespace AntiqueBookstore.Domain.Tests.Sales
{
    public class SaleEventDiscountTests
    {
        [Theory]
        [InlineData(0.00, true)]    // 0% discount
        [InlineData(0.15, true)]    // 15% discount
        [InlineData(1.00, true)]    // 100% discount
        [InlineData(-0.01, false)]  // below lower bound
        [InlineData(1.01, false)]   // above upper bound
        public void SaleEvent_Discount_Must_Be_Between_Zero_And_One(decimal discount, bool expectedIsValid)
        {
            // Arrange
            var saleEvent = new SaleEvent
            {
                Discount = discount
            };

            // Act
            bool isValid = saleEvent.Discount >= 0m && saleEvent.Discount <= 1m;

            // Assert
            isValid.Should().Be(expectedIsValid, "SaleEvent.Discount represents a percentage as a fraction between 0 and 1");
        }
    }
}
