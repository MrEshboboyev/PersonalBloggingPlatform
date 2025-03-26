using PersonalBloggingPlatform.Shared.Abstractions.Commands;

namespace PersonalBloggingPlatform.Application.Commands;

public record CreateCategory(string Name) : ICommand;