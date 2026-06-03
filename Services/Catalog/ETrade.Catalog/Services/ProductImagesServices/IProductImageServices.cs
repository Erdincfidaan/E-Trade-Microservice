using ETrade.Catalog.Dtos.CategoryDtos;
using ETrade.Catalog.Dtos.ProductImageDtos;

namespace ETrade.Catalog.Services.ProductImagesServices
{
    public interface IProductImageServices
    {
        Task<List<ResultProductImageDto>> GetResultProductImageAsync();
        Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);
        Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);
        Task DeleteProductImageAsync(string id);
        Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id);
        Task <GetByIdProductImageDto> GetByProductIdProductImageAsync(string id);
    }
}
