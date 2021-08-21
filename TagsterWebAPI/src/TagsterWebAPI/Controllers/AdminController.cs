using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tagster.Application.Services;
using Tagster.DataAccess.Entities;

namespace TagsterWebAPI.Controllers
{
    [Route("admin")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
            => _adminService = adminService;

        [HttpGet]
        [Route("generate-fake-data/p{profilesCount}/max{maxTagsPerProfile}")]//add variables to route! (profilesCount, maxTagsPerProfile)
        //[ProducesResponseType(typeof(ICollection<Tag>[]), StatusCodes.Status200OK)]
        public async Task<IActionResult> GenFakeData(int profilesCount, int maxTagsPerProfile)
        {
            await _adminService.CreateFakeData(profilesCount, maxTagsPerProfile);
            return Ok();
        }

    }
}
