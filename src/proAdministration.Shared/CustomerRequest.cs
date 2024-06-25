namespace proAdministration.Shared;

public record CustomerRequest(
    string CustomerId,
    string Name,
    string Email,
    string PhoneNumber,
    string Currency,
    string Street,
    string State,
    string City,
    string PostalCode,
    string Country);