using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.d1 = "MultiShop";
            ViewBag.d2 = "Ana Sayfa";
            ViewBag.d3 = "Ürün Listesi";
            return View();
        }
    }
}
