using Microsoft.EntityFrameworkCore;

namespace BackendRestApi.Data
{
    public class AIContextSingleton
    {
        private static AIContext _instance;
        private static readonly object _lock = new();

        private AIContextSingleton() { }

        public static AIContext GetInstance(DbContextOptions<AIContext> options)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new AIContext(options);
                    }
                }
            }
            return _instance;
        }
    }
}
