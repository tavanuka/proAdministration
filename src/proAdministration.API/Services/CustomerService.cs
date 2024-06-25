using System.ComponentModel.DataAnnotations;
using LanguageExt;
using LanguageExt.Common;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using proAdministration.API.Exceptions;
using proAdministration.Data.Contexts;
using proAdministration.Data.Entities;
using proAdministration.Shared;

namespace proAdministration.API.Services;

// New .NET 8 Syntax. Weird but cool...
public class CustomerService(CustomerContext context, IMapper mapper) : ICustomerService
{
    public async Task<Result<List<CustomerDetailsDto>>> GetList(string customerId = "")
    {
        var queryable = context.Customers
            .Include(x => x.Address)
            .AsNoTracking();

        if (!string.IsNullOrWhiteSpace(customerId))
            queryable = MapIdQuery(queryable, customerId);

        var customers = await queryable
            .ProjectToType<CustomerDetailsDto>()
            .ToListAsync();

        return new Result<List<CustomerDetailsDto>>(customers);
    }

    public async Task<Result<CustomerDetailsDto>> GetById(string customerId)
    {
        var queryable = context.Customers
            .Include(x => x.Address)
            .AsNoTracking();

        queryable = MapIdQuery(queryable, customerId);

        var customer = await queryable
            .ProjectToType<CustomerDetailsDto>()
            .FirstOrDefaultAsync();

        return customer is null
            ? new Result<CustomerDetailsDto>(
                new NotFoundException($"Customer with identifier '{customerId}' could not be found."))
            : new Result<CustomerDetailsDto>(customer);
    }

    public async Task<Result<CustomerDetailsDto>> Create(CustomerRequest request)
    {
        if (context.Customers.AsNoTracking().Any(x => x.CustomerId == request.CustomerId))
            return new Result<CustomerDetailsDto>(
                new ValidationException("Conflicting CustomerId. Please check your entry."));

        var customer = mapper.Map<Customer>(request);

        context.Customers.Add(customer);
        await context.SaveChangesAsync();

        return new Result<CustomerDetailsDto>(mapper.Map<CustomerDetailsDto>(customer));
    }

    public async Task<Result<CustomerDetailsDto>> Update(CustomerRequest request, int customerId)
    {
        if (await context.Customers.FirstOrDefaultAsync(x => x.Id == customerId) is not { } customer)
            return new Result<CustomerDetailsDto>(new NotFoundException("Customer could not be found."));

        var updatedCustomer = mapper.Map(request, customer);
        await context.SaveChangesAsync();

        return new Result<CustomerDetailsDto>(mapper.Map<CustomerDetailsDto>(updatedCustomer));
    }

    public async Task<Result<Unit>> Delete(string customerId)
    {
        var queryable = context.Customers.AsQueryable();
        queryable = MapIdQuery(queryable, customerId);

        if (await queryable.FirstOrDefaultAsync() is not { } customer)
            return new Result<Unit>(new NotFoundException("Customer could not be found."));

        context.Customers.Remove(customer);
        // Ensures deletion of both objects through soft delete.
        context.Addresses.Remove(customer.Address);

        await context.SaveChangesAsync();
        return new Result<Unit>(Unit.Default);
    }

    /// <summary>
    /// Formats the query dynamically upon identifier type.
    /// </summary>
    /// <param name="queryable">The query of the customer dataset.</param>
    /// <param name="customerId">The unique identifier of the object defined by the database or the user.</param>
    /// <returns>Filtered query by id.</returns>
    private static IQueryable<Customer> MapIdQuery(IQueryable<Customer> queryable, string customerId)
    {
        return int.TryParse(customerId, out var id)
            ? queryable.Where(x => x.Id == id)
            : queryable.Where(x => x.CustomerId == customerId);
    }
}