using AutoMapper;
using ETrade.Catalog.Dtos.CategoryDtos;
using ETrade.Catalog.Dtos.ProductDetailDtos;
using ETrade.Catalog.Entities;
using ETrade.Catalog.Settings;
using MongoDB.Driver;

namespace ETrade.Catalog.Services.ProductDetailsServices
{
    public class ProductDetailServices : IProductDetailServices
    {
        private readonly IMongoCollection<ProductDetail> _productDetailCollection;
        private readonly IMapper _mapper;

        public ProductDetailServices(IMapper mapper, IDatabaseSettings _databaseSettings)
        {

            var client = new MongoClient(_databaseSettings.ConnectionString); //constring ile mongodbye bağlanıyor
            var database = client.GetDatabase(_databaseSettings.DatabaseName);//mongodbde veritabanı seçiliyor
            _productDetailCollection = database.GetCollection<ProductDetail>(_databaseSettings.ProductDetailCollectionName);//seçilen veritabanında categorycollectionu ele alınıyor
            _mapper = mapper;
        }
        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            var value = _mapper.Map<ProductDetail>(createProductDetailDto);
            await _productDetailCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await _productDetailCollection.DeleteOneAsync(x => id == x.ProductDetailId);

        }

        public async Task<GetByIdProductDetailDto> GetByProductDetailByProductIdAsync(string id)
        {
            var values = await _productDetailCollection.Find<ProductDetail>(x => x.ProductDetailId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDetailDto>(values);
        }

        public async Task<GetByIdProductDetailDto> GetByProductIdProductDetailAsync(string id)
        {
            var values = await _productDetailCollection.Find<ProductDetail>(x => x.ProductId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDetailDto>(values);

        }

        public async Task<List<ResultProductDetailDto>> GetResultProductDetailAsync()
        {
            var value = await _productDetailCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDetailDto>>(value);
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            var values = _mapper.Map<ProductDetail>(updateProductDetailDto);
            await _productDetailCollection.FindOneAndReplaceAsync(x => x.ProductDetailId ==  updateProductDetailDto.ProductDetailId, values);
        }
    }
}
