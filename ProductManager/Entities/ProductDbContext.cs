using Microsoft.EntityFrameworkCore;
using ProductManager.Models;

namespace ProductManager.Entities
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Shop> Shops { get; set; } = null!;
        public DbSet<Address> Addresses { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(mb =>
            {
                mb.Property(x => x.Name).HasMaxLength(100);
                mb.Property(x => x.Description).HasMaxLength(200);
                mb.Property(x => x.Price).HasColumnType("decimal(5,2)");
                mb.HasOne(x => x.Shop).WithMany(y => y.Products).HasForeignKey(z => z.ShopId);
            });
            modelBuilder.Entity<Address>(mb =>
            {
                mb.HasOne(x => x.Shop).WithOne(y => y.Address).HasForeignKey<Shop>(z => z.AddressId);
            });

        }
    }
}
