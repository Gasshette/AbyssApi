using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AbyssApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeepsController : ControllerBase
    {
        public IDeepRepository _deepRepository;

        public DeepsController(IDeepRepository deepRepository)
        {
            _deepRepository = deepRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Deep>> Get()
        {
            IEnumerable<Deep> deeps = _deepRepository.GetAll();
            return Ok(deeps);
        }

        [HttpPost]
        public ActionResult<Deep> Post([FromBody] Deep post)
        {
            _deepRepository.Post(post);
            return Ok(post);
        }

        [HttpPut]
        public ActionResult<Deep> Put([FromBody] Deep put)
        {
            _deepRepository.Put(put);
            return Ok(put);
        }

        [HttpDelete("{id}")]
        public ActionResult<Deep> Delete(int id)
        {
            _deepRepository.Delete(id);
            return Ok();
        }
    }
}

