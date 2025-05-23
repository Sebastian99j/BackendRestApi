﻿using BackendRestApi.Data;
using Microsoft.EntityFrameworkCore;

namespace BackendRestApi.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IDbContextFactory<AIContext> _contextFactory;

        public Repository(IDbContextFactory<AIContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<T?> GetByNameAsync(string name)
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.Set<T>().FirstOrDefaultAsync(e => EF.Property<string>(e, "Username") == name);
        }

        public async Task<List<T>> GetListByUserIdAsync(int userId)
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.Set<T>()
                .Where(e => EF.Property<int>(e, "UserId") == userId)
                .ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            using var context = _contextFactory.CreateDbContext();
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            using var context = _contextFactory.CreateDbContext();
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            using var context = _contextFactory.CreateDbContext();
            var entity = await context.Set<T>().FindAsync(id);
            if (entity != null)
            {
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();
            }
        }
    }
}