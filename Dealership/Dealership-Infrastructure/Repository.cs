using Microsoft.EntityFrameworkCore;
using Dealership_Domain.Repository;
using Dealership_Infrastructure.EntityFramework;
using System.Linq.Expressions;
using Dealership_Domain;

namespace Dealership_Infrastructure
{
    public class Repository<TEntity, TId> : IRepository<TEntity, TId>
        where TEntity : Entity<TId>
        where TId : IComparable, IComparable<TId>
    {

        private readonly DealershipDbContext dbContext;
        private readonly DbSet<TEntity> dbSet;

        public Repository(DealershipDbContext dbContext) => (this.dbContext, this.dbSet) = (dbContext, dbContext.GetDbSet<TEntity, TId>());

        public async Task<TEntity?> DeleteAsync(TEntity entity)
        {
            await Task.Factory.StartNew(() =>
            {
                dbSet.Remove(entity);
            });

            return entity;
        }

        public async Task<TEntity?> DeleteByIdAsync(TId id)
        {
            var entity = await dbSet.FirstOrDefaultAsync(it => it.Id!.Equals(id));
            if (entity != null) return await DeleteAsync(entity);
            return default;
        }

        public async Task<IEnumerable<TEntity>?> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>?> GetAllByFilterAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Task.Factory.StartNew(() =>
            {
                return dbSet.Where(predicate);
            });
        }

        public async Task<TEntity?> GetBytIdAsync(TId id)
        {
            return await dbSet.FirstOrDefaultAsync(it => it.Id!.Equals(id));
        }

        public async Task<TEntity?> GetFirtsByFilterAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await dbSet.FirstOrDefaultAsync(predicate);
        }

        public Task<IEnumerable<TEntity>?> GetPageByFilterAsync(Expression<Func<TEntity, bool>> predicate, int page, int size)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity?> InsertAsync(TEntity entity)
        {
            entity.CreationDate = DateTime.UtcNow;
            await dbSet.AddAsync(entity);
            return entity;
        }


        public async Task<TEntity?> UpdateAsync(TEntity entity)
        {
            await Task.Factory.StartNew(() =>
            {
                dbSet.Update(entity);
            });
            return entity;
        }

        public async Task Save()
        {
            await dbContext.SaveChangesAsync();
        }


        public object GetContext()
        {
            return dbContext;
        }

    }
}
