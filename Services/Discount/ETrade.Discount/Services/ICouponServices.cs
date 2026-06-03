using ETrade.Discount.Dtos;

namespace ETrade.Discount.Services
{
    public interface ICouponServices
    {
        Task<List<ResultCouponDto>> GetAllCoupons();
        Task CreateCoupon(CreateCouponDto createCouponDto);
        Task UpdateCoupon(UpdateCouponDto updateCouponDto);
        Task<GetByIdCouponDto> GetByIdCoupon(int id);
        Task DeleteCoupon(int id);
    }
}
