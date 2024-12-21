using Luftborn.Task.Main.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Luftborn.Task.Main.Infrastructure
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "T-Shirt", Price = 99.99m, Description = "Summer T-Shirt" }
            );
        }

        public DbSet<Product> Products { get; set; }
    }
}
