using PersonalBloggingPlatform.Application.Exceptions;
using PersonalBloggingPlatform.Application.Services;
using PersonalBloggingPlatform.Domain.Repositories;
using PersonalBloggingPlatform.Domain.ValueObjects;
using PersonalBloggingPlatform.Shared.Abstractions.Commands;
using System.Threading.Tasks;

namespace PersonalBloggingPlatform.Application.Commands.Handlers;

internal class UpdateCategoryHandler(ICategoryRepository repository,
    ICategoryReadService readService) : ICommandHandler<UpdateCategory>
{
    private readonly ICategoryRepository _repository = repository;
    private readonly ICategoryReadService _readService = readService;

    public async Task HandleAsync(UpdateCategory command)
    {
        var category = await _repository.GetAsync(command.Id)
            ?? throw new CategoryNotFoundException(command.Id);

        if (await _readService.ExistsByNameAsync(command.Name))
        {
            throw new CategoryAlreadyExistsException(command.Name);
        }

        category.UpdateName(new CategoryName(command.Name));

        await _repository.UpdateAsync(category);
    }
}