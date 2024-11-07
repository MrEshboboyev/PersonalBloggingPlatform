using Microsoft.EntityFrameworkCore;
using PersonalBloggingPlatform.Application.DTO;
using PersonalBloggingPlatform.Application.Queries;
using PersonalBloggingPlatform.Infrastructure.EF.Contexts;
using PersonalBloggingPlatform.Infrastructure.EF.Models;
using PersonalBloggingPlatform.Shared.Abstractions.Queries;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBloggingPlatform.Infrastructure.EF.Queries.Handlers;

public class GetBlogPostHandler(ReadDbContext context)
    : IQueryHandler<GetBlogPost, BlogPostDto>
{
    private readonly DbSet<BlogPostReadModel> _blogPosts = context.BlogPosts;

    public Task<BlogPostDto> HandleAsync(GetBlogPost query)
        => _blogPosts
            .Where(bp => bp.Id == query.Id)
            .Select(bp => bp.AsDto())
            .AsNoTracking()
            .SingleOrDefaultAsync();
}