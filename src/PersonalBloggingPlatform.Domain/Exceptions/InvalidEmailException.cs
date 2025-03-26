using PersonalBloggingPlatform.Shared.Abstractions.Exceptions;

namespace PersonalBloggingPlatform.Domain.Exceptions;

public class InvalidEmailException : DomainException
{
    public InvalidEmailException() : base("Email is Invalid format.")
    {
    }
}
