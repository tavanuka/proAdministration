using LanguageExt;
using LanguageExt.Common;
using proAdministration.Shared;

namespace proAdministration.API.Services;

public interface ICustomerService
{
    Task<Result<List<CustomerDetailsDto>>> GetList(string customerId = "");
    Task<Result<CustomerDetailsDto>> GetById(string customerId);
    Task<Result<CustomerDetailsDto>> Create(CustomerRequest request);
    Task<Result<Unit>> Delete(string customerId);
    Task<Result<CustomerDetailsDto>> Update(CustomerRequest request, int customerId);
}