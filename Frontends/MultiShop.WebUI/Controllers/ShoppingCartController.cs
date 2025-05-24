using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.BasketDtos;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBasketService _basketService;

        public ShoppingCartController(IProductService productService, IBasketService basketService)
        {
            _productService = productService;
            _basketService = basketService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.d1 = "Ana Sayfa";
            ViewBag.d2 = "Ürünler";
            ViewBag.d3 = "Sepetim";
            var values = await _basketService.GetBasket();
            return View(values);
        }

        public async Task<IActionResult> AddBasketItem(string Id)
        {
            var values = await _productService.GetByIdProductAsync(Id);
            var items = new BasketItemDto
            {
                ProductId = values.ProductId,
                ProductName = values.ProductName,
                Price = values.ProductPrice,
                Quantity = 1,
                ProductImageUrl = values.ProductImageUrl
            };
            await _basketService.AddBasketItem(items);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveBasketItem(string Id)
        {
            await _basketService.RemoveBasketItem(Id);
            return RedirectToAction("Index");
        }
    }
}
