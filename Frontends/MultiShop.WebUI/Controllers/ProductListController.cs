using System.Text;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentDtos;
using MultiShop.WebUI.Services.CommentServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Controllers
{
    public class ProductListController : Controller
    {
        private readonly ICommentService _commentService;

        public ProductListController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        public IActionResult Index(string id)
        {
            ViewBag.d1 = "Ana Sayfa";
            ViewBag.d2 = "Ürünler";
            ViewBag.d3 = "Ürün Listesi";
            ViewBag.i = id;
            return View();
        }

        public IActionResult ProductDetail(string id)
        {
            ViewBag.d1 = "Ana Sayfa";
            ViewBag.d2 = "Ürünler";
            ViewBag.d3 = "Ürün Detayları";
            ViewBag.x = id;
            return View();
        }

        [HttpGet]
        public PartialViewResult AddComment()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(CreateCommentDto createCommentDto)
        {
            createCommentDto.ImageUrl = "test";
            createCommentDto.CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            createCommentDto.Status = false;
            await _commentService.CreateCommentAsync(createCommentDto);
            return RedirectToAction("Index", "Default");
        }
    }
}
