using PersonalBloggingPlatform.Application.Exceptions;
using PersonalBloggingPlatform.Application.Services;
using PersonalBloggingPlatform.Domain.Factories;
using PersonalBloggingPlatform.Domain.Repositories;
using PersonalBloggingPlatform.Shared.Abstractions.Commands;
using System.Threading.Tasks;

namespace PersonalBloggingPlatform.Application.Commands.Handlers;

internal class CreateCategoryHandler(ICategoryRepository repository,
    ICategoryFactory factory,
    ICategoryReadService readService) : ICommandHandler<CreateCategory>
{
    private readonly ICategoryRepository _repository = repository;
    private readonly ICategoryFactory _factory = factory;
    private readonly ICategoryReadService _readService = readService;

    public async Task HandleAsync(CreateCategory command)
    {
        var categoryName = command.Name;

        if (await _readService.ExistsByNameAsync(categoryName))
        {
            throw new CategoryAlreadyExistsException(categoryName);
        }

        var category = _factory.Create(categoryName);

        await _repository.CreateAsync(category);
    }
}
