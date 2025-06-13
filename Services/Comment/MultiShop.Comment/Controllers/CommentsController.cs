using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Comment.Context;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly CommentContext _commentContext;

        public CommentsController(CommentContext commentContext)
        {
            _commentContext = commentContext;
        }

        [HttpGet]
        public IActionResult CommentList()
        {
            var values = _commentContext.UserComments.ToList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            var values = _commentContext.UserComments.Find(id);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateComment(UserComment userComment)
        {
            _commentContext.UserComments.Add(userComment);
            _commentContext.SaveChanges();
            return Ok("Yorum başarıyla eklendi");
        }

        [HttpPut]
        public IActionResult UpdateComment(UserComment userComment)
        {
            _commentContext.UserComments.Update(userComment);
            _commentContext.SaveChanges();
            return Ok("Yorum başarı ile güncellendi");
        }

        [HttpDelete]
        public IActionResult DeleteComment(int id)
        {
            var values = _commentContext.UserComments.Find(id);
            _commentContext.UserComments.Remove(values);
            _commentContext.SaveChanges();
            return Ok("Yorum başarı ile silindi");
        }

        [HttpGet("CommentListByProductId/{id}")]
        public IActionResult CommentListByProductId(string id)
        {
            var values = _commentContext.UserComments.Where(x => x.ProductId == id).ToList();
            return Ok(values);
        }

        [HttpGet("GetActiveCommentCount")]
        public IActionResult GetActiveCommentCount()
        {
            int values = _commentContext.UserComments.Where(x => x.Status == true).Count();
            return Ok(values);
        }

        [HttpGet("GetPassiveCommentCount")]
        public IActionResult GetPassiveCommentCount()
        {
            int values = _commentContext.UserComments.Where(x => x.Status == false).Count();
            return Ok(values);
        }

        [AllowAnonymous]
        [HttpGet("GetTotalCommentCount")]
        public IActionResult GetTotalCommentCount()
        {
            var values = _commentContext.UserComments.Count();
            return Ok(values);
        }

    }
}
