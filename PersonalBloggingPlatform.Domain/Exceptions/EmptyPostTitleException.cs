using PersonalBloggingPlatform.Shared.Abstractions.Exceptions;

namespace PersonalBloggingPlatform.Domain.Exceptions;

public class EmptyPostTitleException : DomainException
{
    public EmptyPostTitleException() : base("Post title cannot be empty!")
    {
    }
}
