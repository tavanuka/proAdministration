using Microsoft.AspNetCore.Mvc;
using Refit;

namespace proAdministration.API.Clients.QueryParameters;

public class GetCustomersQueryParams
{
    [AliasAs("limit")]
    [FromQuery(Name = "limit")]
    public int Limit { get; set; } = 30;

    [AliasAs("start")]
    [FromQuery(Name = "start")]
    public int Start { get; set; }

    [AliasAs("x-expand")]
    [FromQuery(Name = "x-expand")]
    public string XExpand { get; set; } = string.Empty;
}