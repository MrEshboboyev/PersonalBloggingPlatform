using PersonalBloggingPlatform.Shared.Abstractions.Exceptions;

namespace PersonalBloggingPlatform.Domain.Exceptions;

public class BlogPostTagAlreadyExistsException(string postTitle, string tagName) 
    : DomainException($"BlogPost : {postTitle} post already defined tag {tagName}")
{
    public string PostTitle { get; } = postTitle;
    public string TagName { get; } = tagName;
}