using ETrade.Catalog.Dtos.ProductImageDtos;
using ETrade.Catalog.Services.ProductImagesServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.Catalog.Controllers
{
    [AllowAnonymous]
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageServices _Imagedetail;
        public ProductImagesController(IProductImageServices productImageServices)
        {
            _Imagedetail = productImageServices;
        }
        [HttpGet]
        public async Task<IActionResult> ProductImageList()
        {
            var values = await _Imagedetail.GetResultProductImageAsync();
            return Ok(values);
        }
        [HttpGet("ProductImagesByProductId")]
        public async Task<IActionResult> ProductImagesByProductId(string id)
        {
            var values = await _Imagedetail.GetByProductIdProductImageAsync(id);
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> ProductImageGetById(string id)
        {
            var values = await _Imagedetail.GetByIdProductImageAsync(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> ProductImageAdd(CreateProductImageDto createProductImageDto)
        {
            await _Imagedetail.CreateProductImageAsync(createProductImageDto);
            return Ok("İşlem Başarılı");
        }
        [HttpPut]
        public async Task<IActionResult> ProductImageUpdate(UpdateProductImageDto updateProductImageDto)
        {
            await _Imagedetail.UpdateProductImageAsync(updateProductImageDto);
            return Ok("İşlem Başarılı");
        }
        [HttpDelete]
        public async Task<IActionResult> ProductImageDelete(string id)
        {
            await _Imagedetail.DeleteProductImageAsync(id);
            return Ok("İşlem Başarılı");
        }
    }
}
