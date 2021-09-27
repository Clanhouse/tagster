using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tagster.Application.Services;
using TagsterWebAPI.Controllers;
using Xunit;

namespace TagsterWebAPI.UnitTests
{
    public class AdminControllerTests
    {
        private readonly IAdminService adminService;
        [Fact]
        /// Generates (profilesCount) profiles and assigns to them number of tags between 0 and (maxTagsPerProfile)
        public void Generates_Profiles_AssignsToThemNumberOfTags_Between_0_and_Max()
        {
            adminService.CreateFakeDataAsync(1, 7);
        }
    } 
}
