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

        public async Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await this.dbSet.Where(predicate).ToListAsync();
        }

        public async Task<IList<T>> GetAll()
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
            var entity = dbSet.Attach(t);
            dbCOontext.Entry(entity).State = EntityState.Modified;
            return t;
        }
    }
}
