using Microsoft.AspNetCore.Mvc;
using PersonalBloggingPlatform.Application.Commands;
using PersonalBloggingPlatform.Application.DTO;
using PersonalBloggingPlatform.Application.Queries;
using PersonalBloggingPlatform.Shared.Abstractions.Commands;
using PersonalBloggingPlatform.Shared.Abstractions.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalBloggingPlatform.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogPostController(ICommandDispatcher commandDispatcher, 
    IQueryDispatcher queryDispatcher) : BaseController
{
    private readonly ICommandDispatcher _commandDispatcher = commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher = queryDispatcher;

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<BlogPostDto>> Get([FromRoute] GetBlogPost query)
    {
        var result = await _queryDispatcher.QueryAsync(query);

        return OkOrNotFound(result);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BlogPostDto>>> Get([FromQuery] SearchBlogPosts query)
    {
        var result = await _queryDispatcher.QueryAsync(query);

        return OkOrNotFound(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateBlogPost command)
    {
        await _commandDispatcher.DispatchAsync(command);

        return CreatedAtAction(nameof(Get), new { id = command.Id }, null);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(DeleteBlogPost command)
    {
        await _commandDispatcher.DispatchAsync(command);

        return Ok();
    }
}
