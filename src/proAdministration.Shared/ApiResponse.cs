using System.Text.Json.Serialization;

namespace proAdministration.Shared;

public class ApiResponse<T>
{
    [JsonPropertyName("data")] public T Data { get; set; } = default!;
    [JsonPropertyName("total")] public int Total { get; set; }
}