using Microsoft.AspNetCore.Mvc;
using PersonalBloggingPlatform.Application.Commands;
using PersonalBloggingPlatform.Shared.Abstractions.Auth;
using PersonalBloggingPlatform.Shared.Abstractions.Commands;
using System.Threading.Tasks;

namespace PersonalBloggingPlatform.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(ICommandDispatcher commandDispatcher) : ControllerBase
{
    private readonly ICommandDispatcher _commandDispatcher = commandDispatcher;

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUser command)
    {
        await _commandDispatcher.DispatchAsync(command);
        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] AuthenticateUser command)
    {
        var token = await _commandDispatcher.DispatchAsync<AuthenticateUser, string>(command);

        return Ok(new { Token = token });
    }
}
