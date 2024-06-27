using System.Text.Json.Serialization;

namespace proAdministration.Shared;

public class CustomerFirstVoucherRequest
{
    public int BusinessId { get; set; } = 1;

    public string? City { get; set; }

    public string? Company { get; set; }

    public string? Country { get; set; }

    public string? CustomerNumber { get; set; }

    public string Email { get; set; } = string.Empty;

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public string? Phone { get; set; }

    public int SalutationId { get; set; } = 2;

    public string? Street { get; set; }

    public string? StreetAddition { get; set; }

    public string? VatNumber { get; set; }

    public string? Zip { get; set; }
}