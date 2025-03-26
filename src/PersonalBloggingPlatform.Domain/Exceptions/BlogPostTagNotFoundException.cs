using PersonalBloggingPlatform.Shared.Abstractions.Exceptions;

namespace PersonalBloggingPlatform.Domain.Exceptions;

public class BlogPostTagNotFoundException(string tagName) 
    : DomainException($"BlogPost Tag {tagName} was not found!")
{
    public string TagName { get; set; } = tagName;
}