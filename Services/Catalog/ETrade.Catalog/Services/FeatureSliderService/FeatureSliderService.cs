using AutoMapper;
using ETrade.Catalog.Dtos.FeatureSlidersDtos;
using ETrade.Catalog.Entities;
using ETrade.Catalog.Settings;
using MongoDB.Driver;
using System.Runtime.InteropServices;

namespace ETrade.Catalog.Services.FeatureSliderService
{
    public class FeatureSliderService : IFeatureSliderServices
    {
        private readonly IMongoCollection<FeatureSlider> _featuresliders;
        private readonly IMapper _mapper;
        public FeatureSliderService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _featuresliders = database.GetCollection<FeatureSlider>(databaseSettings.FeatureSliderCollectionName);
            _mapper = mapper;
        }
        public async Task CreateFeatureSlidersAsync(CreateFeatureSlidersDto createFeatureSlidersDto)
        {
            var value = _mapper.Map<FeatureSlider>(createFeatureSlidersDto);
            await _featuresliders.InsertOneAsync(value);
        }

        public async Task DeleteFeatureSlidersAsync(string id)
        {
            await _featuresliders.DeleteOneAsync(x => id == x.FeatureSliderId);
        }

        public Task FeaturesSliderChangeStatusToFalseAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task FeaturesSliderChangeStatusToTrueAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<GetByIdFeatureSlidersDto> GetByIdFeatureSlidersAsync(string id)
        {
            var result = await _featuresliders.Find<FeatureSlider>(x => x.FeatureSliderId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdFeatureSlidersDto>(result);

        }

        public async Task<List<ResultFeatureSlidersDto>> GetAllFeatureSliderslAsync()
        {
            var result =  await _featuresliders.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultFeatureSlidersDto>>(result);
        }

        public async Task UpdateFeatureSlidersAsync(UpdateFeatureSlidersDto updateFeatureSlidersDto)
        {
           var value = _mapper.Map<FeatureSlider>(updateFeatureSlidersDto);
            await _featuresliders.FindOneAndReplaceAsync(x => x.FeatureSliderId == updateFeatureSlidersDto.FeatureSliderId, value);
        }
    }
}
