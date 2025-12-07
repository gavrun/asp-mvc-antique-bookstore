using AntiqueBookstore.Domain.Entities;
using FluentAssertions;

namespace AntiqueBookstore.Domain.Tests.Orders
{
    public class OrderTotalAmountTests
    {
        [Fact]
        public void TotalAmount_Sums_All_Sales_Prices()
        {
            var order = new Order
            {
                Sales =
                {
                    new Sale { SalePrice = 10 },
                    new Sale { SalePrice = 15.5m },
                    new Sale { SalePrice = 4.5m }
                }
            };

            order.TotalAmount.Should().Be(30m);
        }

        [Fact]
        public void TotalAmount_Is_Zero_When_No_Sales()
        {
            var order = new Order();

            order.TotalAmount.Should().Be(0m);
        }
    }
}
