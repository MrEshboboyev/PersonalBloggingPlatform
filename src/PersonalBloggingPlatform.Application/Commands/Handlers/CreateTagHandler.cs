using PersonalBloggingPlatform.Application.Exceptions;
using PersonalBloggingPlatform.Application.Services;
using PersonalBloggingPlatform.Domain.Factories;
using PersonalBloggingPlatform.Domain.Repositories;
using PersonalBloggingPlatform.Shared.Abstractions.Commands;
using System.Threading.Tasks;

namespace PersonalBloggingPlatform.Application.Commands.Handlers;

internal class CreateTagHandler(ITagRepository repository,
    ITagFactory factory,
    ITagReadService readService) : ICommandHandler<CreateTag>
{
    private readonly ITagRepository _repository = repository;
    private readonly ITagFactory _factory = factory;
    private readonly ITagReadService _readService = readService;

    public async Task HandleAsync(CreateTag command)
    {
        var tagName = command.Name;

        if (await _readService.ExistsByNameAsync(tagName))
        {
            throw new TagAlreadyExistsException(tagName);
        }

        var tag = _factory.Create(tagName);

        await _repository.CreateAsync(tag);
    }
}
