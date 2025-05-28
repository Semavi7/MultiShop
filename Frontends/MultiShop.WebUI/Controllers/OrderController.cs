using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.d1 = "MultiShop";
            ViewBag.d2 = "Siparişler";
            ViewBag.d3 = "Sipariş İşlemleri";

            return View();
        }
    }
}
