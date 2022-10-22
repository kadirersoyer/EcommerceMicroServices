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
        ///  Get All
        /// </summary>
        /// <returns></returns>
        Task<IList<T>> GetAll();
    }
}
