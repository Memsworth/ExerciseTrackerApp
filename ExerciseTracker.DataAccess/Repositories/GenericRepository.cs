using ExerciseTracker.Domain.Abstractions.Repositories;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace ExerciseTracker.DataAccess.Repositories
{
    public class GenericRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly ExerciseTrackerDbContext DbContext;

        public GenericRepository(ExerciseTrackerDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task AddAsync(T entity)
        {
            if (entity == null)
            {
                
                throw new ArgumentNullException($"{nameof(entity)}","can't be a null item");
            }
            try
            {
                await DbContext.AddAsync(entity);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task DeleteAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(entity)}","Entity doesn't exist");
            }
            try
            {
                await Task.Run(async() => DbContext.Remove(entity)) ;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        
        public async Task<List<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetAsync(int id)
        {
            try
            {
                return await DbContext.Set<T>().FindAsync(id) ?? throw new KeyNotFoundException();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
        public async Task<List<T>> GetAsync()
        {
            try
            {
                return await DbContext.Set<T>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(entity)}", "Entity can't be null");
            }
            try
            {
                await Task.Run(async() => DbContext.Update(entity));
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
    }
}
