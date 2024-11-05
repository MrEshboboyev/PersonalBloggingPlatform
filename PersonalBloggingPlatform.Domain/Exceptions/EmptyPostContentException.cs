using PersonalBloggingPlatform.Shared.Abstractions.Exceptions;

namespace PersonalBloggingPlatform.Domain.Exceptions;

public class EmptyPostContentException : DomainException
{
    public EmptyPostContentException() : base("Post Content cannot be empty!")
    {
    }
}
