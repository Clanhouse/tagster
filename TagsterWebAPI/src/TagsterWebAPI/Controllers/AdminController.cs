using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tagster.Application.Commands.GenFakeData;
using Tagster.Domain.Authorization;

namespace TagsterWebAPI.Controllers;

[Route("admin")]
[Authorize(Roles = Role.Admin)]
public class AdminController : ControllerBase
{
    private readonly IMediator _mediator;

    public AdminController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Generates (profilesCount) profiles and assigns to them number of tags between 0 and (maxTagsPerProfile)
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("generate-fake-data")]
    public async Task<IActionResult> GenFakeData([FromQuery]GenFakeData command)
    {
        await _mediator.Send(command);
        return Ok();
    }

}
