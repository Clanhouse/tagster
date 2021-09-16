using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tagster.Application.Services;
using Tagster.DataAccess.Entities;

namespace TagsterWebAPI.Controllers
{
    [Route("tag")]
    public class TagController : ControllerBase
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
            => _tagService = tagService;

        [HttpGet]
        [Route("{name}")]
        [ProducesResponseType(typeof(ICollection<Tag>[]), StatusCodes.Status200OK)]
        public async Task<IActionResult> TagsOnProfile(string name)
            => Ok(await _tagService.GetList((string)name));

        [HttpPut]
        [Route("{name}")]
        [ProducesResponseType(typeof(ICollection<Tag>[]), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SetTags(string href, ICollection<Tag> tags)
        {
            if (ModelState.IsValid)
                return BadRequest();
            return Ok(await _tagService.PutList(href, tags));
        }
    }
}