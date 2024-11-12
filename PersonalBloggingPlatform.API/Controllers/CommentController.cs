using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalBloggingPlatform.API.Requests;
using PersonalBloggingPlatform.Application.Commands;
using PersonalBloggingPlatform.Application.DTO;
using PersonalBloggingPlatform.Application.Queries;
using PersonalBloggingPlatform.Shared.Abstractions.Commands;
using PersonalBloggingPlatform.Shared.Abstractions.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalBloggingPlatform.API.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CommentController(ICommandDispatcher commandDispatcher, 
    IQueryDispatcher queryDispatcher) : BaseController
{
    private readonly ICommandDispatcher _commandDispatcher = commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher = queryDispatcher;

    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CommentDto>>> Get([FromQuery] GetCommentsForBlogPost query)
    {
        var result = await _queryDispatcher.QueryAsync(query);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(AddCommentRequest request)
    {
        AddComment command = new(request.Content, request.BlogPostId, GetUserId());
        await _commandDispatcher.DispatchAsync(command);

        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(RemoveComment command)
    {
        await _commandDispatcher.DispatchAsync(command);

        return Ok();
    }
}
