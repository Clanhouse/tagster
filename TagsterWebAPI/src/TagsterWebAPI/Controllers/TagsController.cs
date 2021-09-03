using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tagster.Application.Services;
using Tagster.DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;

namespace TagsterWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TagsController : ControllerBase
    {
        private readonly ITagsService _tagService;

        public TagsController(ITagsService tagService)
            => _tagService = tagService;

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



    }
}