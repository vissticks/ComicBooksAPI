using System.Threading.Tasks;
using AutoMapper;
using ComicBooksAPI.Users.Models;
using ComicBooksAPI.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ComicBooksAPI.Users
{
    [Route("api/[controller]/[action]")]
    public class AuthController : Controller
    {
        private readonly IMapper _mapper;
        private readonly AuthService _auth;

        public AuthController(AuthService auth, IMapper mapper)
        {
            _mapper = mapper;
            _auth = auth;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserRegistrationDto model)
        {
            var user = _mapper.Map<User>(model);
            var result = await _auth.Register(user, model.Password);

            if (result.Succeeded)
            {
                return Ok(_mapper.Map<UserDto>(user));
            }

            return BadRequest(result.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserLoginDto model)
        {
            try
            {
                var user = await _auth.Authenticate(model.Username, model.Password);
                return Ok(new { Token = _auth.GenerateJwtToken(user) });
            }
            catch (AuthenticationFailedException e)
            {
                return Unauthorized(new { Error = e.Message });
            }
        }
    }
}