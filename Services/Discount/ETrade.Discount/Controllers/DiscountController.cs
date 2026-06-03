using ETrade.Discount.Dtos;
using ETrade.Discount.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.Discount.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly ICouponServices _couponServices;
        public DiscountController(ICouponServices couponServices)
        {
            _couponServices = couponServices;
        }
        [HttpGet]
        public async Task<IActionResult>CouponList()
        {
            var values= await _couponServices.GetAllCoupons();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> CouponGetById(int id)
        {
            var values= await _couponServices.GetByIdCoupon(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCoupon(CreateCouponDto createCouponDto)
        {
            await _couponServices.CreateCoupon(createCouponDto);
            return Ok("Kupon oluşturuldu");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCoupon(int id)
        {
            await _couponServices.DeleteCoupon(id);
            return Ok("Kupon başarıyla silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCoupon(UpdateCouponDto updateCouponDto)
        {
            await _couponServices.UpdateCoupon(updateCouponDto);
            return Ok("Kupon başarıyla güncellendi");

        }
    }
}
