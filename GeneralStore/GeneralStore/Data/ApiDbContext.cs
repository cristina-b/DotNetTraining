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
    }
}
