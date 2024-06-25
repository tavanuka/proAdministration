using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proAdministration.Data.Entities;

public class Customer
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [MaxLength(16)] public string CustomerId { get; set; } = string.Empty;

    [MaxLength(100)] public string Name { get; set; } = string.Empty;

    [MaxLength(100)] public string Email { get; set; } = string.Empty;

    [MaxLength(100)] public string PhoneNumber { get; set; } = string.Empty;

    [MaxLength(10)] public string Currency { get; set; } = string.Empty;

    public Address Address { get; set; } = default!;

    public int AddressId { get; set; }
}