using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.Interface;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    public class TestController : Controller
    {
        private readonly IUserService _userService;

        public TestController(IUserService userService)
        {
            _userService = userService;
        }

        [Area("Admin")]
        public async Task<IActionResult> Index()
        {
            var user = await _userService.GetUserInfo();
            ViewBag.User = user;
            return View();
        }
    }
}
