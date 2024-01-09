using Microsoft.EntityFrameworkCore;
using Nowadays.DAL.Repositories.Abstractl;
using System.Linq.Expressions;

namespace Nowadays.DAL.Repositories.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DbContext c;
        private DbSet<T> entities;
        public GenericRepository(DbContext dbContext)
        {
            c = dbContext;
            entities = dbContext.Set<T>();
        }
        public IQueryable<T> GetAll()
        {
            //  return await entities.AsNoTracking().ToListAsync();
            return entities.AsNoTracking().AsQueryable();
        }

        public async Task<T> GetWhereAsync(Expression<Func<T, bool>> filter = null)
        {
            return await entities.FirstOrDefaultAsync(filter);
        }

        public async Task<T> GetByIdAsync(int entityId)
        {
            return await entities.Where(entity => EF.Property<int>(entity, "Id").Equals(entityId)).SingleOrDefaultAsync();

        }

        public async Task InsertAsync(T entity)
        {
            entity.GetType().GetProperty("CreatedDate").SetValue(entity, DateTime.Now);
            try
            {
                await entities.AddAsync(entity);
                await c.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task Delete(T entity)
        {
            c.Remove(entity);
            await c.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(T entity)
        {
            entity.GetType().GetProperty("UpdatedDate").SetValue(entity, DateTime.Now);
            entities.Update(entity);
            return await c.SaveChangesAsync();

        }

        public async Task<IEnumerable<T>> GetWhereListAsync(Expression<Func<T, bool>> filter)
        {
            return await entities.Where(filter).ToListAsync();
        }
    }
}
