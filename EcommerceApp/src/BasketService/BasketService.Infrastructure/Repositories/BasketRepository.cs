using BasketService.Infrastructure.Entities;
using BasketService.Infrastructure.Extensions;
using StackExchange.Redis;

namespace BasketService.Infrastructure.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDatabase _redisCache;

        public BasketRepository(IDatabase redisCache)
        {
            _redisCache = redisCache ?? throw new ArgumentNullException(nameof(redisCache));
        }
        public async Task DeleteBasket(string userName)
        {
            var basket = (await _redisCache.StringGetAsync(userName)).ToString();
            if (!string.IsNullOrEmpty(basket))
                await _redisCache.StringGetDeleteAsync(userName);
        }

        public async Task<ShoppingCart> GetBasket(string userName)
        {
            var basket = (await _redisCache.StringGetAsync(userName)).ToString(); 
            if (string.IsNullOrEmpty(basket))
                return null;
            return await basket.ToConvertToObj<ShoppingCart>();
        }

        public async Task<ShoppingCart> UpdateBasket(ShoppingCart shoppingCart)
        {
            var serializedData = await shoppingCart.ToConvertToString();
            await _redisCache.StringSetAsync(shoppingCart.UserName, serializedData);
            var basket = (await _redisCache.StringGetAsync(shoppingCart.UserName)).ToString();
            if (string.IsNullOrEmpty(basket))
                return new ShoppingCart(shoppingCart.UserName ?? string.Empty);

            return await basket.ToConvertToObj<ShoppingCart>();
        }
    }
}
