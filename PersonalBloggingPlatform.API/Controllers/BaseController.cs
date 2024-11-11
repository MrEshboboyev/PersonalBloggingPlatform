using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace PersonalBloggingPlatform.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseController : ControllerBase
{
    protected ActionResult<TResult> OkOrNotFound<TResult>(TResult result)
        => result is null ? NotFound() : Ok(result);

    protected string GetUserId()
        => User.FindFirstValue(ClaimTypes.NameIdentifier);
}
