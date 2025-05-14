using BackendRestApi.Models;
using BackendRestApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TrainingSeriesController : ControllerBase
    {
        private readonly TrainingSeriesRepository _trainingSeriesRepository;
        private readonly TrainingSeriesRepositorySpec _trainingSeriesRepositorySpec;

        public TrainingSeriesController(TrainingSeriesRepository trainingSeriesRepository,
            TrainingSeriesRepositorySpec trainingSeriesRepositorySpec)
        {
            _trainingSeriesRepository = trainingSeriesRepository;
            _trainingSeriesRepositorySpec = trainingSeriesRepositorySpec;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllTrainingSeries()
        {
            var trainingSeries = await _trainingSeriesRepository.GetAllAsync();
            return Ok(trainingSeries);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetTrainingSeriesById(int id)
        {
            var training = await _trainingSeriesRepository.GetByIdAsync(id);
            if (training == null) return NotFound();
            return Ok(training);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateTrainingSeries([FromBody] TrainingSeries training)
        {
            await _trainingSeriesRepository.AddAsync(training);
            return CreatedAtAction(nameof(GetTrainingSeriesById), new { id = training.Id }, training);
        }

        [HttpPost("user")]
        [Authorize]
        public async Task<IActionResult> GetTrainingSeriesByUserId([FromBody] UserIdRequest user)
        {
            var training = await _trainingSeriesRepositorySpec.GetListByUserIdAsync(user.Id);
            if (!training.Any()) return NotFound();

            var result = training.Select(t => new TrainingSeriesDto
            {
                Id = t.Id,
                TrainingType = t.TrainingType?.Name ?? "Brak",
                Weight = t.Weight ?? 0,
                Reps = t.Reps ?? 0,
                Sets = t.Sets ?? 0,
                Rpe = t.RPE ?? 0,
                DateTime = t.DateTime ?? DateTime.Now,
                BreaksInSeconds = t.BreaksInSeconds ?? 0,
                Trained = t.Trained ?? false
            }).ToList();

            return Ok(result);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateTrainingSeries(int id, [FromBody] TrainingSeries training)
        {
            if (id != training.Id) return BadRequest();

            await _trainingSeriesRepository.UpdateAsync(training);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteTrainingSeries(int id)
        {
            await _trainingSeriesRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}