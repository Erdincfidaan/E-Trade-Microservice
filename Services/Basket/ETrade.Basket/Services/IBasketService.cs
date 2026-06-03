using ETrade.Basket.Dtos;

namespace ETrade.Basket.Services
{
    public interface IBasketService
    {
        Task<BasketTotalDto> GetBasketItemAsync(string userId);
        Task SaveBasket(BasketTotalDto basketTotalDto);
        Task DeleteBasketItemAsync(string userId);

    }
}
