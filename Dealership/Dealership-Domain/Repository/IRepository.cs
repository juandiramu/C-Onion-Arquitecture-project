

using System.Linq.Expressions;

namespace Dealership_Domain.Repository
{
    public interface IRepository<TEntity, TId>
       where TEntity : Entity<TId>
       where TId : IComparable, IComparable<TId>
    {
        public Task<TEntity?> GetBytIdAsync(TId TId);
        public Task<IEnumerable<TEntity>?> GetAllAsync();
        public Task<TEntity?> InsertAsync(TEntity entity);
        public Task<TEntity?> UpdateAsync(TEntity entity);
        public Task<TEntity?> DeleteAsync(TEntity entity);
        public Task<TEntity?> DeleteByIdAsync(TId id);
        public Task<IEnumerable<TEntity>?> GetAllByFilterAsync(Expression<Func<TEntity, bool>> predicate);
        public Task<TEntity?> GetFirtsByFilterAsync(Expression<Func<TEntity, bool>> predicate);
        public Task<IEnumerable<TEntity>?> GetPageByFilterAsync(Expression<Func<TEntity, bool>> predicate, int page, int size);
        public object GetContext();
        public Task Save();

    }
}
