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

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("ProductManagerDbConnectionString"));
        }
    }

}
