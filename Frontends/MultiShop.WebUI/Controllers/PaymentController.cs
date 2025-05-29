using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.d1 = "MultiShop";
            ViewBag.d2 = "Ödeme Ekranı";
            ViewBag.d3 = "Kartla Ödeme";

            return View();
        }
    }
}
