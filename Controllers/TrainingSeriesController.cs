﻿using BackendRestApi.Models;
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

        public TrainingSeriesController(TrainingSeriesRepository trainingSeriesRepository)
        {
            _trainingSeriesRepository = trainingSeriesRepository;
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