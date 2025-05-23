using System.Text;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentDtos;
using MultiShop.WebUI.Services.CommentServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Route("Admin/Comment")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        void CommentViewBagList()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Yorumlar";
            ViewBag.v3 = "Yorum Listesi Sayfası";
            ViewBag.v4 = "Yorum İşlemleri";
        }

        //[Route("Index")]
        public async Task<IActionResult> Index()
        {
            CommentViewBagList();
            var values = await _commentService.GetAllCommentAsync();
            return View(values);
        }

        [HttpGet]
        //[Route("CreateComment")]
        public IActionResult CreateComment()
        {
            CommentViewBagList();
            return View();
        }

        [HttpPost]
        //[Route("CreateComment")]
        public async Task<IActionResult> CreateComment(CreateCommentDto createCommentDto)
        {
            await _commentService.CreateCommentAsync(createCommentDto);
            return RedirectToAction("Index", "Comment", new { area = "Admin" });

        }

        //[Route("DeleteComment/{id}")]
        public async Task<IActionResult> DeleteComment(string id)
        {
            await _commentService.DeleteCommentAsync(id);
            return RedirectToAction("Index", "Comment", new { area = "Admin" });
        }

        //[Route("UpdateComment/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateComment(string id)
        {
            CommentViewBagList();
            var values = await _commentService.GetByIdCommentAsync(id);
            return View(values);
        }

        [HttpPost]
        //[Route("UpdateComment/{id}")]
        public async Task<IActionResult> UpdateComment(UpdateCommentDto updateCommentDto)
        {
            await _commentService.UpdateCommentAsync(updateCommentDto);
            return RedirectToAction("Index", "Comment", new { area = "Admin" });
        }
    }
}
