using BasketService.Infrastructure.Entities;
using BasketService.Infrastructure.Extensions;
using Microsoft.Extensions.Caching.Distributed;

namespace BasketService.Infrastructure.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _redisCache;

        public BasketRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache ?? throw new ArgumentNullException(nameof(redisCache));
        }
        public async Task DeleteBasket(string userName)
        {
            var basket = await _redisCache.GetStringAsync(userName);
            if (!string.IsNullOrEmpty(basket))
                _redisCache.Remove(userName);
        }

        public async Task<ShoppingCart> GetBasket(string userName)
        {
            var basket = await _redisCache.GetStringAsync(userName);
            if (string.IsNullOrEmpty(basket))
                return null;
            return await basket.ToConvertToObj<ShoppingCart>();
        }

        public async Task<ShoppingCart> UpdateBasket(ShoppingCart shoppingCart)
        {
            var serializedData = await shoppingCart.ToConvertToString();
            await _redisCache.SetStringAsync(shoppingCart.UserName, serializedData);
            var basket = await _redisCache.GetStringAsync(shoppingCart.UserName);
            if (string.IsNullOrEmpty(basket))
                return new ShoppingCart(shoppingCart.UserName ?? string.Empty);

            return await basket.ToConvertToObj<ShoppingCart>();
        }
    }
}
