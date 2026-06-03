using AutoMapper;
using ETrade.Catalog.Dtos.ProductImageDtos;
using ETrade.Catalog.Entities;
using ETrade.Catalog.Settings;
using MongoDB.Driver;

namespace ETrade.Catalog.Services.ProductImagesServices
{
    public class ProductImageServices : IProductImageServices
    {
        private readonly IMongoCollection<ProductImages> _productImageCollection;
        private readonly IMapper _mapper;

        public ProductImageServices(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString); // MongoDB'ye bağlan
            var database = client.GetDatabase(databaseSettings.DatabaseName); // Veritabanını seç
            _productImageCollection = database.GetCollection<ProductImages>(databaseSettings.ProductImageCollectionName); // Collection'ı al
            _mapper = mapper;
        }

        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            var value = _mapper.Map<ProductImages>(createProductImageDto);
            await _productImageCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductImageAsync(string id)
        {
            await _productImageCollection.DeleteOneAsync(x => x.ProductImagesID == id);
        }

        public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id)
        {
            var values = await _productImageCollection.Find<ProductImages>(x => x.ProductImagesID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductImageDto>(values);
        }

        public async Task<GetByIdProductImageDto> GetByProductIdProductImageAsync(string id)
        {
            var value = await _productImageCollection.Find(x => x.ProductId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductImageDto>(value);
        }

        public async Task<List<ResultProductImageDto>> GetResultProductImageAsync()
        {
            var value = await _productImageCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductImageDto>>(value);
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            var values = _mapper.Map<ProductImages>(updateProductImageDto);
            await _productImageCollection.FindOneAndReplaceAsync(x => x.ProductImagesID == updateProductImageDto.ProductImagesID, values);
        }
    }
}
