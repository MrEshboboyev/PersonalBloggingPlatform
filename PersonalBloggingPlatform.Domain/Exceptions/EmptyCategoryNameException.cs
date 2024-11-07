using PersonalBloggingPlatform.Shared.Abstractions.Exceptions;

namespace PersonalBloggingPlatform.Domain.Exceptions;

public class EmptyCategoryNameException : DomainException
{
    public EmptyCategoryNameException() : base("Category name cannot be empty.")
    {
    }
}