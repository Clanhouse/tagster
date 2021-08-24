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
        /// brief
        /// </summary>
        /// <param name="profilesCount"> here </param>
        /// <param name="maxTagsPerProfile"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("generate-fake-data/p{profilesCount}/max{maxTagsPerProfile}")]
        public async Task<IActionResult> GenFakeData(int profilesCount, int maxTagsPerProfile)
        {
            await _adminService.CreateFakeData(profilesCount, maxTagsPerProfile);
            return Ok();
        }

    }
}
