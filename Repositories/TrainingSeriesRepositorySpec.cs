﻿using BackendRestApi.Data;
using BackendRestApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendRestApi.Repositories
{
    public class TrainingSeriesRepositorySpec
    {
        private readonly IDbContextFactory<AIContext> _contextFactory;

        public TrainingSeriesRepositorySpec(IDbContextFactory<AIContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<List<TrainingSeries>> GetListByUserIdAsync(int userId)
        {
            using var context = _contextFactory.CreateDbContext();

            return await context.TrainingSeries
                .Include(t => t.TrainingType)
                .Where(t => t.UserId == userId)
                .ToListAsync();
        }

        public int? GetTrainingTypeId(string typeName)
        {
            using var _context = _contextFactory.CreateDbContext();

            var trainingType = _context.TrainingTypes.FirstOrDefault(t => t.Name == typeName);
            return trainingType?.Id;
        }

    }
}
