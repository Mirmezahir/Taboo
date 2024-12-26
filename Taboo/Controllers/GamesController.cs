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

        [HttpPost]
        public async Task<IActionResult> Create(GameCreateDto dto)
        {
           
         
            return Ok( await _service.CreateAsync(dto));
        }
        [HttpPut]
        public async Task<IActionResult> Start(Guid id)
        {
                     
           return Ok(await _service.StartAsync(id));

        }

        [HttpGet]
        public async Task<IActionResult> Skip(Guid id)
        {
            return Ok(_service.Skip(id));
        }
    }
}
