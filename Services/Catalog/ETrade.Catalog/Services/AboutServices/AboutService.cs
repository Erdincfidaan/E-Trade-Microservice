using AutoMapper;
using ETrade.Catalog.Dtos.AboutDtos;
using ETrade.Catalog.Entities;
using ETrade.Catalog.Settings;
using MongoDB.Driver;

namespace ETrade.Catalog.Services.AboutServices
{
    public class AboutService : IAboutService
    {
        private readonly IMongoCollection<About>  _aboutCollection;
        private readonly IMapper _mapper;
        public AboutService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString); //constring ile mongodbye bağlanıyor
            var database = client.GetDatabase(_databaseSettings.DatabaseName);//mongodbde veritabanı seçiliyor
            _aboutCollection = database.GetCollection<About>(_databaseSettings.AboutCollectionName);//seçilen veritabanında aboutcollectionu ele alınıyor
            _mapper = mapper;
        }
        public async Task CreateAboutAsync(CreateAboutDto createAboutDto)
        {
            var values = _mapper.Map<About>(createAboutDto);
            await _aboutCollection.InsertOneAsync(values);
        }

        public async Task DeleteAboutAsync(string id)
        {
            await _aboutCollection.DeleteOneAsync(x => id == x.AboutId);

        }

        public async Task<GetByIdAboutDto> GetByIdAboutAsync(string id)
        {
            var result = await _aboutCollection.Find<About>(x => x.AboutId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdAboutDto>(result);
        }

        public async Task<List<ResultAboutDto>> GetResultAboutAsync()
        {
            var result = await _aboutCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultAboutDto>>(result);
        }

        public async Task UpdateAboutAsync(UpdateAboutDto updateAboutDto)
        {
            var values = _mapper.Map<About>(updateAboutDto);
             await _aboutCollection.FindOneAndReplaceAsync(x => x.AboutId == updateAboutDto.AboutId, values);
        }
    }
}
