using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tagster.Application.Services;
using Tagster.DataAccess.Entities;

namespace TagsterWebAPI.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class TagsController : ControllerBase
    {
        private readonly ITagsService _tagService;

        public TagsController(ITagsService tagService)
            => _tagService = tagService;

        /*[HttpGet]
        public string StartMessage()
            => "Welcome!";*/

        [HttpGet]
        [Route("{name}")]
        [ProducesResponseType(typeof(ICollection<Tag>[]), StatusCodes.Status200OK)]
        public async Task<IActionResult> TagsOnProfile(string name)
            => Ok(await _tagService.GetList((string)name));

        [HttpGet]
        [ProducesResponseType(typeof(ICollection<Tag>[]), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllTags()
            => Ok(await _tagService.GetAsync());
    }
}