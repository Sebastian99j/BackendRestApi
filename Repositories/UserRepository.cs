using BackendRestApi.Data;
using BackendRestApi.Models;

namespace BackendRestApi.Repositories
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(AIContext context) : base(context) { }
    }
}