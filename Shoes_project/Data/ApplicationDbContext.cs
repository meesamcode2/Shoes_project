using Microsoft.EntityFrameworkCore;
using Shoes_project.Models;

namespace Shoes_project.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<MembershipLevel> MembershipLevels { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Delivery> Deliveries { get; set; } = null!;
        public DbSet<Promotion> Promotions { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

    }
}