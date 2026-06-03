using ETrade.Basket.Dtos;
using ETrade.Basket.LoginServices;
using ETrade.Basket.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.Basket.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly ILoginServices _loginServices;
        public BasketsController(IBasketService basketService, ILoginServices loginServices)
        {
            _basketService = basketService;
            _loginServices = loginServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasket()
        {
            var result = await _basketService.GetBasketItemAsync(_loginServices.GetUserId);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBasket()
        {
            await _basketService.DeleteBasketItemAsync(_loginServices.GetUserId);
            return Ok("Sepetteki ürünler başarıyla silindi");
        }
        [HttpPost]
        public async Task<IActionResult> SaveBasket(BasketTotalDto basketTotalDto)
        {
            // Eğer login service null döndürdüyse Postman’den gelen değeri koru
            if (string.IsNullOrEmpty(_loginServices.GetUserId) == false)
            {
                basketTotalDto.UserId = _loginServices.GetUserId;
            }

            await _basketService.SaveBasket(basketTotalDto);
            return Ok("Sepet başarıyla kaydedildi");
        }



    }
}
