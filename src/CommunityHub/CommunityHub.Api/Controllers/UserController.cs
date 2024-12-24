using CommunityHub.Application.DTOs;
using CommunityHub.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CommunityHub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/User/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUserByIdAsync(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUserAsync([FromBody] UserDto userDto)
        {
            var userId = await _userService.CreateUserAsync(userDto);
            return CreatedAtAction(nameof(GetUserByIdAsync), new { id = userId });
        }

        // PUT: api/User
        [HttpPut]
        public async Task<ActionResult> UpdateUserAsync([FromBody] UserDto userDto)
        {
            await _userService.UpdateUserAsync(userDto);
            return CreatedAtAction(nameof(UpdateUserAsync), new { userDto.Id });
        }
    }
}