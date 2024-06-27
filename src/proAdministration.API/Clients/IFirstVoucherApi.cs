using proAdministration.API.Clients.QueryParameters;
using proAdministration.Shared;
using Refit;

namespace proAdministration.API.Clients;

[Headers(
    "Content-Type: application/json",
    "Accept: application/json")]
public interface IFirstVoucherApi
{
    [Get("/api/data/customer")]
    Task<Shared.ApiResponse<List<CustomerDto>>> GetList([Query] GetCustomersQueryParams queryParams);

    [Get("/api/data/customer/{customerId}")]
    Task<CustomerDto> GetById(int customerId);

    [Post("/api/data/customer")]
    Task<CustomerDto> Create(CustomerFirstVoucherRequest request);

    [Put("/api/data/customer/{customerId}")]
    Task<CustomerDto> Update(int customerId, CustomerFirstVoucherRequest request);

    [Patch("/api/data/customer/{customerId}")]
    Task<CustomerDto> UpdateField(int customerId, [Body] List<CustomerFieldUpdateRequest> request);

    [Delete("/api/data/customer/{customerId}")]
    Task Delete(int customerId);
}