using ETrade.Discount.Context;
using ETrade.Discount.Dtos;
using Dapper;

namespace ETrade.Discount.Services
{
    public class CouponServices : ICouponServices
    {

        private readonly DapperContext _context;

        public CouponServices(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateCoupon(CreateCouponDto createCouponDto)
        {
            string query = "insert into Coupons(Code,Rate,IsActive,ValidDate) values (@code,@rate,@isactive,@validdate)";
            var parameters = new DynamicParameters();
            parameters.Add("@code", createCouponDto.Code);
            parameters.Add("@rate", createCouponDto.Rate);
            parameters.Add("@isActive", createCouponDto.IsActive);
            parameters.Add("@validDate", createCouponDto.ValidDate);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);

            }
        }

        public async Task DeleteCoupon(int id)
        {
            string query = "Delete From Coupons where CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", id);
            using (var connection = _context.CreateConnection())
            {
                {
                    await connection.ExecuteAsync(query, parameters);
                }
            }
        }

        public async Task<List<ResultCouponDto>> GetAllCoupons()
        {
            string query = "Select * From Coupons";
            using (var connection = _context.CreateConnection())
            {
                var values =await connection.QueryAsync<ResultCouponDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdCouponDto> GetByIdCoupon(int id)
        {
            string query = "Select * From Coupons Where CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", id);
            using(var  connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstAsync<GetByIdCouponDto>(query,parameters);
                return values;
            }

        }

        public async Task UpdateCoupon(UpdateCouponDto updateCouponDto)
        {
            string query = "Update Coupons Set Code=@code,Rate=@rate,IsActive=@isActive,ValidDate=@validDate,CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@code", updateCouponDto.Code);
            parameters.Add("@rate",updateCouponDto.Rate);
            parameters.Add("@isActive", updateCouponDto.IsActive);
            parameters.Add("@validDate",updateCouponDto.ValidDate);
            parameters.Add("@couponId",updateCouponDto.CouponId);
            using( var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }


        }
    }
}
