using BackendRestApi.Models;
using BackendRestApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BackendRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingSeriesController : ControllerBase
    {
        private readonly TrainingSeriesRepository _trainingSeriesRepository;

        public TrainingSeriesController(TrainingSeriesRepository trainingSeriesRepository)
        {
            _trainingSeriesRepository = trainingSeriesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTrainingSeries()
        {
            var trainingSeries = await _trainingSeriesRepository.GetAllAsync();
            return Ok(trainingSeries);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrainingSeriesById(int id)
        {
            var training = await _trainingSeriesRepository.GetByIdAsync(id);
            if (training == null) return NotFound();
            return Ok(training);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTrainingSeries([FromBody] TrainingSeries training)
        {
            await _trainingSeriesRepository.AddAsync(training);
            return CreatedAtAction(nameof(GetTrainingSeriesById), new { id = training.Id }, training);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrainingSeries(int id, [FromBody] TrainingSeries training)
        {
            if (id != training.Id) return BadRequest();

            await _trainingSeriesRepository.UpdateAsync(training);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainingSeries(int id)
        {
            await _trainingSeriesRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}