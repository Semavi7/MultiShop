using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.Interface;
using MultiShop.WebUI.Services.OrderServices.OrderingServices;

namespace MultiShop.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class MyOrderController : Controller
    {
        private readonly IOrderingServices _orderingServices;
        private readonly IUserService _userService;

        public MyOrderController(IOrderingServices orderingServices, IUserService userService)
        {
            _orderingServices = orderingServices;
            _userService = userService;
        }

        public async Task<IActionResult> MyOrderList()
        {
            var user = await _userService.GetUserInfo();
            var values = await _orderingServices.GetOrderingByUserId(user.Id);
            return View(values);
        }
    }
}
