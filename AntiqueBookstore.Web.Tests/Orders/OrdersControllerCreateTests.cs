using AntiqueBookstore.Controllers;
using AntiqueBookstore.Data;
using AntiqueBookstore.Domain.Entities;
using AntiqueBookstore.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace AntiqueBookstore.Web.Tests.Orders
{
    public class OrdersControllerCreateTests
    {
        private ApplicationDbContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new ApplicationDbContext(options);
        }

        // Minimal fake UserManager
        private UserManager<ApplicationUser> FakeUserManager()
        {
            var store = new Mock<IUserStore<ApplicationUser>>();
            return new UserManager<ApplicationUser>(
                store.Object, null, null, null, null, null, null, null, null
            );
        }

        private class SimpleTempDataProvider : ITempDataProvider
        {
            public IDictionary<string, object> LoadTempData(HttpContext context)
                => new Dictionary<string, object>();

            public void SaveTempData(HttpContext context, IDictionary<string, object> values) { }
        }

        [Fact]
        public async Task Create_ValidOrder_CreatesOrderAndSale()
        {
            using var context = CreateContext();

            // Required FK entities
            var customer = new Customer { FirstName = "Jane", LastName = "Customer" };
            var employee = new Employee { FirstName = "Eve", LastName = "Seller" };
            var payment = new PaymentMethod { Name = "Cash", IsActive = true };
            var status = new OrderStatus { Name = "New" };

            context.Customers.Add(customer);
            context.Employees.Add(employee);
            context.PaymentMethods.Add(payment);
            context.OrderStatuses.Add(status);

            var book = new Book
            {
                Title = "Order Book",
                PublicationDate = 2000,
                ConditionId = 1,
                StatusId = 1,
                PurchasePrice = 10,
                RecommendedPrice = 15
            };

            context.Books.Add(book);
            await context.SaveChangesAsync();

            var userManager = FakeUserManager();
            var logger = LoggerFactory.Create(b => b.AddDebug()).CreateLogger<OrdersController>();

            var controller = new OrdersController(context, userManager);
            controller.TempData = new TempDataDictionary(
                new DefaultHttpContext(),
                new SimpleTempDataProvider()
            );

            var vm = new OrderCreateViewModel
            {
                OrderDate = DateTime.Today,
                SelectedCustomerId = customer.Id,
                SelectedEmployeeId = employee.Id,
                SelectedPaymentMethodId = payment.Id,
                SelectedOrderStatusId = status.Id,
                Sales = new List<SaleCreateItemViewModel>
                {
                    new SaleCreateItemViewModel
                    {
                        BookId = book.Id,
                        SalePrice = 20m
                    }
                }
            };

            // Act
            var result = await controller.Create(vm);

            // Assert
            context.Orders.Count().Should().Be(1);
            context.Sales.Count().Should().Be(1);

            var order = context.Orders.Include(o => o.Sales).First();

            var sale = order.Sales.First();
            sale.BookId.Should().Be(book.Id);
            sale.SalePrice.Should().Be(20m);

            // Controller returns new Order
            var redirect = Assert.IsType<RedirectToActionResult>(result);
            redirect.ActionName.Should().Be("Details");
            redirect.RouteValues!["id"].Should().Be(order.Id);
        }
    }
}
