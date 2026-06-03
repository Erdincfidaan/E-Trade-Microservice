using ETrade.Catalog.Dtos.CategoryDtos;
using ETrade.Catalog.Services.CategoryServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.Catalog.Controllers
{

    //[Authorize]
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryServices _categoryServices;
        
        public CategoriesController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList() 
        {
            var values = await _categoryServices.GetResultCategoryAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> CategoryGetById(string id)
        {
            var values = await _categoryServices.GetByIdCategoryAsync(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CategoryAdd(CreateCategoryDto createCategoryDto)
        {
            await _categoryServices.CreateCategoryAsync(createCategoryDto);
            return Ok("İşlem Başarılı");

        }
        [HttpDelete]
        public async Task<IActionResult> CategoryDelete(string id)
        {
            await _categoryServices.DeleteCategoryAsync(id);
            return Ok("İşlem Başarılı");
        }
        [HttpPut]
        public async Task<IActionResult> CategoryUpdate(UpdateCategoryDto updateCategoryDto)
        {
            await _categoryServices.UpdateCategoryAsync(updateCategoryDto);
            return Ok("İşlem Başarılı");
        }
    }
}
