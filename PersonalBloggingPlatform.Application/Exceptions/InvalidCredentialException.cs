using PersonalBloggingPlatform.Shared.Abstractions.Exceptions;

namespace PersonalBloggingPlatform.Application.Exceptions;

public class InvalidCredentialException : DomainException
{
    public InvalidCredentialException() : base("Invalid credentials!")
    {
        
    }
}
