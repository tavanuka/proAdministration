using System.Reflection;
using Mapster;
using MapsterMapper;

namespace proAdministration.API.Mapping;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Register Mapster and all custom map configurations to services.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    public static IServiceCollection AddMapping(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());
        config.ConfigureDefaultSettings();

        services
            .AddSingleton(config)
            .AddScoped<IMapper, ServiceMapper>();
        return services;
    }

    private static void ConfigureDefaultSettings(this TypeAdapterConfig config)
    {
        // Future people: this makes the client explode whenever a request contains a collection that is null if not configured the way it is. Just don't change.
        config.Default.AddDestinationTransform(DestinationTransform.EmptyCollectionIfNull);
    }
}