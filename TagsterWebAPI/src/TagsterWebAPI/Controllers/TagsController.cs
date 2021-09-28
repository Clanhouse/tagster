using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tagster.Application.Commands.AddTagsToProfile;
using Tagster.Application.Services;
using Tagster.DataAccess.Entities;

namespace TagsterWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TagsController : ControllerBase
    {
        private readonly ITagsService _tagService;
        private readonly IMediator _mediator;

        public TagsController(ITagsService tagService, IMediator mediator)
        {
            _tagService = tagService;
            _mediator = mediator;
        }

        /// <summary>
        /// Get all tags for profile
        /// </summary>
        /// <param name="profileName"></param>
        /// <returns></returns>

        [HttpGet]
        [Route("{profileName}")]
        [ProducesResponseType(typeof(ICollection<Tag>[]), StatusCodes.Status200OK)]
        public async Task<IActionResult> TagsOnProfile(string profileName)
            => Ok(await _tagService.GetList(profileName));
         
        [HttpPut]
        [Route("")]
        public async Task<IActionResult> InsertData([FromBody] AddTagsToProfile command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}