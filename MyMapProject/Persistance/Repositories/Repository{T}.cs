using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using MyMapProject.Core.Application.Interfaces;
using MyMapProject.Persistance.Context;

namespace MyMapProject.Persistance.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly LocationsContext locationsContext;
        public Repository(LocationsContext locationsContext)
        {
            this.locationsContext = locationsContext;
        }
        public async Task CreateAsync(T entity)
        {
            await this.locationsContext.Set<T>().AddAsync(entity);
            await this.locationsContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await this.locationsContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            return await this.locationsContext.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter);
        }

        public async Task<T?> GetByIdAsync(object id)
        {
            return await this.locationsContext.Set<T>().FindAsync(id);
        }

        public async Task RemoveAsync(T entity)
        {
            this.locationsContext.Set<T>().Remove(entity);
            await this.locationsContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            this.locationsContext.Set<T>().Update(entity);
            await this.locationsContext.SaveChangesAsync();
        }
    }
}
