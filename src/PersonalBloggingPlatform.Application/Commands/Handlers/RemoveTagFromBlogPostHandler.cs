using PersonalBloggingPlatform.Application.Exceptions;
using PersonalBloggingPlatform.Domain.Repositories;
using PersonalBloggingPlatform.Shared.Abstractions.Commands;
using System.Threading.Tasks;

namespace PersonalBloggingPlatform.Application.Commands.Handlers;

public class RemoveTagFromBlogPostHandler(IBlogPostRepository blogPostRepository,
    ITagRepository tagRepository) : ICommandHandler<RemoveTagFromBlogPost>
{
    private readonly IBlogPostRepository _blogPostRepository = blogPostRepository;
    private readonly ITagRepository _tagRepository = tagRepository;

    public async Task HandleAsync(RemoveTagFromBlogPost command)
    {
        var (blogPostId, tagId) = command;

        var blogPost = await _blogPostRepository.GetAsync(blogPostId)
            ?? throw new BlogPostNotFoundException(blogPostId);

        var tag = await _tagRepository.GetAsync(tagId)
            ?? throw new TagNotFoundException(tagId);

        blogPost.RemoveTag(tag);

        await _blogPostRepository.UpdateAsync(blogPost);
    }
}