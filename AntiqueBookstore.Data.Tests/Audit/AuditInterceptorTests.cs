using AntiqueBookstore.Data.Interceptors;
using AntiqueBookstore.Domain.Entities;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AntiqueBookstore.Data.Tests.Audit
{
    public class AuditInterceptorTests
    {
        // Helper context with the SalesAuditInterceptor registered
        private ApplicationDbContext CreateContext(out IHttpContextAccessor accessor)
        {
            var services = new ServiceCollection();

            accessor = new HttpContextAccessor
            {
                HttpContext = new DefaultHttpContext()
            };

            // Fake authenticated user
            accessor.HttpContext.User = new System.Security.Claims.ClaimsPrincipal(
                new System.Security.Claims.ClaimsIdentity(
                    new[] { new System.Security.Claims.Claim("name", "TestUser") }, "TestAuth"
                )
            );

            services.AddSingleton<IHttpContextAccessor>(accessor);

            services.AddDbContext<ApplicationDbContext>((sp, options) =>
            {
                options
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .AddInterceptors(new SalesAuditInterceptor(sp.GetRequiredService<IHttpContextAccessor>()));
            });

            var provider = services.BuildServiceProvider();
            return provider.GetRequiredService<ApplicationDbContext>();
        }

        [Fact]
        public void Saving_Sale_Creates_AuditLog_Entry()
        {
            using var context = CreateContext(out var accessor);

            // Insert minimal Book
            var book = new Book
            {
                Title = "Test",
                PublicationDate = 2000,
                PurchasePrice = 10,
                ConditionId = 1,
                StatusId = 1
            };

            context.Books.Add(book);

            // Insert minimal Order
            var order = new Order
            {
                CustomerId = 1,
                OrderDate = DateTime.Now,
                OrderStatusId = 1
            };

            context.Orders.Add(order);
            context.SaveChanges();

            // Insert minimal Sale
            var sale = new Sale
            {
                SalePrice = 10,
                BookId = book.Id
            };

            context.Sales.Add(sale);
            context.SaveChanges();  // trigger interceptor

            // Collect all audit logs records and filter
            var log = context.SalesAuditLogs.ToList();
            var saleLog = log.Where(l => l.TableName == "Sale" && l.Operation == "Added").ToList();

            saleLog.Should().NotBeEmpty("Saving a Sale must create audit entries for its properties");
        }
    }
}
