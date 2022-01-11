using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tagster.Application.Commands.AddTagsToProfile;
using Tagster.Application.Queries.GetProfileWithTags;
using Tagster.Application.Queries.GetTags;
using Tagster.Domain.Entities;

namespace TagsterWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize()]
public class TagsController : ControllerBase
{
    private readonly IMediator _mediator;

    public TagsController(IMediator mediator)
        => _mediator = mediator;

    /// <summary>
    /// Get all tags for profile
    /// </summary>
    /// <param name="profileName"></param>
    /// <returns></returns>

    [HttpGet]
    [Route("{profileName}")]
    [ProducesResponseType(typeof(ICollection<Tag>[]), StatusCodes.Status200OK)]
    public async Task<IActionResult> TagsOnProfile(string profileName)
        => Ok(await _mediator.Send(new GetTags { ProfileName = profileName }));

    [HttpPut]
    [Route("")]
    public async Task<IActionResult> InsertData([FromBody] AddTagsToProfile command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [HttpGet]
    [Route("get/{href}")]
    public async Task<IActionResult> GetProfileWithTagsByHref(string href)
        => Ok(await _mediator.Send(new GetProfileWithTags { Href = href }));
}
