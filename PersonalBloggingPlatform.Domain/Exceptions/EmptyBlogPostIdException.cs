using PersonalBloggingPlatform.Shared.Abstractions.Exceptions;

namespace PersonalBloggingPlatform.Domain.Exceptions;

public class EmptyBlogPostIdException(string message) : DomainException("Blog Post Id cannot be empty!")
{
}
