using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tagster.Application.Commands.GenFakeData;
using Tagster.Application.Services;

namespace TagsterWebAPI.Controllers
{
    [Route("admin")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IMediator _mediator;
 

        public AdminController(IAdminService adminService, IMediator mediator)
        {
            _adminService = adminService;
            _mediator = mediator;
        }

        /// <summary>
        /// Generates (profilesCount) profiles and assigns to them number of tags between 0 and (maxTagsPerProfile)
        /// </summary>
        /// <param name="profilesCount"> Number of generated profiles depend on this parameter </param>
        /// <param name="maxTagsPerProfile"> Number of generated tags depend on this parameter (0-maxTagsPerProfile) </param>
        /// <returns></returns>
        [HttpGet]
        [Route("generate-fake-data/p{command.profilesCount}/max{command.maxTagsPerProfile}")]
        public async Task<IActionResult> GenFakeData(GenFakeData command)
        {
            await _mediator.Send(command);
            return Ok();
        }

    }
}
