using BackendRestApi.Models;
using BackendRestApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TrainingTypeController : ControllerBase
    {
        private readonly TrainingTypesRepository _trainingTypeRepository;

        public TrainingTypeController(TrainingTypesRepository trainingTypeRepository)
        {
            _trainingTypeRepository = trainingTypeRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllTrainingTypes()
        {
            var trainingTypes = await _trainingTypeRepository.GetAllAsync();
            return Ok(trainingTypes);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetTrainingTypeById(int id)
        {
            var trainingType = await _trainingTypeRepository.GetByIdAsync(id);
            if (trainingType == null) return NotFound();
            return Ok(trainingType);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateTrainingType([FromBody] TrainingTypes trainingType)
        {
            await _trainingTypeRepository.AddAsync(trainingType);
            return CreatedAtAction(nameof(GetTrainingTypeById), new { id = trainingType.Id }, trainingType);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateTrainingType(int id, [FromBody] TrainingTypes trainingType)
        {
            if (id != trainingType.Id) return BadRequest();

            await _trainingTypeRepository.UpdateAsync(trainingType);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteTrainingType(int id)
        {
            await _trainingTypeRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}