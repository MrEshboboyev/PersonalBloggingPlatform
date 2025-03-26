using PersonalBloggingPlatform.Shared.Abstractions.Exceptions;

namespace PersonalBloggingPlatform.Domain.Exceptions;

public class EmptyUsernameException : DomainException
{
    public EmptyUsernameException() : base("Username cannot be empty.")
    {
    }
}