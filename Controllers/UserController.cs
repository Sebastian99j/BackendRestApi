using BackendRestApi.Models;
using BackendRestApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;

        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        //[HttpPost]
        //[Authorize]
        //public async Task<IActionResult> CreateUser([FromBody] User user)
        //{
        //    await _userRepository.AddAsync(user);
        //    return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        //}

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
        {
            if (id != user.Id) return BadRequest();

            await _userRepository.UpdateAsync(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}