﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagsterWebAPI.Controllers;
using Xunit;

namespace TagsterWebAPI.UnitTests
{
    public class AdminControllerTests
    {
        [Fact]
        /// Generates (profilesCount) profiles and assigns to them number of tags between 0 and (maxTagsPerProfile)
        public void Generates_Profiles_AssignsToThemNumberOfTags_Between_0_and_Max()
        {
            //Arrange
            var adminController = new AdminController(); 

            //Act


            //Assert
        }
    }
}
