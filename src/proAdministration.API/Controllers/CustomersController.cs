using Microsoft.AspNetCore.Mvc;
using proAdministration.API.Exceptions;
using proAdministration.API.Services;
using proAdministration.Shared;

namespace proAdministration.API.Controllers;

[ApiController]
[Route("api/customers")]
public class CustomersController(ICustomerService customerService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType<List<CustomerDetailsDto>>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get([FromQuery] string customerId = "")
    {
        var result = await customerService.GetList(customerId);
        return result.Match<IActionResult>(
            Ok,
            ex => ex.ToResponse());
    }

    [HttpGet("{customerId}")]
    [ProducesResponseType<CustomerDetailsDto>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(string customerId)
    {
        var result = await customerService.GetById(customerId);
        return result.Match<IActionResult>(
            Ok,
            ex => ex.ToResponse());
    }

    [HttpPost]
    [ProducesResponseType<CustomerDetailsDto>(StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] CustomerRequest request)
    {
        var result = await customerService.Create(request);
        return result.Match<IActionResult>(
            Ok,
            ex => ex.ToResponse());
    }

    [HttpPatch("{customerId:int}")]
    [ProducesResponseType<CustomerDetailsDto>(StatusCodes.Status200OK)]
    public async Task<IActionResult> Update([FromBody] CustomerRequest request, int customerId)
    {
        var result = await customerService.Update(request, customerId);
        return result.Match<IActionResult>(
            Ok,
            ex => ex.ToResponse());
    }

    [HttpDelete("{customerId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(string customerId)
    {
        var result = await customerService.Delete(customerId);
        return result.Match<IActionResult>(
            _ => NoContent(),
            ex => ex.ToResponse());
    }
}