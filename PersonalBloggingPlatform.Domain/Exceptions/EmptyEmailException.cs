using PersonalBloggingPlatform.Shared.Abstractions.Exceptions;

namespace PersonalBloggingPlatform.Domain.Exceptions;

internal class EmptyEmailException : DomainException
{
    public EmptyEmailException() : base("Email cannot be empty.")
    {
    }
}
