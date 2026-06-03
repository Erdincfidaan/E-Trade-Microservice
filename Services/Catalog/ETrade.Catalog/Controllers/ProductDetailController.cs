using ETrade.Catalog.Dtos.ProductDetailDtos;
using ETrade.Catalog.Services.ProductDetailsServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.Catalog.Controllers
{
    [AllowAnonymous]
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailController : ControllerBase
    {
        private readonly IProductDetailServices _productDetailServices;
       public ProductDetailController(IProductDetailServices productDetailServices)
        {
            _productDetailServices = productDetailServices;
        }
        [HttpGet]
        public async Task<IActionResult> ProductDetailList()
        {
            var values = await _productDetailServices.GetResultProductDetailAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> ProductDetailGetById(string id)
        {
            var values = await _productDetailServices.GetByProductDetailByProductIdAsync(id);
            return Ok(values);
        }
        [HttpGet("GetProductDetailByProductId")]
        public async Task<IActionResult> GetProductDetailByProductId(string id)
        {
            var values = await _productDetailServices.GetByProductIdProductDetailAsync(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> ProductDetailAdd(CreateProductDetailDto createProductDetailDto)
        {
            await _productDetailServices.CreateProductDetailAsync(createProductDetailDto);
            return Ok("İşlem Başarılı");
        }
        [HttpPut]
        public async Task<IActionResult> ProductDetailUpdate(UpdateProductDetailDto updateProductDetailDto)
        {
            await _productDetailServices.UpdateProductDetailAsync(updateProductDetailDto);
            return Ok("İşlem Başarılı");
        }
        [HttpDelete]
        public async Task<IActionResult> ProductDetailDelete(string id)
        {
            await _productDetailServices.DeleteProductDetailAsync(id);
            return Ok("İşlem Başarılı");
        }
        

    }
}
