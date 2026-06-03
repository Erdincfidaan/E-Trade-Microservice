using ETrade.Catalog.Dtos.ProductDtos;
using ETrade.Catalog.Services.CategoryServices;
using ETrade.Catalog.Services.ProductServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.Catalog.Controllers
{
    [AllowAnonymous]
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productServices;
        public ProductController(IProductService productServices)
        {
            _productServices = productServices;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var values = await _productServices.GetResultProductAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> ProductGetById(string id)
        {
            var values = await _productServices.GetByIdProductAsync(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> ProductAdd(CreateProductDto createProductDto)
        {
            await _productServices.CreateProductAsync(createProductDto);
            return Ok("İşlem Başarılı");
        }
        [HttpPut]
        public async Task<IActionResult> ProductUpdate(UpdateProductDto updateProductDto)
        {
            await _productServices.UpdateProductAsync(updateProductDto);
            return Ok("İşlem Başarılı");
        }
        [HttpDelete]
        public async  Task<IActionResult> ProductDelete(string id)
        {
            await _productServices.DeleteProductAsync(id);
            return Ok("İşlem Başarılı");
        }
        [HttpGet("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory()
        {
            var values = await _productServices.GetResultProductsWithCategories();
            return Ok(values);

        }
        [HttpGet("ProductListWithCategoryByCategoryId")]
        public async Task<IActionResult> ProductListWithCategoryByCategoryId(string categoryId)
        {
            var values = await _productServices.GetResultProductWithCategoryByCategoryId(categoryId);
            return Ok(values);
        }

    }
}
