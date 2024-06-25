using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proAdministration.Data.Entities;

public class Address : ISoftDelete
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [MaxLength(256)] public string Street { get; set; } = string.Empty;
    
    [MaxLength(256)] public string State { get; set; } = string.Empty;
    
    [MaxLength(256)] public string City { get; set; } = string.Empty;
    
    [MaxLength(100)] public string PostalCode { get; set; } = string.Empty;
    
    [MaxLength(64)] public string Country { get; set; } = string.Empty;
    
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
}