using Microsoft.AspNetCore.Mvc;
using proAdministration.API.Attributes;
using proAdministration.API.Clients.QueryParameters;
using proAdministration.API.Exceptions;
using proAdministration.API.Services;
using proAdministration.Shared;

namespace proAdministration.API.Controllers;

[Tags("Customers - External")]
[FirstVoucherRoute(Route = "customers")]
public class FirstVoucherCustomersController(IFirstVoucherService firstVoucherService) : FirstVoucherControllerBase
{
    [HttpGet]
    [ProducesResponseType<List<CustomerDto>>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get([FromQuery] GetCustomersQueryParams queryParams)
    {
        var result = await firstVoucherService.GetList(queryParams);
        return result.Match<IActionResult>(
            Ok,
            ex => ex.ToResponse());
    }

    [HttpGet("{customerId:int}")]
    [ProducesResponseType<CustomerDto>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int customerId)
    {
        var result = await firstVoucherService.GetById(customerId);
        return result.Match<IActionResult>(
            Ok,
            ex => ex.ToResponse());
    }

    [HttpPost]
    [ProducesResponseType<CustomerDto>(StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] CustomerFirstVoucherRequest request)
    {
        var result = await firstVoucherService.Create(request);
        return result.Match<IActionResult>(
            Ok,
            ex => ex.ToResponse());
    }

    [HttpPut("{customerId:int}")]
    [ProducesResponseType<CustomerDto>(StatusCodes.Status200OK)]
    public async Task<IActionResult> Update(int customerId, [FromBody] CustomerFirstVoucherRequest request)
    {
        var result = await firstVoucherService.Update(customerId, request);
        return result.Match<IActionResult>(
            Ok,
            ex => ex.ToResponse());
    }

    [HttpPatch("{customerId:int}")]
    [ProducesResponseType<CustomerDto>(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateField(int customerId, [FromBody] List<CustomerFieldUpdateRequest> request)
    {
        var result = await firstVoucherService.UpdateField(customerId, request);
        return result.Match<IActionResult>(
            Ok,
            ex => ex.ToResponse());
    }

    [HttpDelete("{customerId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete(int customerId)
    {
        var result = await firstVoucherService.Delete(customerId);
        return result.Match<IActionResult>(
            _ => NoContent(),
            ex => ex.ToResponse());
    }
}