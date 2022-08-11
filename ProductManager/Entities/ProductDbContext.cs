using Microsoft.EntityFrameworkCore;
using ProductManager.Models;

namespace ProductManager.Entities
{
    public class ProductDbContext : DbContext
    {
        protected readonly IConfiguration _configuration;

        public ProductDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
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
            });
            modelBuilder.Entity<CreateProductDto>(mb =>
            {
                mb.Property(x => x.Name).IsRequired();
                mb.Property(x => x.Price).IsRequired();
            });
            modelBuilder.Entity<UpdateProductDto>(mb =>
            {
                mb.Property(x => x.Id).IsRequired();
                mb.Property(x => x.Description).HasMaxLength(200);
                mb.Property(x => x.Name).HasMaxLength(100);
            });
            modelBuilder.Entity<Shop>(mb =>
            {
                mb.HasOne(x => x.Address).WithOne(y => y.Shop).HasForeignKey<Address>(z => z.ShopId);
            });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("ProductManagerDbConnectionString"));
        }
    }

}
