using PersonalBloggingPlatform.Application.Exceptions;
using PersonalBloggingPlatform.Domain.Repositories;
using PersonalBloggingPlatform.Shared.Abstractions.Commands;
using System.Threading.Tasks;

namespace PersonalBloggingPlatform.Application.Commands.Handlers;

public class AddTagToBlogPostHandler(IBlogPostRepository blogPostRepository,
    ITagRepository tagRepository) : ICommandHandler<AddTagToBlogPost>
{
    private readonly IBlogPostRepository _blogPostRepository = blogPostRepository;
    private readonly ITagRepository _tagRepository = tagRepository;

    public async Task HandleAsync(AddTagToBlogPost command)
    {
        var (blogPostId, tagId) = command;

        var blogPost = await _blogPostRepository.GetAsync(blogPostId)
            ?? throw new BlogPostNotFoundException(blogPostId);

        var tag = await _tagRepository.GetAsync(tagId) 
            ?? throw new TagNotFoundException(tagId);

        blogPost.AddTag(tag);

        await _blogPostRepository.UpdateAsync(blogPost);
    }
}