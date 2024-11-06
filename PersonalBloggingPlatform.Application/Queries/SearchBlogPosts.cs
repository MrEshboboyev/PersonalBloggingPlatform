using PersonalBloggingPlatform.Application.DTO;
using PersonalBloggingPlatform.Shared.Abstractions.Queries;
using System.Collections.Generic;

namespace PersonalBloggingPlatform.Application.Queries;

public class SearchBlogPosts : IQuery<IEnumerable<BlogPostDto>>
{
    public string SearchPhrase { get; set; }
}