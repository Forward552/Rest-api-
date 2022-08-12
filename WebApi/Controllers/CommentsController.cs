using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.Dto;
using Application.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentServise;
        public CommentsController(ICommentService commentService)
        {
            _commentServise = commentService;
        }
        [SwaggerOperation(Summary = "pobieramy wszystkie komentarze")]
        [HttpGet]
        public IActionResult Get()
        {
            var comments = _commentServise.GetAllComments();
            return Ok(comments);
        }

        [SwaggerOperation(Summary = "Zwraca komentarz o podanym id")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var comments = _commentServise.GetCommentByIdComments(id);
            if (comments == null)
            {
                return NotFound();
            }
            return Ok(comments);
        }

        [SwaggerOperation(Summary = "Pobierz wszystkie komentarze do danego posta po jego id.")]
        [HttpGet("{idPost}")]
        public IActionResult GetByPost(int idPost)
        {
            var comment = _commentServise.GetCommentByIdPost(idPost);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment);
        }

        [SwaggerOperation(Summary = "Tworzenie nowego Komentarza")]
        [HttpPost]
        public IActionResult CreateComment(CreateCommentDto create)
        {
            var comment = _commentServise.NewComment(create);
            if (comment.PostId == 0)
            {
                return NotFound();
            }
            return Created($"api/comments/{comment.Id}", comment);
        }

        [SwaggerOperation(Summary = "Aktualizuje istniejący komentarz")]
        [HttpPut]
        public IActionResult Update(UpdateCommentsDto updateComments)
        {
            _commentServise.Update(updateComments);
            return NoContent();
        }

        [SwaggerOperation(Summary = "Kasowanie Komentarza po id")]
        [HttpDelete("id")]
        public IActionResult DeleteComment (int id)
        {
            _commentServise.DeleteComment(id);
            return NoContent();
        }

      





    }
}
