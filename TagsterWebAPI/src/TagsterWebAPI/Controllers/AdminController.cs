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

        /// <summary>
        /// Generates (profilesCount) profiles and assigns to them number of tags between 0 and (maxTagsPerProfile)
        /// </summary>
        /// <param name="profilesCount"> Number of generated profiles depend on this parameter </param>
        /// <param name="maxTagsPerProfile"> Number of generated tags depend on this parameter (0-maxTagsPerProfile) </param>
        /// <returns></returns>
        [HttpGet]
        [Route("generate-fake-data/p{profilesCount}/max{maxTagsPerProfile}")]
        public async Task<IActionResult> GenFakeData(int profilesCount, int maxTagsPerProfile)
        {
            await _adminService.CreateFakeDataAsync(profilesCount, maxTagsPerProfile);
            return Ok();
        }

    }
}
