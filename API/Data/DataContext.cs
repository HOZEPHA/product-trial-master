using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class DataContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=products.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.CreatedAt)
                .HasConversion(
                    v => ((DateTimeOffset)v).ToUnixTimeMilliseconds(),  // Convert DateTime to Unix timestamp (milliseconds)
                    v => DateTimeOffset.FromUnixTimeMilliseconds(v).DateTime // Convert Unix timestamp back to DateTime
                );

            modelBuilder.Entity<Product>()
                .Property(p => p.UpdatedAt)
                .HasConversion(
                    v => ((DateTimeOffset)v).ToUnixTimeMilliseconds(),  // Convert DateTime to Unix timestamp (milliseconds)
                    v => DateTimeOffset.FromUnixTimeMilliseconds(v).DateTime // Convert Unix timestamp back to DateTime
                );
        }
}