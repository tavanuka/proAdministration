using Bogus;
using proAdministration.Data.Entities;

namespace proAdministration.Data.Common;

public class DatabaseSeeder
{
    public List<Customer> Customers { get; }
    public List<Address> Addresses { get; }

    public DatabaseSeeder()
    {
        const int amount = 50;
        Customers = GenerateCustomers(amount);
        Addresses = GenerateCustomerAddresses(amount);
    }

    private static List<Address> GenerateCustomerAddresses(int amount)
    {
        var addressId = 1;
        var addressFaker = new Faker<Address>("de")
            .RuleFor(x => x.Id, _ => addressId++)
            .RuleFor(x => x.Street, f => f.Address.StreetAddress())
            .RuleFor(x => x.City, f => f.Address.City())
            .RuleFor(x => x.State, f => f.Address.State())
            .RuleFor(x => x.PostalCode, f => f.Address.ZipCode())
            .RuleFor(x => x.Country, _ => "Deutschland");

        var addresses = Enumerable
            .Range(1, amount)
            .Select(i => SeedRow(addressFaker, i))
            .ToList();

        return addresses;
    }

    private static List<Customer> GenerateCustomers(int amount)
    {
        string[] emailPrefixes = ["business", "hr", "info"];
        var customerId = 1;
        var fkAddressId = 1;

        var customerFaker = new Faker<Customer>("de")
            .RuleFor(x => x.Id, _ => customerId++)
            .RuleFor(x => x.CustomerId, f => f.Random.Replace("###-######"))
            .RuleFor(x => x.Name, f => f.Company.CompanyName())
            .RuleFor(x => x.Email,
                (f, u) => f.Internet
                    .Email(
                        firstName: f.PickRandom(emailPrefixes),
                        lastName: f.Name.LastName(),
                        provider: $"{FormatHelpers.FormatBogusCompanyName(u.Name)}.de")
                    .ToLower())
            .RuleFor(x => x.PhoneNumber, f => f.Phone.PhoneNumber())
            .RuleFor(x => x.Currency, _ => "EUR")
            .RuleFor(x => x.AddressId, _ => fkAddressId++);

        var customers = Enumerable
            .Range(1, amount)
            .Select(i => SeedRow(customerFaker, i))
            .ToList();

        return customers;
    }

    private static T SeedRow<T>(Faker<T> faker, int rowId) where T : class
    {
        var recordRow = faker.UseSeed(rowId).Generate();
        return recordRow;
    }
}