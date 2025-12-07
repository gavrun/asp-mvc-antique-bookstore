using AntiqueBookstore.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Authorization;

namespace AntiqueBookstore.Web.Tests.Authorization
{
    public class AuthorizationAttributeTests
    {
        [Fact]
        public void EmployeesController_Should_Require_Manager_Role()
        {
            var controllerType = typeof(EmployeesController);

            // Read [Authorize] attributes applied to controller
            var authorizeAttributes = controllerType
                .GetCustomAttributes(typeof(AuthorizeAttribute), inherit: true)
                .Cast<AuthorizeAttribute>()
                .ToList();

            authorizeAttributes.Should().NotBeEmpty();

            authorizeAttributes.Any(a => a.Roles == "Manager")
                .Should().BeTrue("Controller is restricted to Manager role.");
        }
    }
}
