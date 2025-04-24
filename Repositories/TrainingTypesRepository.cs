using BackendRestApi.Data;
using BackendRestApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendRestApi.Repositories
{
    public class TrainingTypesRepository : Repository<TrainingTypes>
    {
        public TrainingTypesRepository(IDbContextFactory<AIContext> contextFactory)
            : base(contextFactory) { }
    }
}