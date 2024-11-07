using Microsoft.Extensions.DependencyInjection;
using PersonalBloggingPlatform.Shared.Services;

namespace PersonalBloggingPlatform.Shared;

public static class Extensions
{
    public static IServiceCollection AddShared(this IServiceCollection services)
    {
        services.AddHostedService<AppInitializer>();
        return services;
    }
}