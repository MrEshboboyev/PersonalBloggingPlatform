using PersonalBloggingPlatform.Application.DTO;
using PersonalBloggingPlatform.Shared.Abstractions.Queries;
using System.Collections.Generic;

namespace PersonalBloggingPlatform.Application.Queries;

public class GetBlogPostsByTag : IQuery<IEnumerable<BlogPostDto>>
{
    public string TagName { get; set; }
}