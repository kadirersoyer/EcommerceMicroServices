using Mapster;

namespace CatalogService.Shared.Helpers
{
    public static class MapperHelper
    {
        /// <summary>
        ///  Generic Mapster Class
        /// </summary>
        /// <typeparam name="TData"></typeparam>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task<TReturn> MapTo<TData, TReturn>(TData data) where TReturn : class, new()
        {
            return await Task.Run(() =>
            {
                return data?.Adapt<TReturn>() ?? new TReturn();
            });
        }
    }
}
