using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonalBloggingPlatform.Application.Services;
using PersonalBloggingPlatform.Domain.Repositories;
using PersonalBloggingPlatform.Infrastructure.EF.Contexts;
using PersonalBloggingPlatform.Infrastructure.EF.Options;
using PersonalBloggingPlatform.Infrastructure.EF.Repositories;
using PersonalBloggingPlatform.Infrastructure.EF.Services;
using PersonalBloggingPlatform.Shared.Options;

namespace PersonalBloggingPlatform.Infrastructure.EF;

internal static class Extensions
{
    public static IServiceCollection AddPostges(this IServiceCollection services, 
        IConfiguration configuration)
    {
        // adding lifetimes
        services.AddScoped<IBlogPostRepository, PostgresBlogPostRepository>();
        services.AddScoped<ITagRepository, PostgresTagRepository>();
        services.AddScoped<ICategoryRepository, PostgresCategoryRepository>();
        services.AddScoped<IBlogPostReadService, PostgresBlogPostReadService>();
        services.AddScoped<ITagReadService, PostgresTagReadService>();
        services.AddScoped<ICategoryReadService, PostgresCategoryReadService>();

        var options = configuration.GetOptions<PostgresOptions>("Postgres");
        services.AddDbContext<ReadDbContext>(ctx => 
             ctx.UseNpgsql(options.ConnectionString));
        services.AddDbContext<WriteDbContext>(ctx =>
             ctx.UseNpgsql(options.ConnectionString));
        
        return services;
    }
}

