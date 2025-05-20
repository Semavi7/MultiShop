using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Route("Admin/Category")]
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IHttpClientFactory httpClientFactory, IProductService productService, ICategoryService categoryService)
        {
            _httpClientFactory = httpClientFactory;
            _productService = productService;
            _categoryService = categoryService;
        }

        void ProductViewbagList()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Listesi";
            ViewBag.v4 = "Ürün İşlemleri";
        }
        //[Route("Index")]
        public async Task<IActionResult> Index()
        {
            ProductViewbagList();
            var values = await _productService.GetAllProductAsync();
            return View(values);
        }

        //[Route("Index")]
        public async Task<IActionResult> ProductListWithCategory()
        {
            ProductViewbagList();
            var values = await _productService.GetPruductsWithCategoryAsync();
            return View(values);
        }

        [HttpGet]
        //[Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct()
        {
            ProductViewbagList();

            var values = await _categoryService.GetAllCategoryAsync();
            List<SelectListItem> categoryValues = (from x in values
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID
                                                   }).ToList();
            ViewBag.CategoryValues = categoryValues;
            return View();
        }

        [HttpPost]
        //[Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _productService.CreateProductAsync(createProductDto);
            return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
        }

        //[Route("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);
            return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
        }

        //[Route("UpdateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            ProductViewbagList();

            var values = await _categoryService.GetAllCategoryAsync();
            List<SelectListItem> categoryValues = (from x in values
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID
                                                   }).ToList();
            ViewBag.CategoryValues = categoryValues;

            var values1 = await _productService.GetByIdProductAsync(id);
            return View(values1);
        }

        [HttpPost]
        //[Route("UpdateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _productService.UpdateProductAsync(updateProductDto);
            return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });

        }
    }
}
