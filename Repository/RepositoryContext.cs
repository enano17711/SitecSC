using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Repository;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new MovementConfiguration());
        modelBuilder.ApplyConfiguration(new PurchaseConfiguration());
    }

    public DbSet<Product>? Products { get; set; }
    public DbSet<Movement>? Movements { get; set; }
    public DbSet<Purchase>? Purchases { get; set; }
    public DbSet<Sale>? Sales { get; set; }
}