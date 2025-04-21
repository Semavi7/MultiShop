using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.DefaultComponents
{
    public class _CarouselDefaultComponentPertial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
