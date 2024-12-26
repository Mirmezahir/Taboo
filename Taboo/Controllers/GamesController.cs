using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Taboo.DTOs.GameDto;
using Taboo.Service.Abstracts;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Taboo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController(IGameService _service) : ControllerBase
    { 

        [HttpPost("[action]")]
        public async Task<IActionResult> Create(GameCreateDto dto)
        {
           
         
            return Ok( await _service.CreateAsync(dto));
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> Start(Guid id)
        {
                     
           return Ok(await _service.StartAsync(id));

        }
        [HttpGet("[action]")]
        public async Task<IActionResult> Skip(Guid id)
        {
            return Ok(await _service.Skip(id));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> Fail(Guid id)
        {
            await _service.Fail(id);
            return Ok();
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> Succes(Guid id)
        {
            await _service.Succsess(id);
            return Ok();
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> End(Guid id)
        {
            return Ok(await _service.End(id));
        }

    }
}
