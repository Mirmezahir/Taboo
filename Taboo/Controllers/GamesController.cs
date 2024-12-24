using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Taboo.DTOs.GameDto;
using Taboo.Service.Abstracts;

namespace Taboo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController(IGameService _service) : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> Create(GameCreateDto dto)
        {
           var data = await _service.CreateAsync(dto);
           await _service.StartAsync(data);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Start(Guid id)
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
