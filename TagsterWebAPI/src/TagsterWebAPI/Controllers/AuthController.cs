using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tagster.Application.Commands.SignUp;

namespace TagsterWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
            => _mediator = mediator;

        /// <summary>
        /// Sign up user
        /// </summary>
        /// <param name="command">Request body which user would be sign up</param>
        /// <returns>status code 201 created</returns>
        [HttpPost("sign-up")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SignUp([FromBody] SignUp command)
        {
            if (!command.Password.Equals(command.ConfirmPassword))
            {
                return BadRequest("Passwords do not match!");
            }

            await _mediator.Send(command);
            return Accepted();
        }

        //[HttpGet]
        //public IEnumerable<string> Get()
        //    => new string[] { "tagster authentication" };

        //[HttpPost]
        //[Route("SignUp")]
        //public async Task<IActionResult> SignUp(SignUpViewModel signUpViewModel)
        //{
        //    if (signUpViewModel.Password == signUpViewModel.ConfirmPassword
        //        && signUpViewModel.Password.Length >= 9)
        //    {
        //        return Ok();
        //    }
        //    else
        //    {
        //        return Unauthorized();
        //    }
        //}

        //[HttpPost]
        //[Route("")]
        //public IActionResult SignIn()
        //    => Ok(new SignInViewModel());

        //[Authorize]
        //[HttpPost]
        //[Route("SignIn")]
        //public async Task<IActionResult> SignIn(SignInViewModel signInViewModel)
        //{
        //    await _signInManager.PasswordSignInAsync(signInViewModel.Email,
        //        signInViewModel.Password, false, false);
        //    return Ok();
        //}

        //[HttpPost]
        //[Route("SignOut")]
        //public async Task<IActionResult> SignOut()
        //{
        //    await _signInManager.SignOutAsync();
        //    return Ok();
        //}

        //[HttpGet("{id}")]
        //public string Get(int id) => "value";

        //[AllowAnonymous]
        //[HttpPost("authenticate")]
        //public IActionResult Authenticate([FromBody] UserCredential userCredential)
        //{
        //    var token = _jwtAuthenticationManager.Authenticate(userCredential);
        //    if (token == null)
        //    {
        //        return Unauthorized();
        //    }

        //    return Ok(token);
        //}
    }
}
