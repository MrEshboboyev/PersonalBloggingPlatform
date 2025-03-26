using Microsoft.EntityFrameworkCore;
using PersonalBloggingPlatform.Application.DTO;
using PersonalBloggingPlatform.Application.Queries;
using PersonalBloggingPlatform.Infrastructure.EF.Contexts;
using PersonalBloggingPlatform.Infrastructure.EF.Models;
using PersonalBloggingPlatform.Shared.Abstractions.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBloggingPlatform.Infrastructure.EF.Queries.Handlers;

internal sealed class GetCommentsForBlogPostHandler(ReadDbContext context)
    : IQueryHandler<GetCommentsForBlogPost, IEnumerable<CommentDto>>
{
    private readonly DbSet<CommentReadModel> _comments = context.Comments;

    public async Task<IEnumerable<CommentDto>> HandleAsync(GetCommentsForBlogPost query)
    {
        var dbQuery = _comments
            .AsQueryable();

        dbQuery = dbQuery.Where(c => c.BlogPostId.Equals(query.BlogPostId));

        return await dbQuery
            .Select(c => c.AsDto())
            .AsNoTracking()
            .ToListAsync();
    }
}
