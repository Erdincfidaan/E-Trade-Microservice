using Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace Identity.Controllers
{
    [Authorize(LocalApi.PolicyName)]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public UsersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUser()
        {
            var userClaims = User.Claims.FirstOrDefault(x=> x.Type == JwtRegisteredClaimNames.Sub);   
            var user = await _userManager.FindByIdAsync(userClaims.Value);
            return Ok(new
            {
                Id = user.Id,
                UserName = user.UserName,
                Surname = user.Surname,
                Email = user.Email,
                Name = user.Name
            });
        }
    }
}
