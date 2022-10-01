using InventoryAPI.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace InventoryAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ProductType>().HasKey(p => p.Id);
            modelBuilder.Entity<ProductType>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<ProductType>().Property(p => p.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<ProductType>().HasMany(p => p.Products).WithOne(p => p.ProductType).HasForeignKey(p => p.ProductTypeId);

            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Product>().Property(p => p.Description).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Product>().Property(b => b.CreatedDate).HasDefaultValueSql("getdate()");


    }


    }
}
