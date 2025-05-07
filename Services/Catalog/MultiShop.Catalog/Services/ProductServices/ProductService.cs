using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.ProductDetailServices;
using MultiShop.Catalog.Services.ProductImageServices;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Product> _productsCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IProductImageService _productImageService;
        private readonly IProductDetailService _productDetailService;
        public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings, IProductImageService productImageService, IProductDetailService productDetailService)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productsCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _productImageService = productImageService;
            _productDetailService = productDetailService;
            _mapper = mapper;
        }
        
        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var values = _mapper.Map<Product>(createProductDto);
            await _productsCollection.InsertOneAsync(values);

            var productId = values.ProductId;

            var createProductImageDto = new CreateProductImageDto
            {
                ProductId = productId,
                Image1 = "Deneme",
                Image2 = "",
                Image3 = "",
                Image4 = ""
            };
            await _productImageService.CreateProductImageAsync(createProductImageDto);

            var createProductDetailDto = new CreateProductDetailDto
            {
                ProductId = productId,
                ProductDescription = "Deneme",
                ProductInfo = "",
            };
            await _productDetailService.CreateProductDetailAsync(createProductDetailDto);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _productsCollection.DeleteOneAsync(x => x.ProductId == id);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var values = await _productsCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(values);
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            var values = await _productsCollection.Find<Product>(x => x.ProductId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDto>(values);
        }

        public async Task<List<ResultProductsWithCategoryDto>> GetProductsWithCategoryByCategoryIdAsync(string CategoryId)
        {
            var values = await _productsCollection.Find(x => x.CategoryId == CategoryId).ToListAsync();
            foreach (var item in values)
            {
                item.Category = await _categoryCollection.Find<Category>(x => x.CategoryID == item.CategoryId).FirstAsync();
            }
            return _mapper.Map<List<ResultProductsWithCategoryDto>>(values);
        }

        public async Task<List<ResultProductsWithCategoryDto>> GetPruductsWithCategoryAsync()
        {
            var values = await _productsCollection.Find(x => true).ToListAsync();
            foreach(var item in values)
            {
                item.Category = await _categoryCollection.Find<Category>(x => x.CategoryID == item.CategoryId).FirstAsync();
            }
            return _mapper.Map<List<ResultProductsWithCategoryDto>>(values);
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var values = _mapper.Map<Product>(updateProductDto);
            await _productsCollection.FindOneAndReplaceAsync(x => x.ProductId == updateProductDto.ProductId, values);
        }
    }
}
