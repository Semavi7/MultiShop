using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.OrderDtos.OrderAddressDtos;
using MultiShop.WebUI.Services.Interface;
using MultiShop.WebUI.Services.OrderServices.AddressServices;

namespace MultiShop.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAddressService _addressService;
        private readonly IUserService _userService;

        public OrderController(IAddressService addressService, IUserService userService)
        {
            _addressService = addressService;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.d1 = "MultiShop";
            ViewBag.d2 = "Siparişler";
            ViewBag.d3 = "Sipariş İşlemleri";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateAddressDto createAddressDto)
        {
            var values = await _userService.GetUserInfo();
            createAddressDto.UserId = values.Id;

            await _addressService.CreateAddressAsync(createAddressDto);

            return RedirectToAction("Index", "Payment");
        }
    }
}
