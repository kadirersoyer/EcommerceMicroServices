using Newtonsoft.Json;

namespace BasketService.Infrastructure.Extensions
{
    public static class ConverterExtensions
    {
        /// <summary>
        ///  Get Converted To Object From String
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Task<T> ToConvertToObj<T>(this string obj) where T: class
        {
            var convertedData = JsonConvert.DeserializeObject<T>(obj);
            return Task.Run(() =>
            {
                return convertedData ?? throw new InvalidCastException(nameof(obj));
            });
        }


        /// <summary>
        ///  Get Converted To Object From String
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Task<string> ToConvertToString<T>(this T obj) where T : class
        {
            var convertedData = JsonConvert.SerializeObject(obj);
            return Task.Run(() =>
            {
                return convertedData ?? throw new InvalidCastException(nameof(obj));
            });
        }
    }
}
