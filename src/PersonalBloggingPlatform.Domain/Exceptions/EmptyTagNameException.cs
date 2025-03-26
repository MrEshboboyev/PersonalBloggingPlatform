using PersonalBloggingPlatform.Shared.Abstractions.Exceptions;

namespace PersonalBloggingPlatform.Domain.Exceptions;

public class EmptyTagNameException : DomainException
{
    public EmptyTagNameException() : base("Tag name cannot be empty.")
    {
    }
}