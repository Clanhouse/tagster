using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tagster.Application.Dtos.Requests;
using Tagster.Application.Services;

namespace TagsterWebAPI.Controllers
{
    [Route("profile")]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;
        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProfileRequest createProfileRequest)
        {
            await _profileService.Create(createProfileRequest);
            return Ok();
        }
    }
}
