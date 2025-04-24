using BackendRestApi.Data;
using BackendRestApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendRestApi.Repositories
{
    public class UsersRepository : Repository<Users>
    {
        public UsersRepository(IDbContextFactory<AIContext> contextFactory)
            : base(contextFactory) { }
    }
}