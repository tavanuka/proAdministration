using System.Net.Http.Headers;
using Microsoft.Extensions.Options;
using proAdministration.API.Options;

namespace proAdministration.API.Clients.Handlers;

public class FirstVoucherAuthenticationHeaderHandler(IOptions<FirstVoucherApiOptions> options) : DelegatingHandler
{
    private readonly FirstVoucherApiOptions _options = options.Value;

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        request.Headers.Authorization = new AuthenticationHeaderValue(_options.Authorization, _options.ApiToken);
        
        return await base.SendAsync(request, cancellationToken);
    }
}