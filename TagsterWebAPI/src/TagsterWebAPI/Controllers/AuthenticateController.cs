using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TagsterWebAPI.Models;


namespace TagsterWebAPI.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IJwtAuthenticationManager _jwtAuthenticationManager;
        private readonly SignInManager<IdentityUser> _signInManager;


        public AuthenticateController(SignInManager<IdentityUser> signInManager, IJwtAuthenticationManager jwtAuthenticationManager)
        {
            _signInManager = signInManager;
            _jwtAuthenticationManager = jwtAuthenticationManager;

        }


        // GET: api/<NameController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "tagster authentication"};
        }
        [HttpPost]
        [Route("SignUp")]
        public async Task<IActionResult> SignUp(SignUpViewModel signUpViewModel)
        {

            if (signUpViewModel.Password == signUpViewModel.ConfirmPassword && signUpViewModel.Password.Length >= 9)
                return Ok();
            else
                return Unauthorized();
                
        }

        [HttpPost]
        [Route("")]
        public IActionResult SignIn()
        {
           return Ok(new SignInViewModel());
        }

        [Authorize]
        [HttpPost]
        [Route("SignIn")]
        public async Task<IActionResult> SignIn(SignInViewModel signInViewModel)
        {
          await _signInManager.PasswordSignInAsync(signInViewModel.Email, signInViewModel.Password, false, false);
            return Ok();
        }

        [HttpPost]
        [Route("SignOut")]
        public async Task<IActionResult> SignOut()
        {
           await _signInManager.SignOutAsync();
            return Ok();
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
