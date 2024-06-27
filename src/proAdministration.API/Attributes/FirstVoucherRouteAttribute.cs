using Microsoft.AspNetCore.Mvc.Routing;

namespace proAdministration.API.Attributes;

public class FirstVoucherRouteAttribute : Attribute, IRouteTemplateProvider
{
    public string Route { get; set; } = string.Empty;
    public string Template => $"api/firstvoucher/{Route}";
    public int? Order => 2;
    public string Name { get; set; } = string.Empty;
}