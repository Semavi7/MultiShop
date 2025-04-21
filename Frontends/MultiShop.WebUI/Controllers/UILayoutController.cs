using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult UILayout()
        {
            return View();
        }
    }
}
