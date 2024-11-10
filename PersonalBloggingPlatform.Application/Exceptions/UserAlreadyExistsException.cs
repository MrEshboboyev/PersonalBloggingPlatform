using PersonalBloggingPlatform.Shared.Abstractions.Exceptions;

namespace PersonalBloggingPlatform.Application.Exceptions;

internal class UserAlreadyExistsException(string username) : 
    DomainException($"This username {username} already exists in our system!")
{
    public string Username { get; } = username;
}
