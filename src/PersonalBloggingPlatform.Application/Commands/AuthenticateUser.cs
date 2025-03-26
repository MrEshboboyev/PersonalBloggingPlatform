using PersonalBloggingPlatform.Shared.Abstractions.Commands;

namespace PersonalBloggingPlatform.Application.Commands;

public record AuthenticateUser(string Username, string Password) : ICommand<string>;