using BackendRestApi.Data;
using BackendRestApi.Models;

namespace BackendRestApi.Repositories
{
    public class AuthenticationRepository : Repository<Authentication>
    {
        public AuthenticationRepository(AIContext context) : base(context) { }
    }
}