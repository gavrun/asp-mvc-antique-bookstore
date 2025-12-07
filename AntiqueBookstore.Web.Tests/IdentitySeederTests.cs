using AntiqueBookstore.Data;
using AntiqueBookstore.Data.Seed;
using AntiqueBookstore.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AntiqueBookstore.Web.Tests
{
    public class IdentitySeederTests
    {
        private ServiceProvider BuildServiceProvider()
        {
            var services = new ServiceCollection();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("IdentitySeederTestDB"));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddLogging();

            return services.BuildServiceProvider();
        }

        [Fact]
        public async Task IdentitySeeder_CreatesRoles()
        {
            // Arrange
            var sp = BuildServiceProvider();

            using var scope = sp.CreateScope();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

            // Act
            await IdentitySeeder.SeedRolesAsync(roleManager, logger);

            // Assert
            Assert.True(await roleManager.RoleExistsAsync("Manager"));
            Assert.True(await roleManager.RoleExistsAsync("Sales"));
        }

        //[Fact]
        //public async Task IdentitySeeder_CreatesUsers()
        //{

        //}
    }
}
