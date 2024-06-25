using Microsoft.EntityFrameworkCore;
using proAdministration.Data.Common;
using proAdministration.Data.Entities;
using proAdministration.Data.Interceptors;

namespace proAdministration.Data.Contexts;

public class CustomerContext(DbContextOptions<CustomerContext> options) : DbContext(options)
{
    public DbSet<Customer> Customers { get; set; } = default!;
    public DbSet<Address> Addresses { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        SeedDataWithBogus(modelBuilder);
        
        modelBuilder.Entity<Customer>()
            .HasQueryFilter(x => x.IsDeleted == false);
        modelBuilder.Entity<Address>()
            .HasQueryFilter(x => x.IsDeleted == false);

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.AddInterceptors(new SoftDeleteInterceptor());

    private static void SeedDataWithBogus(ModelBuilder modelBuilder)
    {
        var dbSeeder = new DatabaseSeeder();
        modelBuilder.Entity<Address>().HasData(dbSeeder.Addresses);
        modelBuilder.Entity<Customer>().HasData(dbSeeder.Customers);
    }
}