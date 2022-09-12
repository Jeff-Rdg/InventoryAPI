using InventoryAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace InventoryAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasOne<ProductType>(p => p.ProductType).WithMany(p => p.Products).HasForeignKey(f => f.ProductTypeId);
        }


    }
}
