using ETrade.Catalog.Dtos.CategoryDtos;
using ETrade.Catalog.Dtos.ProductDetailDtos;

namespace ETrade.Catalog.Services.ProductDetailsServices
{
    public interface IProductDetailServices
    {
        Task<List<ResultProductDetailDto>> GetResultProductDetailAsync();
        Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);
        Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);
        Task DeleteProductDetailAsync(string id);
        Task<GetByIdProductDetailDto> GetByProductDetailByProductIdAsync(string id);
        Task<GetByIdProductDetailDto> GetByProductIdProductDetailAsync(string id);
    }
}
