using BackendRestApi.Models;
using BackendRestApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BackendRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingTypeController : ControllerBase
    {
        private readonly TrainingTypeRepository _trainingTypeRepository;

        public TrainingTypeController(TrainingTypeRepository trainingTypeRepository)
        {
            _trainingTypeRepository = trainingTypeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTrainingTypes()
        {
            var trainingTypes = await _trainingTypeRepository.GetAllAsync();
            return Ok(trainingTypes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrainingTypeById(int id)
        {
            var trainingType = await _trainingTypeRepository.GetByIdAsync(id);
            if (trainingType == null) return NotFound();
            return Ok(trainingType);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTrainingType([FromBody] TrainingType trainingType)
        {
            await _trainingTypeRepository.AddAsync(trainingType);
            await _trainingTypeRepository.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTrainingTypeById), new { id = trainingType.Id }, trainingType);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrainingType(int id, [FromBody] TrainingType trainingType)
        {
            if (id != trainingType.Id) return BadRequest();

            await _trainingTypeRepository.UpdateAsync(trainingType);
            await _trainingTypeRepository.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainingType(int id)
        {
            await _trainingTypeRepository.DeleteAsync(id);
            await _trainingTypeRepository.SaveChangesAsync();
            return NoContent();
        }
    }
}
