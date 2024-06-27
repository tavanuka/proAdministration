using LanguageExt;
using LanguageExt.Common;
using MapsterMapper;
using proAdministration.API.Clients;
using proAdministration.API.Clients.QueryParameters;
using proAdministration.API.Common;
using proAdministration.Shared;

namespace proAdministration.API.Services;

public class FirstVoucherService(IFirstVoucherApi client, IMapper mapper) : IFirstVoucherService
{
    public async Task<Result<List<CustomerDto>>> GetList(GetCustomersQueryParams queryParams)
    {
        var result = await client.GetList(queryParams);
        return new Result<List<CustomerDto>>(result.Unwrap());
    }

    public async Task<Result<CustomerDto>> GetById(int customerId)
    {
        var result = await client.GetById(customerId);
        return new Result<CustomerDto>(result);
    }

    public async Task<Result<CustomerDto>> Create(CustomerFirstVoucherRequest request)
    {
        var result = await client.Create(request);
        return new Result<CustomerDto>(result);
    }

    public async Task<Result<CustomerDto>> Update(int customerId, CustomerFirstVoucherRequest request)
    {
        var result = await client.Update(customerId, request);
        return new Result<CustomerDto>(result);
    }

    public async Task<Result<CustomerDto>> UpdateField(int customerId, List<CustomerFieldUpdateRequest> request)
    {
        var result = await client.UpdateField(customerId, request);
        return new Result<CustomerDto>(result);
    }

    public async Task<Result<Unit>> Delete(int customerId)
    {
        await client.Delete(customerId);
        return new Result<Unit>(Unit.Default);
    }
}