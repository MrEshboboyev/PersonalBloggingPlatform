using PersonalBloggingPlatform.Shared.Abstractions.Commands;

namespace PersonalBloggingPlatform.Application.Commands;

public record CreateTag(string Name) : ICommand;