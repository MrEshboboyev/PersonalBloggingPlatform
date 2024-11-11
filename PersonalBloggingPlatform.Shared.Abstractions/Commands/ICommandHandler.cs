using System.Threading.Tasks;

namespace PersonalBloggingPlatform.Shared.Abstractions.Commands;

public interface ICommandHandler<in TCommand> where TCommand : class, ICommand 
{
    Task HandleAsync(TCommand command);
}

// New generic interface for command handlers that return a result
public interface ICommandHandler<in TCommand, TResult> where TCommand : class, ICommand<TResult>
{
    Task<TResult> HandleAsync(TCommand command);
}