using ETrade.Catalog.Dtos.CategoryDtos;

namespace ETrade.Catalog.Services.CategoryServices
{
    public interface ICategoryServices
    {
        Task<List<ResultCategoryDto>> GetResultCategoryAsync();
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task DeleteCategoryAsync(string id);
        Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id);

    }
}
