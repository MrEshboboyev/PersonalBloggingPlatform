using PersonalBloggingPlatform.Shared.Abstractions.Exceptions;

namespace PersonalBloggingPlatform.Application.Exceptions;

public class BlogPostAlreadyExistsException(string title) 
    : DomainException($"Blog Post with title {title} already exists!")
{
    public string Title { get; } = title;
}
