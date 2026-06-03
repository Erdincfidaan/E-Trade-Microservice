using Identity.Dtos;
using Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace Identity.Controllers
{
    [AllowAnonymous]
    //[Authorize(LocalApi.PolicyName)]
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegisterController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(UserRegisterDto userRegisterDto)
        {
            var values = new ApplicationUser()
            {
                UserName = userRegisterDto.Username,
                Email = userRegisterDto.Email,
                Name = userRegisterDto.Name,
                Surname = userRegisterDto.Surname,
            };

           var result= await _userManager.CreateAsync(values,userRegisterDto.Password);
            if (result.Succeeded)
            {
                return Ok("Kullanıcı Başarıyla Oluşturuldu");
            }
            else
            {
                return BadRequest(result.Errors);
            }

        }
    }
}
