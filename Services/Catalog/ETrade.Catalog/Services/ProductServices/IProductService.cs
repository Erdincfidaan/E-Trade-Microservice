using ETrade.Catalog.Dtos.ProductDtos;

namespace ETrade.Catalog.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetResultProductAsync();
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(string id);
        Task <GetByIdProductDto> GetByIdProductAsync(string id);

        Task<List<ResultProductsWithCategoryDto>> GetResultProductsWithCategories();

        Task <List<ResultProductsWithCategoryDto>>GetResultProductWithCategoryByCategoryId(string categoryId);
    }
}
