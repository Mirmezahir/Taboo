using Microsoft.AspNetCore.Mvc;

namespace Taboo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Create()
        {
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Start()
        {
            return Ok();
        }




        [HttpPut]
        public async Task<IActionResult> End()
        {
            return Ok();
        }
    }
}
