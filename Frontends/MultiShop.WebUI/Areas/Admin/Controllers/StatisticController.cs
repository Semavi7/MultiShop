using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.StatisticServices.CatalogStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.CommentStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.DiscountStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.MessageStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.UserStatisticServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StatisticController : Controller
    {
        private readonly ICatalogStatisticService _catalogStatisticService;
        private readonly IUserStatisticService _userStatisticService;
        private readonly ICommentStatisticService _commentStatisticService;
        private readonly IDiscountStatisticService _discountStatisticService;
        private readonly IMessageStatisticService _messageStatisticService;

        public StatisticController(ICatalogStatisticService catalogStatisticService, IUserStatisticService userStatisticService, ICommentStatisticService commentStatisticService, IDiscountStatisticService discountStatisticService, IMessageStatisticService messageStatisticService)
        {
            _catalogStatisticService = catalogStatisticService;
            _userStatisticService = userStatisticService;
            _commentStatisticService = commentStatisticService;
            _discountStatisticService = discountStatisticService;
            _messageStatisticService = messageStatisticService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "İstatistikler";
            ViewBag.v3 = "İstatistik Listesi";
            ViewBag.v4 = "İstatistik İşlemleri";

            var BrandCount = await _catalogStatisticService.GetBrandCount();
            var CategoryCount = await _catalogStatisticService.GetCategoryCount();
            var ProductCount = await _catalogStatisticService.GetProductCount();
            var ProductAvgPrice = await _catalogStatisticService.GetProductAvgPrice();
            var MaxPriceProductName = await _catalogStatisticService.GetMaxPriceProductName();
            var MinPriceProductName = await _catalogStatisticService.GetMinPriceProductName();
            var UserCount = await _userStatisticService.GetUserCount();
            var TotalCommentCount = await _commentStatisticService.GetTotalCommentCount();
            var ActiveCommentCount = await _commentStatisticService.GetActiveCommentCount();
            var PassiveCommentCount = await _commentStatisticService.GetPassiveCommentCount();
            var DiscountCouponCount = await _discountStatisticService.GetDiscountCouponCount();
            var TotalMessageCount = await _messageStatisticService.GetTotalMessageCount();
            
            ViewBag.BrandCount = BrandCount;
            ViewBag.CategoryCount = CategoryCount;
            ViewBag.ProductCount = ProductCount;
            ViewBag.ProductAvgPrice = ProductAvgPrice;
            ViewBag.MaxPriceProductName = MaxPriceProductName;
            ViewBag.MinPriceProductName = MinPriceProductName;
            ViewBag.UserCount = UserCount;
            ViewBag.TotalCommentCount = TotalCommentCount;
            ViewBag.ActiveCommentCount = ActiveCommentCount;
            ViewBag.PassiveCommentCount = PassiveCommentCount;
            ViewBag.DiscountCouponCount = DiscountCouponCount;
            ViewBag.TotalMessageCount = TotalMessageCount;
            return View();
        }
    }
}
