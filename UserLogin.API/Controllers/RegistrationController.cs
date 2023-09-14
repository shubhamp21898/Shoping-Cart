using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserLogin.API.Model;
using UserLogin.API.Services;
using UserLogin.API.Services.Implementations;

namespace UserLogin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _iUserService;
        public RegistrationController(IConfiguration configuration, IUserService iUserService)
        {
            _configuration = configuration;
            _iUserService = iUserService;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Registration>> GetUserById(int id)
        {
            var user = await _iUserService.GetUserById(id);
            if (user == null)
                return NotFound();

            return user;
        }

        [HttpPost("register")]
        public async Task<ActionResult<Registration>> RegisterUser([FromBody] Registration userRegistration)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var newUser = await _iUserService.RegisterUser(userRegistration);
            return CreatedAtAction(nameof(GetUserById), new { id = newUser.Id }, newUser);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] Login loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var token = await _iUserService.Login(loginDto.UserName, loginDto.Password);

            if (token == null)
                return Unauthorized();

            return token;
        }
    }
}
