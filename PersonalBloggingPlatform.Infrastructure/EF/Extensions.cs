using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonalBloggingPlatform.Infrastructure.EF.Contexts;
using PersonalBloggingPlatform.Infrastructure.EF.Options;
using PersonalBloggingPlatform.Shared.Options;

namespace PersonalBloggingPlatform.Infrastructure.EF;

internal static class Extensions
{
    public static IServiceCollection AddPostges(this IServiceCollection services, 
        IConfiguration configuration)
    {
        var options = configuration.GetOptions<PostgresOptions>("Postgres");
        services.AddDbContext<ReadDbContext>(ctx => 
             ctx.UseNpgsql(options.ConnectionString));
        services.AddDbContext<WriteDbContext>(ctx =>
             ctx.UseNpgsql(options.ConnectionString));
        
        return services;
    }
}

