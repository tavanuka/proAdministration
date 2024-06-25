using Microsoft.EntityFrameworkCore;
using proAdministration.Data.Common;
using proAdministration.Data.Entities;

namespace proAdministration.Data.Contexts;

public class CustomerContext(DbContextOptions<CustomerContext> options) : DbContext(options)
{
    public DbSet<Customer> Customers { get; set; } = default!;
    public DbSet<Address> Addresses { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        SeedDataWithBogus(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }

    private static void SeedDataWithBogus(ModelBuilder modelBuilder)
    {
        var dbSeeder = new DatabaseSeeder();
        modelBuilder.Entity<Address>().HasData(dbSeeder.Addresses);
        modelBuilder.Entity<Customer>().HasData(dbSeeder.Customers);
    }
}