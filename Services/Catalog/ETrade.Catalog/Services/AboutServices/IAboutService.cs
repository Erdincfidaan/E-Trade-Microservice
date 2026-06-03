using ETrade.Catalog.Dtos.AboutDtos;
using ETrade.Catalog.Dtos.AboutDtos;

namespace ETrade.Catalog.Services.AboutServices
{
    public interface IAboutService
    {
        Task<List<ResultAboutDto>> GetResultAboutAsync();
        Task CreateAboutAsync(CreateAboutDto createAboutDto);
        Task UpdateAboutAsync(UpdateAboutDto updateAboutDto);
        Task DeleteAboutAsync(string id);
        Task<GetByIdAboutDto> GetByIdAboutAsync(string id);
    }
}
