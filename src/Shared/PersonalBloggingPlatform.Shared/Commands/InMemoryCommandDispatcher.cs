using Microsoft.Extensions.DependencyInjection;
using PersonalBloggingPlatform.Shared.Abstractions.Commands;
using System;
using System.Threading.Tasks;

namespace PersonalBloggingPlatform.Shared.Commands;

internal sealed class InMemoryCommandDispatcher(IServiceProvider serviceProvider) : ICommandDispatcher
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    public async Task DispatchAsync<TCommand>(TCommand command) where TCommand : class, ICommand
    {
        using var scope = _serviceProvider.CreateScope();
        var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand>>();
        await handler.HandleAsync(command);
    }

    // New method to dispatch commands that return a result
    public async Task<TResult> DispatchAsync<TCommand, TResult>(TCommand command)
        where TCommand : class, ICommand<TResult>
    {
        using var scope = _serviceProvider.CreateScope();
        var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand, TResult>>();
        return await handler.HandleAsync(command);
    }
}