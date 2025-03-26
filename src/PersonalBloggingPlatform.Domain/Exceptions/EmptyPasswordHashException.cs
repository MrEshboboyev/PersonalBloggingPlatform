using PersonalBloggingPlatform.Shared.Abstractions.Exceptions;

namespace PersonalBloggingPlatform.Domain.Exceptions;

public class EmptyPasswordHashException : DomainException
{
    public EmptyPasswordHashException() : base("Password hash cannot be empty!")
    {
    }
}