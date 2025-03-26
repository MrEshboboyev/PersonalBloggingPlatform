using PersonalBloggingPlatform.Shared.Abstractions.Commands;

namespace PersonalBloggingPlatform.Application.Commands;

public record RegisterUser(string Username, string Email,
    string Password) : ICommand;