using AntiqueBookstore.Domain.Entities;
using FluentAssertions;

namespace AntiqueBookstore.Domain.Tests.Orders
{
    public class OrderStatusTests
    {
        [Theory]
        [InlineData(1)] // New
        [InlineData(2)] // Processing
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)] // Cancelled
        [InlineData(6)]
        [InlineData(7)]
        public void Order_Allows_Only_Valid_StatusIds(int validStatus)
        {
            var order = new Order { OrderStatusId = validStatus };
            order.OrderStatusId.Should().Be(validStatus);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(8)]
        public void OrderStatus_OtherValues_ShouldBeConsideredInvalid(int status)
        {
            var order = new Order { OrderStatusId = status };

            bool isValid = status is >= 1 and <= 5;

            isValid.Should().BeFalse("Only valid(seeded) statuses 1..7 are valid");
        }

        [Fact]
        public void Delivered_Order_Requires_PaymentDate()
        {
            var order = new Order
            {
                OrderStatusId = 4, // Delivered
                PaymentDate = null
            };

            bool isValid = order.OrderStatusId == 4 && order.PaymentDate != null;

            isValid.Should().BeFalse("Delivered Orders must have PaymentDate");
        }
    }
}
