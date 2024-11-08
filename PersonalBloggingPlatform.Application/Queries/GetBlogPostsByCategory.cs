using PersonalBloggingPlatform.Application.DTO;
using PersonalBloggingPlatform.Shared.Abstractions.Queries;
using System.Collections.Generic;

namespace PersonalBloggingPlatform.Application.Queries;

public class GetBlogPostsByCategory : IQuery<IEnumerable<BlogPostDto>>
{
    public string CategoryName { get; set; }
}