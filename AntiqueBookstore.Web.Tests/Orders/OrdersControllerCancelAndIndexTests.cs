using AntiqueBookstore.Controllers;
using AntiqueBookstore.Data;
using AntiqueBookstore.Domain.Entities;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Security.Claims;

namespace AntiqueBookstore.Web.Tests.Orders
{
    public class OrdersControllerCancelAndIndexTests
    {
        private ApplicationDbContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new ApplicationDbContext(options);
        }

        private UserManager<ApplicationUser> CreateBareUserManager()
        {
            var store = new Mock<IUserStore<ApplicationUser>>();
            return new UserManager<ApplicationUser>(
                store.Object, null, null, null, null, null, null, null, null);
        }

        private UserManager<ApplicationUser> CreateUserManagerReturningUser(ApplicationUser user)
        {
            var store = new Mock<IUserStore<ApplicationUser>>();

            store.Setup(s => s.FindByIdAsync(user.Id, It.IsAny<CancellationToken>()))
                 .ReturnsAsync(user);

            return new UserManager<ApplicationUser>(
                store.Object, null, null, null, null, null, null, null, null);
        }

        private class SimpleTempDataProvider : ITempDataProvider
        {
            public IDictionary<string, object> LoadTempData(HttpContext context)
                => new Dictionary<string, object>();

            public void SaveTempData(HttpContext context, IDictionary<string, object> values) { }
        }

        private static OrdersController CreateController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            ClaimsPrincipal user)
        {
            var controller = new OrdersController(context, userManager);

            var httpContext = new DefaultHttpContext
            {
                User = user
            };

            controller.ControllerContext = new ControllerContext
            {
                HttpContext = httpContext
            };

            controller.TempData = new TempDataDictionary(httpContext, new SimpleTempDataProvider());

            return controller;
        }

        [Fact]
        public async Task CancelConfirmed_AsManager_SetsStatusToCancelled_AndRestoresBookStatus()
        {
            // Arrange
            using var context = CreateContext();

            var customer = new Customer { FirstName = "Hans", LastName = "Customer" };
            var employee = new Employee { FirstName = "Bob", LastName = "Sales", IsActive = true };

            var book = new Book
            {
                Title = "TestBook",
                PublicationDate = 1900,
                ConditionId = 1,
                StatusId = 3    // Sold, Book not available
            };

            context.Customers.Add(customer);
            context.Employees.Add(employee);
            context.Books.Add(book);
            await context.SaveChangesAsync();

            var order = new Order
            {
                CustomerId = customer.Id,
                EmployeeId = employee.Id,
                OrderDate = DateTime.Now,
                OrderStatusId = 1,       // New
                PaymentMethodId = 1
            };
            context.Orders.Add(order);
            await context.SaveChangesAsync();

            var sale = new Sale
            {
                OrderId = order.Id,
                BookId = book.Id,
                SalePrice = 150m
            };
            context.Sales.Add(sale);
            await context.SaveChangesAsync();
 
            var managerClaims = new[]
            {
                new Claim(ClaimTypes.Name, "manager@test"),
                new Claim(ClaimTypes.Role, "Manager")
            };
            var managerUser = new ClaimsPrincipal(
                new ClaimsIdentity(managerClaims, "TestAuth"));

            var userManager = CreateBareUserManager();
            var controller = CreateController(context, userManager, managerUser);

            // Act
            var result = await controller.CancelConfirmed(order.Id);

            // Assert
            var redirect = Assert.IsType<RedirectToActionResult>(result);
            redirect.ActionName.Should().Be(nameof(OrdersController.Index));

            var reloadedOrder = await context.Orders.FindAsync(order.Id);
            reloadedOrder.Should().NotBeNull();
            reloadedOrder!.OrderStatusId.Should().Be(5, "Cancelled status id is 5");

            var reloadedBook = await context.Books.FindAsync(book.Id);
            reloadedBook.Should().NotBeNull();
            reloadedBook!.StatusId.Should().Be(1, "Cancelled Orders must return Books to Available");

            context.Sales.Count().Should().Be(1, "Cancelling should not delete Sales history");
        }

        [Fact]
        public async Task CancelConfirmed_AsSales_NotOwner_Should_DenyAndNotChangeStatusOrBook()
        {
            // Arrange
            using var context = CreateContext();

            var customer = new Customer { FirstName = "Sophie", LastName = "Customer" };
            var ownerEmployee = new Employee
            {
                FirstName = "Alice",
                LastName = "Owner",
                IsActive = true,
                ApplicationUserId = "user-owner"
            };
            var otherEmployee = new Employee
            {
                FirstName = "Eve",
                LastName = "OtherSales",
                IsActive = true,
                ApplicationUserId = "user-other"
            };

            var book = new Book
            {
                Title = "Signed First Edition",
                PublicationDate = 1950,
                ConditionId = 1,
                StatusId = 3   // Sold
            };

            context.Customers.Add(customer);
            context.Employees.AddRange(ownerEmployee, otherEmployee);
            context.Books.Add(book);
            await context.SaveChangesAsync();

            var order = new Order
            {
                CustomerId = customer.Id,
                EmployeeId = ownerEmployee.Id, // belongs to owner Employee
                OrderDate = DateTime.Now,
                OrderStatusId = 1,             // New
                PaymentMethodId = 1
            };
            context.Orders.Add(order);
            await context.SaveChangesAsync();

            context.Sales.Add(new Sale
            {
                OrderId = order.Id,
                BookId = book.Id,
                SalePrice = 300m
            });
            await context.SaveChangesAsync();

            var salesUserAccount = new ApplicationUser
            {
                Id = "user-other",
                UserName = "sales2@test"
            };

            var userManager = CreateUserManagerReturningUser(salesUserAccount);

            // Sales user trying to cancel other Employee’s order
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, salesUserAccount.Id),
                new Claim(ClaimTypes.Name, salesUserAccount.UserName!),
                new Claim(ClaimTypes.Role, "Sales")
            };
            var salesPrincipal = new ClaimsPrincipal(
                new ClaimsIdentity(claims, "TestAuth"));

            var controller = CreateController(context, userManager, salesPrincipal);

            // Act
            var result = await controller.CancelConfirmed(order.Id);

            // Assert
            var redirect = Assert.IsType<RedirectToActionResult>(result);
            redirect.ActionName.Should().Be(nameof(OrdersController.Index));

            // TempData error is the visible signal
            controller.TempData["ErrorMessage"].Should().Be("You are not authorized to cancel this order.");

            var reloadedOrder = await context.Orders.FindAsync(order.Id);
            reloadedOrder.Should().NotBeNull();
            reloadedOrder!.OrderStatusId.Should().Be(1, "Unauthorized Sales must not be able to change status");

            var reloadedBook = await context.Books.FindAsync(book.Id);
            reloadedBook.Should().NotBeNull();
            reloadedBook!.StatusId.Should().Be(3, "Unauthorized cancellation must not change Book availability");

            context.Sales.Count().Should().Be(1);
        }
    }
}
