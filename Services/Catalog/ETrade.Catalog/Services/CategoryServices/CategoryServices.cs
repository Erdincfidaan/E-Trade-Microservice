using AutoMapper;
using ETrade.Catalog.Dtos.CategoryDtos;
using ETrade.Catalog.Entities;
using ETrade.Catalog.Settings;
using MongoDB.Driver;

namespace ETrade.Catalog.Services.CategoryServices
{
    public class CategoryServices : ICategoryServices
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryServices(IMapper mapper,IDatabaseSettings _databaseSettings)
        {
            
            var client  = new MongoClient(_databaseSettings.ConnectionString); //constring ile mongodbye bağlanıyor
            var database=client.GetDatabase(_databaseSettings.DatabaseName);//mongodbde veritabanı seçiliyor
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);//seçilen veritabanında categorycollectionu ele alınıyor
            _mapper = mapper;
        }
        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var value = _mapper.Map<Category>(createCategoryDto);
            await _categoryCollection.InsertOneAsync(value);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _categoryCollection.DeleteOneAsync(x=> id == x.CategoryID);
        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id)
        {
            var values = await _categoryCollection.Find<Category>(x=>x.CategoryID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdCategoryDto>(values);
        }

        public async Task<List<ResultCategoryDto>> GetResultCategoryAsync()
        {
            var value = await _categoryCollection.Find(x=>true).ToListAsync();
            return _mapper.Map<List<ResultCategoryDto>>(value);
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var values = _mapper.Map<Category>(updateCategoryDto);
            await _categoryCollection.FindOneAndReplaceAsync(x=>x.CategoryID == updateCategoryDto.CategoryID, values);
        }
    }
}
