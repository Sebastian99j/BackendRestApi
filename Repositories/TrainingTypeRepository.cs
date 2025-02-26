using BackendRestApi.Data;
using BackendRestApi.Models;

namespace BackendRestApi.Repositories
{
    public class TrainingTypeRepository : Repository<TrainingType>
    {
        public TrainingTypeRepository(AIContext context) : base(context) { }
    }
}