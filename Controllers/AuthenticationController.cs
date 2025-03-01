//using BackendRestApi.Models;
//using BackendRestApi.Repositories;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;

//namespace BackendRestApi.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    [Authorize]
//    public class AuthenticationController : ControllerBase
//    {
//        private readonly AuthenticationRepository _authRepository;

//        public AuthenticationController(AuthenticationRepository authRepository)
//        {
//            _authRepository = authRepository;
//        }

//        [HttpGet]
//        [Authorize]
//        public async Task<IActionResult> GetAllAuthentications()
//        {
//            var auths = await _authRepository.GetAllAsync();
//            return Ok(auths);
//        }

//        [HttpGet("{id}")]
//        [Authorize]
//        public async Task<IActionResult> GetAuthenticationById(int id)
//        {
//            var auth = await _authRepository.GetByIdAsync(id);
//            if (auth == null) return NotFound();
//            return Ok(auth);
//        }

//        [HttpPost]
//        [Authorize]
//        public async Task<IActionResult> CreateAuthentication([FromBody] Authentication auth)
//        {
//            await _authRepository.AddAsync(auth);
//            return CreatedAtAction(nameof(GetAuthenticationById), new { id = auth.id }, auth);
//        }

//        [HttpPut("{id}")]
//        [Authorize]
//        public async Task<IActionResult> UpdateAuthentication(int id, [FromBody] Authentication auth)
//        {
//            if (id != auth.id) return BadRequest();

//            await _authRepository.UpdateAsync(auth);
//            return NoContent();
//        }

//        [HttpDelete("{id}")]
//        [Authorize]
//        public async Task<IActionResult> DeleteAuthentication(int id)
//        {
//            await _authRepository.DeleteAsync(id);
//            return NoContent();
//        }
//    }
//}