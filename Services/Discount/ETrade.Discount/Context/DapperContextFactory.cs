/*using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ETrade.Discount.Context
{
    public class DapperContextFactory : IDesignTimeDbContextFactory<DapperContext>
    {
        public DapperContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DapperContext>();

            optionsBuilder.UseSqlServer(
                "Server=DESKTOP-KN4VQMV\\SQLEXPRESS01;Initial Catalog=E-TradeDiscountdb;Integrated Security=True;TrustServerCertificate=True"
            );

            return new DapperContext(optionsBuilder.Options);
        }
    }
}
*/