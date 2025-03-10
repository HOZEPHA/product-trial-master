using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class DataContext(DbContextOptions options) : DbContext(options)
{
    /// <summary>
    /// DbSet for Product, which is the entity for the Product table in the database.
    /// </summary>
    public DbSet<Product> Products { get; set; }    

    /// <summary>
    /// DbSet for AppUser, which is the entity for the User table in the database.
    /// </summary>
    public DbSet<AppUser> Users { get; set; }

    /// <summary>
    /// DbSet for Basket, which is the entity for the Basket table in the database.
    /// </summary>
    public DbSet<Basket> Baskets { get; set; } // New Baskets table

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=products.db");
    }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<Product>()
    //         .Property(p => p.CreatedAt)
    //         .HasConversion(
    //             v => ((DateTimeOffset)v).ToUnixTimeMilliseconds(),  // Convert DateTime to Unix timestamp (milliseconds)
    //             v => DateTimeOffset.FromUnixTimeMilliseconds(v).DateTime // Convert Unix timestamp back to DateTime
    //         );

    //     modelBuilder.Entity<Product>()
    //         .Property(p => p.UpdatedAt)
    //         .HasConversion(
    //             v => ((DateTimeOffset)v).ToUnixTimeMilliseconds(),  // Convert DateTime to Unix timestamp (milliseconds)
    //             v => DateTimeOffset.FromUnixTimeMilliseconds(v).DateTime // Convert Unix timestamp back to DateTime
    //         );
    // }
}