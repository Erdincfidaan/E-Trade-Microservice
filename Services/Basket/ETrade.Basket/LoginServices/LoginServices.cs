using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ETrade.Basket.LoginServices
{
    public class LoginServices : ILoginServices
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginServices(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            
        }

        public string GetUserId
        {
            get
            {
                var result = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                return result;//_httpContextAccessor.HttpContext?.User?.FindFirst("sub")?.Value;;
                    
            }
        }


    }
}
