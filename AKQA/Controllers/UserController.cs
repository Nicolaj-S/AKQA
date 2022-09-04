using AKQA.Domain;
using AKQA.Services.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace AKQA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService service;

        public UserController(IUserService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await service.GetAllUsers();
            if (!ModelState.IsValid)
                return NotFound(ModelState);

            return Ok(users);
        }

        [HttpGet("Id/{Id}")]
        public async Task<IActionResult> GetUserById(int Id)
        {
            var user = await service.GetUserById(Id);
            if (!ModelState.IsValid)
                return NotFound(ModelState);

            return Ok(user);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateUser(User user)
        {
            var result = await service.CreateUser(user);
            return result ? Ok(CreateUser) : BadRequest();
        }

        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> DeleteUser(int Id)
        {
            var UserToDelete = await service.GetUserById(Id);
            var result = await service.DeleteUser(UserToDelete);
            return result ? Ok(DeleteUser) : BadRequest();
        }

        [HttpPatch("Update/{Id}")]
        public async Task<IActionResult> UpdateUser(int Id, [FromBody] User user)
        {
            if (user == null)
                return NotFound(ModelState);
            if (!ModelState.IsValid)
                return NotFound(ModelState);
            if (Id != user.Id)
                return NotFound(ModelState);

            var result = await service.UpdateUser(user);
            return result ? Ok(UpdateUser) : BadRequest();
        }
    }
}
