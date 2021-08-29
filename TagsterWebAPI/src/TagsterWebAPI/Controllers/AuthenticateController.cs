using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TagsterWebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TagsterWebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IJwtAuthenticationManager _jwtAuthenticationManager;
        
        public AuthenticateController(IJwtAuthenticationManager jwtAuthenticationManager)
        {
            _jwtAuthenticationManager = jwtAuthenticationManager;
        }

        // GET: api/<NameController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "tagster authentication"};
        }
        [HttpGet]
        public async Task<IActionResult> SignUp(SignUpViewModel signUpViewModel)
        {
            if (signUpViewModel.Password == signUpViewModel.ConfirmPassword)
                return Ok();
            else
                return Unauthorized();
                
        }

        // GET api/<NameController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserCredential userCredential)
        {
           var token =  _jwtAuthenticationManager.Authenticate(userCredential);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }
    }
}
