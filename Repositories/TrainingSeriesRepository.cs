using BackendRestApi.Data;
using BackendRestApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendRestApi.Repositories
{
    public class TrainingSeriesRepository : Repository<TrainingSeries>
    {
        public TrainingSeriesRepository(IDbContextFactory<AIContext> contextFactory)
            : base(contextFactory) { }
    }
}