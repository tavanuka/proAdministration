namespace proAdministration.Shared;

public class CustomerDetailsDto
{
    // TODO: Evaluate if separate address fields are preferable 
    public int Id { get; set; }
    public string CustomerId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Currency { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
}