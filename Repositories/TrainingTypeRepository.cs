using BackendRestApi.Data;
using BackendRestApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendRestApi.Repositories
{
    public class TrainingTypeRepository : Repository<TrainingType>
    {
        public TrainingTypeRepository(IDbContextFactory<AIContext> contextFactory)
            : base(contextFactory) { }
    }
}