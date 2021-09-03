using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        public AuthenticateController(SignInManager<IdentityUser> signInManager,
            IJwtAuthenticationManager jwtAuthenticationManager)
        {
            _signInManager = signInManager;
            _jwtAuthenticationManager = jwtAuthenticationManager;
        }

        [HttpGet]
        public IEnumerable<string> Get()
            => new string[] { "tagster authentication" };

        [HttpPost]
        [Route("SignUp")]
        public async Task<IActionResult> SignUp(SignUpViewModel signUpViewModel)
        {
            if (signUpViewModel.Password == signUpViewModel.ConfirmPassword
                && signUpViewModel.Password.Length >= 9)
            {
                return Ok();
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost]
        [Route("")]
        public IActionResult SignIn()
            => Ok(new SignInViewModel());

        [Authorize]
        [HttpPost]
        [Route("SignIn")]
        public async Task<IActionResult> SignIn(SignInViewModel signInViewModel)
        {
            await _signInManager.PasswordSignInAsync(signInViewModel.Email,
                signInViewModel.Password, false, false);
            return Ok();
        }

        [HttpPost]
        [Route("SignOut")]
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }

        [HttpGet("{id}")]
        public string Get(int id) => "value";

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserCredential userCredential)
        {
            var token = _jwtAuthenticationManager.Authenticate(userCredential);
            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}
