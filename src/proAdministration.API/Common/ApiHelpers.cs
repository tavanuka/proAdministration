using proAdministration.Shared;

namespace proAdministration.API.Common;

public static class ApiHelpers
{
    public static T Unwrap<T>(this ApiResponse<T> response)
        => response.Data;
}