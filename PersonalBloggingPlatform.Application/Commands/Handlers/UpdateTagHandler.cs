using PersonalBloggingPlatform.Application.Exceptions;
using PersonalBloggingPlatform.Application.Services;
using PersonalBloggingPlatform.Domain.Repositories;
using PersonalBloggingPlatform.Domain.ValueObjects;
using PersonalBloggingPlatform.Shared.Abstractions.Commands;
using System.Threading.Tasks;

namespace PersonalBloggingPlatform.Application.Commands.Handlers;

internal class UpdateTagHandler(ITagRepository repository,
    ITagReadService readService) : ICommandHandler<UpdateTag>
{
    private readonly ITagRepository _repository = repository;
    private readonly ITagReadService _readService = readService;

    public async Task HandleAsync(UpdateTag command)
    {
        var tag = await _repository.GetAsync(command.Id)
            ?? throw new TagNotFoundException(command.Id);

        if (await _readService.ExistsByNameAsync(command.Name))
        {
            throw new TagAlreadyExistsException(command.Name);
        }

        tag.UpdateName(new TagName(command.Name));

        await _repository.UpdateAsync(tag);
    }
}