using BasketService.Infrastructure.Entities;
using BasketService.Infrastructure.Repositories;

namespace BasketService.Business.Services
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketRepository;

        public BasketService(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }
        public async Task DeleteBasket(string userName)
        {
            await _basketRepository.DeleteBasket(userName);
        }

        public async Task<ShoppingCart> GetBasket(string userName)
        {
            return await _basketRepository.GetBasket(userName);
        }

        public async Task<ShoppingCart> UpdateBasket(ShoppingCart shoppingCart)
        {
            return await _basketRepository.UpdateBasket(shoppingCart);
        }
    }
}
