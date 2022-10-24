using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CatalogService.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private CatalogContext dbCOontext;
        private DbSet<T> dbSet;

        public Repository(CatalogContext dbCOontext)
        {
            this.dbCOontext = dbCOontext;
            this.dbSet = this.dbCOontext.Set<T>();
        }
        public async Task<T> Add(T t)
        {
            await dbCOontext.AddAsync(t);
            return t;
        }

        public async Task<bool> DeleteById(object id)
        {
            var entity = await GetById(id);
            if (entity != null) { dbCOontext.Remove(entity); return true; }
            return false;
        }

        public async Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await this.dbSet.Where(predicate).ToListAsync();
        }

        public async Task<List<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<T> GetById(object id)
        {
            var entity = await dbSet.FindAsync(id);
            return entity ?? throw new ArgumentNullException();
        }

        public async Task<T> Update(T t)
        {
            return await Task.Run(() =>
            {
                dbCOontext.Update(t);
                return t;
            });
        }
    }
}
