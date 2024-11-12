using Microsoft.Extensions.DependencyInjection;
using PersonalBloggingPlatform.Domain.Factories;
using PersonalBloggingPlatform.Domain.Policies;
using PersonalBloggingPlatform.Shared.Commands;

namespace PersonalBloggingPlatform.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddCommands();
        services.AddSingleton<IBlogPostFactory, BlogPostFactory>();
        services.AddSingleton<ITagFactory, TagFactory>();
        services.AddSingleton<ICategoryFactory, CategoryFactory>();
        services.AddSingleton<IUserFactory, UserFactory>();
        services.AddSingleton<IRoleFactory, RoleFactory>();
        services.AddSingleton<ICommentFactory, CommentFactory>();

        services.Scan(b => b.FromAssemblies(typeof(IBlogPostPolicy).Assembly)
            .AddClasses(c => c.AssignableTo<IBlogPostPolicy>())
            .AsImplementedInterfaces()
            .WithSingletonLifetime());

        return services;
    }
}

