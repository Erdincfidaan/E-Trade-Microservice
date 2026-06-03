using ETrade.Catalog.Dtos.AboutDtos;
using ETrade.Catalog.Services.AboutServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.Catalog.Controllers
{
    //[Authorize]
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }
        [HttpGet]
        public async Task<IActionResult> AboutList()
        {
            var values = await _aboutService.GetResultAboutAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> AboutGetById(string id)
        {
            var values = await _aboutService.GetByIdAboutAsync(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> AboutAdd(CreateAboutDto createAboutDto)
        {
            await _aboutService.CreateAboutAsync(createAboutDto);
            return Ok("İşlem Başarılı");
        }
        [HttpDelete]
        public async Task<IActionResult> AboutDelete(string id)
        {
            await _aboutService.DeleteAboutAsync(id);
            return Ok("İşlem Başarılı");
        }
        [HttpPut]
        public async Task<IActionResult> AboutUpdate(UpdateAboutDto updateAboutDto)
        {
            await _aboutService.UpdateAboutAsync(updateAboutDto);
            return Ok("İşlem Başarılı");
        }

    }
}
