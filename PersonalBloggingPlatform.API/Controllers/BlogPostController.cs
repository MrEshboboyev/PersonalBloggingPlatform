using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalBloggingPlatform.Application.Commands;
using PersonalBloggingPlatform.Application.DTO;
using PersonalBloggingPlatform.Application.Queries;
using PersonalBloggingPlatform.Shared.Abstractions.Commands;
using PersonalBloggingPlatform.Shared.Abstractions.Queries;
using System;
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

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Put(UpdateBlogPost command)
    {
        await _commandDispatcher.DispatchAsync(command);

        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(DeleteBlogPost command)
    {
        await _commandDispatcher.DispatchAsync(command);

        return Ok();
    }

    // New Route for Adding a Tag to BlogPost
    [HttpPost("{blogPostId:guid}/tags/{tagId:guid}")]
    public async Task<IActionResult> AddTag([FromRoute] AddTagToBlogPost command)
    {
        //var command = new AddTagToBlogPostCommand(id, tagId);
        await _commandDispatcher.DispatchAsync(command);
        return Ok();
    }

    // Removing a Tag from BlogPost
    [HttpDelete("{blogPostId:guid}/tags/{tagId:guid}")]
    public async Task<IActionResult> RemoveTag([FromRoute] RemoveTagFromBlogPost command)
    {
        //var command = new RemoveTagFromBlogPostCommand(id, tagId);
        await _commandDispatcher.DispatchAsync(command);
        return Ok();
    }

    // Changing the Category of BlogPost
    [HttpPut("{blogPostId:guid}/category/{newCategoryId:guid}")]
    public async Task<IActionResult> ChangeCategory([FromRoute] ChangeBlogPostCategory command)
    {
        //var command = new ChangeBlogPostCategoryCommand(id, newCategoryId);
        await _commandDispatcher.DispatchAsync(command);
        return Ok();
    }
}
