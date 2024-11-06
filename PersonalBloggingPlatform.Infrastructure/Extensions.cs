using Microsoft.Extensions.DependencyInjection;
using PersonalBloggingPlatform.Shared.Queries;

namespace PersonalBloggingPlatform.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddQueries();

        return services;
    }
}
