using PersonalBloggingPlatform.Shared.Abstractions.Commands;
using System.Threading.Tasks;

namespace PersonalBloggingPlatform.Application.Commands.Handlers;

public class CreateBlogPostHandler : ICommandHandler<CreateBlogPost>
{
    public Task HandleAsync(CreateBlogPost command)
    {
        return Task.CompletedTask;
    }
}
