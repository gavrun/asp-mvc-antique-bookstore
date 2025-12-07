using AntiqueBookstore.Controllers;
using AntiqueBookstore.Data;
using AntiqueBookstore.Domain.Entities;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;

namespace AntiqueBookstore.Web.Tests.Employees
{
    public class EmployeesControllerEditInactiveTests
    {
        [Fact]
        public async Task Edit_InactiveEmployee_Should_RedirectToIndex()
        {
            using var context = new ApplicationDbContext(
                new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options);

            context.Employees.Add(new Employee
            {
                Id = 10,
                FirstName = "Test",
                LastName = "Test",
                HireDate = DateTime.Now,
                IsActive = false
            });
            await context.SaveChangesAsync();

            var controller = new EmployeesController(
                context,
                NullLogger<EmployeesController>.Instance,
                FakeUserManager());

            controller.TempData = new TempDataDictionary(new DefaultHttpContext(), new SimpleTempDataProvider());

            var result = await controller.Edit(10);

            var redirect = Assert.IsType<RedirectToActionResult>(result);
            redirect.ActionName.Should().Be(nameof(EmployeesController.Index));
        }

        private UserManager<ApplicationUser> FakeUserManager()
            => new UserManager<ApplicationUser>(new Mock<IUserStore<ApplicationUser>>().Object,
                null, null, null, null, null, null, null, null);

        private class SimpleTempDataProvider : ITempDataProvider
        {
            public IDictionary<string, object> LoadTempData(HttpContext context) => new Dictionary<string, object>();
            public void SaveTempData(HttpContext context, IDictionary<string, object> values) { }
        }
    }
}
