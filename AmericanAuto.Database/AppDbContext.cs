using AmericanAuto.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace AmericanAuto.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }


        public DbSet<Customer> Customers { get; set; }
        public DbSet<Parts> Parts { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships here using Fluent API

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Vehicles)
                .WithOne(v => v.Customer)
                .HasForeignKey(v => v.CustomerId);

            modelBuilder.Entity<Vehicle>()
                .HasMany(v => v.Parts)
                .WithOne(p => p.Vehicle)
                .HasForeignKey(p => p.VehicleId);
        }
    }
}
