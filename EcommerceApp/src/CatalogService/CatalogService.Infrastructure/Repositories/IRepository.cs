using System.Linq.Expressions;

namespace CatalogService.Infrastructure.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        /// <summary>
        ///  Add To Context
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        Task<T> Add(T t);

        /// <summary>
        ///  Update To Context
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>

        Task<T> Update(T t);


        /// <summary>
        ///  Get By Id To Context
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>

        Task<T> GetById(object id);


        /// <summary>
        ///  Delete by id from Context
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>

        Task<bool> DeleteById(object id);

        /// <summary>
        ///  Get All
        /// </summary>
        /// <returns></returns>
        Task<List<T>> GetAll();

        /// <summary>
        ///  For Quries
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate);
    }
}
