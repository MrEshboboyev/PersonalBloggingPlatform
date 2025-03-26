using PersonalBloggingPlatform.Application.DTO;
using PersonalBloggingPlatform.Shared.Abstractions.Queries;
using System;
using System.Collections.Generic;

namespace PersonalBloggingPlatform.Application.Queries;

public class GetCommentsForBlogPost : IQuery<IEnumerable<CommentDto>>
{
    public Guid BlogPostId { get; set; }
}