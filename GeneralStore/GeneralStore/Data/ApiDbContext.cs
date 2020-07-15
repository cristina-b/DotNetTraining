using Microsoft.EntityFrameworkCore;
using GeneralStore.Entities;
namespace GeneralStore.Data
{
    using GeneralStore.Entities;
    using Microsoft.EntityFrameworkCore;

    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<GeneralStore.Entities.Category> Category { get; set; }

        public DbSet<GeneralStore.Entities.Customer> Customer { get; set; }

        public DbSet<GeneralStore.Entities.Order> Order { get; set; }

        public DbSet<GeneralStore.Entities.Payment> Payment { get; set; }
    }
}
