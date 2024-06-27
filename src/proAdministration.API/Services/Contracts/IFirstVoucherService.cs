using LanguageExt;
using LanguageExt.Common;
using proAdministration.API.Clients.QueryParameters;
using proAdministration.Shared;

namespace proAdministration.API.Services;

public interface IFirstVoucherService
{
    Task<Result<List<CustomerDto>>> GetList(GetCustomersQueryParams queryParams);
    Task<Result<CustomerDto>> GetById(int customerId);
    Task<Result<CustomerDto>> Create(CustomerFirstVoucherRequest request);
    Task<Result<CustomerDto>> Update(int customerId, CustomerFirstVoucherRequest request);
    Task<Result<CustomerDto>> UpdateField(int customerId, List<CustomerFieldUpdateRequest> request);
    Task<Result<Unit>> Delete(int customerId);
}