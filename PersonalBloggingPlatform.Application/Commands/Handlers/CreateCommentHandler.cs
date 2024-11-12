using PersonalBloggingPlatform.Application.Exceptions;
using PersonalBloggingPlatform.Domain.Factories;
using PersonalBloggingPlatform.Domain.Repositories;
using PersonalBloggingPlatform.Shared.Abstractions.Commands;
using System.Threading.Tasks;

namespace PersonalBloggingPlatform.Application.Commands.Handlers;

public class CreateCommentHandler(IBlogPostRepository blogPostRepository,
    ICommentRepository commentRepository,
    ICommentFactory commentFactory) : ICommandHandler<CreateComment>
{
    private readonly IBlogPostRepository _blogPostRepository = blogPostRepository;
    private readonly ICommentRepository _commentRepository = commentRepository;
    private readonly ICommentFactory _commentFactory = commentFactory;

    public async Task HandleAsync(CreateComment command)
    {
        var (content, blogPostId, userId) = command;

        var blogPost = await _blogPostRepository.GetAsync(blogPostId)
            ?? throw new BlogPostNotFoundException(blogPostId);

        var comment = _commentFactory.Create(blogPostId, userId, content);

        await _commentRepository.CreateAsync(comment);
    }
}