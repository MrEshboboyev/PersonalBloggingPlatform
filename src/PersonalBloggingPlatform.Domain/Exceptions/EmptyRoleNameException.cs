using PersonalBloggingPlatform.Shared.Abstractions.Exceptions;

namespace PersonalBloggingPlatform.Domain.Exceptions;

public class EmptyRoleNameException : DomainException
{
    public EmptyRoleNameException() : base("Role name cannot be empty.")
    {
    }
}