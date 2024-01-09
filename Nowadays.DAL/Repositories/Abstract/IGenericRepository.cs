using System.Linq.Expressions;

namespace Nowadays.DAL.Repositories.Abstractl
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int entityId);
        Task<TEntity> GetWhereAsync(Expression<Func<TEntity, bool>> filter);
        Task<IEnumerable<TEntity>> GetWhereListAsync(Expression<Func<TEntity, bool>> filter);
        Task InsertAsync(TEntity entity);
        Task Delete(TEntity entity);
        Task<int> UpdateAsync(TEntity entity);
        IQueryable<TEntity> GetAll();
    }
}
