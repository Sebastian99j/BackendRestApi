using BackendRestApi.Data;
using BackendRestApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendRestApi.Repositories
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(IDbContextFactory<AIContext> contextFactory)
            : base(contextFactory) { }
    }
}