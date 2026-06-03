using ETrade.Basket.Dtos;
using ETrade.Basket.Settings;
using System.Text.Json;

namespace ETrade.Basket.Services
{
    public class BasketServices : IBasketService
    {
        private readonly RedisService _redisService;
        public BasketServices(RedisService redisService)
        {
            _redisService = redisService;
        }
        public Task DeleteBasketItemAsync(string userId)
        {
            var result = _redisService.GetDb().KeyDeleteAsync(userId);
            return result;

        }

        public async Task<BasketTotalDto> GetBasketItemAsync(string userId)
        {
            string key = $"basket:{userId}";
            var existBasket= await _redisService.GetDb().StringGetAsync(key);
            return  JsonSerializer.Deserialize<BasketTotalDto>(existBasket);
        }

        public async Task SaveBasket(BasketTotalDto basketTotalDto)
        {
            string key = $"basket:{basketTotalDto.UserId}";
            await _redisService.GetDb().StringSetAsync(key, JsonSerializer.Serialize(basketTotalDto));
        }
    }
}
