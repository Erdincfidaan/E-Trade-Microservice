using AutoMapper;
using ETrade.Catalog.Dtos.ProductDtos;
using ETrade.Catalog.Entities;
using ETrade.Catalog.Settings;
using MongoDB.Driver;

namespace ETrade.Catalog.Services.ProductServices
{
    public class ProductServices : IProductService
    {
        private readonly IMongoCollection<Product> _productcollection;
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Category> _categoryCollection;

        public ProductServices(IMapper mapper,IDatabaseSettings databaseSettings)
        {
            
            var client= new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productcollection= database.GetCollection<Product>(databaseSettings.ProductCollectionName);
            _mapper = mapper;
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
        }
        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var value = _mapper.Map<Product>(createProductDto);
            await _productcollection.InsertOneAsync(value);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _productcollection.DeleteOneAsync(x => id == x.ProductId);
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            var value = await _productcollection.Find<Product>(x=> x.ProductId == id).FirstOrDefaultAsync();
            return  _mapper.Map<GetByIdProductDto>(value);
        }

        public async Task<List<ResultProductDto>> GetResultProductAsync()
        {
            var value = await _productcollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(value);
        }

        public async Task<List<ResultProductsWithCategoryDto>> GetResultProductsWithCategories()
        {
           var values= await _productcollection.Find(x=>true).ToListAsync();
            foreach(var item in values)
            {
                item.Category=await _categoryCollection.Find<Category>(x=> x.CategoryID == item.CategoryId).FirstAsync();
            }
            return _mapper.Map<List<ResultProductsWithCategoryDto>>(values);
        }

        public async Task<List<ResultProductsWithCategoryDto>> GetResultProductWithCategoryByCategoryId(string categoryId)
        {
            var values = await _productcollection.Find(x => x.CategoryId == categoryId).ToListAsync();
            foreach (var item in values)
            {
                item.Category = await _categoryCollection.Find<Category>(x => x.CategoryID == item.CategoryId).FirstAsync();
            }
            return _mapper.Map<List<ResultProductsWithCategoryDto>>(values);

        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var value = _mapper.Map<Product>(updateProductDto);
            await _productcollection.FindOneAndReplaceAsync(x => x.ProductId == updateProductDto.ProductId, value);
        }
    }
}
