using BackendRestApi.Data;
using BackendRestApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendRestApi.Repositories
{
    public class AuthenticationRepository : Repository<Authentication>
    {
        public AuthenticationRepository(IDbContextFactory<AIContext> contextFactory)
            : base(contextFactory) { }
    }
}