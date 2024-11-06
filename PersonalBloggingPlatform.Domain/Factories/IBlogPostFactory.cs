using PersonalBloggingPlatform.Domain.Entities;
using PersonalBloggingPlatform.Domain.ValueObjects;

namespace PersonalBloggingPlatform.Domain.Factories;

public interface IBlogPostFactory
{
    BlogPost CreateBlogPost(BlogPostId id, PostTitle title, PostContent content);
}
