using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductImageController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductImageController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        //[Route("UpdateCategory/{id}")]
        public async Task<IActionResult> ProductImageDetail(string id)
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Görsel Güncelleme Sayfası";
            ViewBag.v4 = "Ürün Görsel İşlemleri";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7232/api/ProductImages/ProductImageByProductId?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateProductImageDto>(jsondata);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        //[Route("UpdateCategory/{id}")]
        public async Task<IActionResult> ProductImageDetail(UpdateProductImageDto updateProductImageDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateProductImageDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7232/api/ProductImages", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
            }
            return View();
        }
    }
}
