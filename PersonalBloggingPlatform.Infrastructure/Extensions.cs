using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonalBloggingPlatform.Infrastructure.Auth;
using PersonalBloggingPlatform.Infrastructure.Configuration;
using PersonalBloggingPlatform.Infrastructure.EF;
using PersonalBloggingPlatform.Infrastructure.Logging;
using PersonalBloggingPlatform.Shared.Abstractions.Auth;
using PersonalBloggingPlatform.Shared.Abstractions.Commands;
using PersonalBloggingPlatform.Shared.Queries;

namespace PersonalBloggingPlatform.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddPostges(configuration);
        services.AddQueries();

        services.TryDecorate(typeof(ICommandHandler<>), 
            typeof(LoggingCommandHandlerDecorator<>));

        services.AddScoped<IJwtProvider, JwtProvider>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();

        return services;
    }
}
