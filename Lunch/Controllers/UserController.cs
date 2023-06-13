using Lunch.Interfaces;
using Lunch.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lunch.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("{userGuid}")]
        public async Task<IActionResult> GetUserById([FromRoute] Guid userGuid)
        {
            var user = await _userService.GetUserById(userGuid);

            if (user == null) return NotFound();

            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetUsers();

            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserModel userModel)
        {
            return Ok(await _userService.CreateUser(userModel));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UserModel userModel)
        {
            var user = await _userService.UpdateUser(userModel);

            if (user == null) return NotFound();
            
            return Ok(user);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid userId)
        {
            var result = await _userService.DeleteUser(userId);

            if (!result) return NotFound();

            return Ok();
        }
    }
}