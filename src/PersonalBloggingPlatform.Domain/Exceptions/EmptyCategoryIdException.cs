using PersonalBloggingPlatform.Shared.Abstractions.Exceptions;

namespace PersonalBloggingPlatform.Domain.Exceptions;

public class EmptyCategoryIdException : DomainException
{
    public EmptyCategoryIdException() : base("Category Id cannot be empty.")
    {
    }
}