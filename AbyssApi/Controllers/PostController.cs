using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AbyssApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : Controller
    {
        public IPostRepository _postRepository;

        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpGet("/posts")]
        public ActionResult<IEnumerable<Post>> Get()
        {
            IEnumerable<Post> posts = _postRepository.GetAll();
            return Ok(posts);
        }
    }
}

