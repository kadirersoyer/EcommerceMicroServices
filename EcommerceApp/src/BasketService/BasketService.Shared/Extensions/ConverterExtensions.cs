using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketService.Shared.Extensions
{
    public static class ConverterExtensions
    {
        /// <summary>
        ///  Get Converted To Object From String
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T ToConvert<T>(this string obj) where T : class
        {
            var convertedData = JsonConvert.DeserializeObject<T>(obj);
            return convertedData ?? throw new InvalidCastException(nameof(obj));
        }


        /// <summary>
        ///  Get Converted To Object From String
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Task<string> ToConvertString<T>(this string obj) where T : class
        {
            var convertedData = JsonConvert.SerializeObject(obj);

            return Task.Run(() =>
            {
               return convertedData ?? throw new InvalidCastException(nameof(obj));
            });
        }
    }
}
