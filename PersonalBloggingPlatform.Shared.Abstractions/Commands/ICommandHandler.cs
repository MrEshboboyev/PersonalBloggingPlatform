﻿using System.Threading.Tasks;

namespace PersonalBloggingPlatform.Shared.Abstractions.Commands;

public interface ICommandHandler<in TCommand> where TCommand : class, ICommand 
{
    Task HandleAsync(TCommand command);
}

