using AntiqueBookstore.Domain.Entities;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AntiqueBookstore.Data.Tests.Seed
{
    public class SeedDataTests
    {
        // InMemory cannot load runtime HasData()
        // Verify EF model seed correctness at design-time 
        [Fact]
        public void SeedData_Metadata_ShouldContain_BasicEntities()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("SeedDataTest")
                .Options;

            using var context = new ApplicationDbContext(options);

            // Access EF design-time model (check HasData)
            var model = context.GetService<IDesignTimeModel>().Model;

            void CheckSeedExists<TEntity>()
            {
                var entityType = model.FindEntityType(typeof(TEntity));
                entityType.Should().NotBeNull();

                var seed = entityType.GetSeedData();
                seed.Should().NotBeEmpty();
            }

            CheckSeedExists<Author>();
            CheckSeedExists<Book>();
            CheckSeedExists<BookCondition>();
            CheckSeedExists<BookStatus>();
            CheckSeedExists<Customer>();
            CheckSeedExists<PaymentMethod>();
            CheckSeedExists<Position>();
            CheckSeedExists<Level>();
            CheckSeedExists<Employee>();
            CheckSeedExists<PositionHistory>();
        }
    }
}
