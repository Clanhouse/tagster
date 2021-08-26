using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TagsterWebAPI.Controllers
{
    public class AccountController : ControllerBase
    {
        [HttpGet]
        public IActionResult Register()
        {
            return Ok();
        }
    }


}
