using BackendRestApi.Data;
using BackendRestApi.Models;

namespace BackendRestApi.Repositories
{
    public class TrainingSeriesRepository : Repository<TrainingSeries>
    {
        public TrainingSeriesRepository(AIContext context) : base(context) { }
    }
}