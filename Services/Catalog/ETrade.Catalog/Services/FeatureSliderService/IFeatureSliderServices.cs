using ETrade.Catalog.Dtos.FeatureSlidersDtos;

namespace ETrade.Catalog.Services.FeatureSliderService
{
    public interface IFeatureSliderServices
    {
        Task<List<ResultFeatureSlidersDto>> GetAllFeatureSliderslAsync();
        Task CreateFeatureSlidersAsync(CreateFeatureSlidersDto createFeatureSlidersDto);
        Task UpdateFeatureSlidersAsync(UpdateFeatureSlidersDto updateFeatureSlidersDto);
        Task DeleteFeatureSlidersAsync(string id);
        Task<GetByIdFeatureSlidersDto> GetByIdFeatureSlidersAsync(string id);
        Task FeaturesSliderChangeStatusToTrueAsync(string id);
        Task FeaturesSliderChangeStatusToFalseAsync(string id);
    }
}
