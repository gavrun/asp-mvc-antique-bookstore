using AntiqueBookstore.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection;

namespace AntiqueBookstore.Data
{
    //public class ApplicationDbContext : IdentityDbContext
    //{
    //    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    //        : base(options)
    //    {
    //    }
    //}

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> // hook up <ApplicationUser> (IdentityUser) to IdentityDbContext
    {
        // Main model entities
        public DbSet<Book> Books { get; set; } 
        public DbSet<Author> Authors { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Level> Levels { get; set; } // User entity Level
        public DbSet<Customer> Customers { get; set; }
        public DbSet<DeliveryAddress> DeliveryAddresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleEvent> SaleEvents { get; set; }

        // Other linking entities
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<PositionHistory> PositionHistories { get; set; }

        // Referencing entities (lookup tables)
        public DbSet<BookCondition> BookConditions { get; set; }
        public DbSet<BookStatus> BookStatuses { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }

        // Audit log for Sales
        public DbSet<SalesAuditLog> SalesAuditLogs { get; set; }

        // Constructor with config options
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        // Fluent API configuration
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Applly default Identity configuration for Users, Roles, etc.
            base.OnModelCreating(modelBuilder);

            // Register all IEntityTypeConfiguration<TEntity> from the current assembly

            // Apply all configurations 

            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Apply custom configurations

            // Seed static data
        }
    }
}
