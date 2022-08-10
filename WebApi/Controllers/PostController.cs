using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService; 
        public PostController(IPostService postService)
        {
            _postService = postService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var posts = _postService.GetAllPosts();
            return Ok(posts);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var post = _postService.GetPostById(id);
            if (post == null)
                return NotFound();
            return Ok(post);       

        }
    }
}
