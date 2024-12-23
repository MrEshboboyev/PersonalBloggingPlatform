﻿using Microsoft.Extensions.DependencyInjection;
using PersonalBloggingPlatform.Shared.Abstractions.Commands;
using System.Reflection;

namespace PersonalBloggingPlatform.Shared.Commands;

public static class Extensions
{
    public static IServiceCollection AddCommands(this IServiceCollection services)
    {
        var assembly = Assembly.GetCallingAssembly();

        services.AddScoped<ICommandDispatcher, InMemoryCommandDispatcher>();

        services.Scan(s => s.FromAssemblies(assembly)
            .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        // Register generic command handlers
        services.Scan(s => s.FromAssemblies(assembly)
            .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    }
}

