using System.Text;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.OfferDiscountDtos;
using MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Route("Admin/OfferDiscount")]
    public class OfferDiscountController : Controller
    {
        private readonly IOfferDiscountService _offerDiscountService;

        public OfferDiscountController(IOfferDiscountService offerDiscountService)
        {
            _offerDiscountService = offerDiscountService;
        }

        void OfferDiscountViewBagList()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "İndirim Teklifleri";
            ViewBag.v3 = "İndirim Teklifleri Listesi";
            ViewBag.v4 = "İndirim Teklifleri İşlemleri";
        }

        //[Route("Index")]
        public async Task<IActionResult> Index()
        {
            OfferDiscountViewBagList();
            var values = await _offerDiscountService.GetAllOfferDiscountAsync();
            return View(values);
        }

        [HttpGet]
        //[Route("CreateOfferDiscount")]
        public IActionResult CreateOfferDiscount()
        {
            OfferDiscountViewBagList();
            return View();
        }

        [HttpPost]
        //[Route("CreateOfferDiscount")]
        public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto createOfferDiscountDto)
        {
            await _offerDiscountService.CreateOfferDiscountAsync(createOfferDiscountDto);
            return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });

        }

        //[Route("DeleteOfferDiscount/{id}")]
        public async Task<IActionResult> DeleteOfferDiscount(string id)
        {
            await _offerDiscountService.DeleteOfferDiscountAsync(id);
            return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
        }

        //[Route("UpdateOfferDiscount/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateOfferDiscount(string id)
        {
            OfferDiscountViewBagList();
            var values = await _offerDiscountService.GetByIdOfferDiscountAsync(id);
            return View(values);
        }

        [HttpPost]
        //[Route("UpdateOfferDiscount/{id}")]
        public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            await _offerDiscountService.UpdateOfferDiscountAsync(updateOfferDiscountDto);
            return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
        }
    }
}
