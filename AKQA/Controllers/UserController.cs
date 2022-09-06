using AKQA.Authorization;
using AKQA.Entities;
using AKQA.Helpers;
using AKQA.Models.User;
using AKQA.Services.UserServices;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AKQA.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService service;
        private IMapper mapper;
        private readonly AppSettings appSettings;

        public UserController(IUserService service, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            this.service = service;
            this.mapper = mapper;
            this.appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = service.Authenticate(model);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register(RegisterRequest model)
        {
            service.Register(model);
            return Ok(new { message = "Registration successful" });
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = service.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = service.GetUserById(id);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, UpdateRequest model)
        {
            service.UpdateUser(id, model);
            return Ok(new { message = "User updated successfully" });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            service.DeleteUser(id);
            return Ok(new { message = "User deleted successfully" });
        }
    }
}
