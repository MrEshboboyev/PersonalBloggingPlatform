using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalBloggingPlatform.Application.Commands;
using PersonalBloggingPlatform.Application.DTO;
using PersonalBloggingPlatform.Application.Queries;
using PersonalBloggingPlatform.Shared.Abstractions.Commands;
using PersonalBloggingPlatform.Shared.Abstractions.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalBloggingPlatform.API.Controllers;

[Authorize(Roles = "Admin")]
[Route("api/[controller]")]
[ApiController]
public class CategoryController(ICommandDispatcher commandDispatcher, 
    IQueryDispatcher queryDispatcher) : BaseController
{
    private readonly ICommandDispatcher _commandDispatcher = commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher = queryDispatcher;

    [AllowAnonymous]
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<CategoryDto>> Get([FromRoute] GetCategory query)
    {
        var result = await _queryDispatcher.QueryAsync(query);

        return OkOrNotFound(result);
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> Get([FromQuery] SearchCategories query)
    {
        var result = await _queryDispatcher.QueryAsync(query);

        return OkOrNotFound(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateCategory command)
    {
        await _commandDispatcher.DispatchAsync(command);

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Put(UpdateCategory command)
    {
        await _commandDispatcher.DispatchAsync(command);

        return Ok();
    }
}
