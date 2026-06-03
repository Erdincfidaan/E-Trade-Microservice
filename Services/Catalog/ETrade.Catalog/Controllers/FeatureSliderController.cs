using ETrade.Catalog.Dtos.CategoryDtos;
using ETrade.Catalog.Dtos.FeatureSlidersDtos;
using ETrade.Catalog.Services.FeatureSliderService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.Catalog.Controllers
{
    [AllowAnonymous]
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureSliderController : ControllerBase
    {
        private readonly IFeatureSliderServices _featureSliderServices;
        public FeatureSliderController(IFeatureSliderServices featureSliderServices)
        {
            _featureSliderServices = featureSliderServices;
        }

        [HttpGet]
        public async Task<IActionResult> FeatureSlidersList()
        {
            var values = await _featureSliderServices.GetAllFeatureSliderslAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> FeatureSliderGetById(string id)
        {
            var values = await _featureSliderServices.GetByIdFeatureSlidersAsync(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> FeatureSlidersAdd(CreateFeatureSlidersDto createFeatureSlidersDto)
        {
            await _featureSliderServices.CreateFeatureSlidersAsync(createFeatureSlidersDto);
            return Ok("İşlem Başarılı");

        }
        [HttpDelete]
        public async Task<IActionResult> FeatureSlidersDelete(string id)
        {
            await _featureSliderServices.DeleteFeatureSlidersAsync(id);
            return Ok("İşlem Başarılı");
        }
        [HttpPut]
        public async Task<IActionResult> FeatureSlidersUpdate(UpdateFeatureSlidersDto updateFeatureSlidersDto)
        {
            await _featureSliderServices.UpdateFeatureSlidersAsync(updateFeatureSlidersDto);
            return Ok("İşlem Başarılı");
        }

    }
}
