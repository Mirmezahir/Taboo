using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Taboo.DTOs.WordDTO;
using Taboo.Exceptions;
using Taboo.Service.Abstracts;

namespace Taboo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordsController(IWordService _service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
    
            return Ok(await _service.GetAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Create(WordCreateDto dto)
        {
            try
            {
                 await _service.CreateAsync(dto);
                 return Ok(); 
  
            }
            catch (Exception ex)
            {

                if (ex is IBaseException bEx)
                {
                    return StatusCode(bEx.StatusCode, new
                    {
                        StatusCode = bEx.StatusCode,
                        Message = bEx.ErrorMessage
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        ex.Message,
                    });

                }
            }
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateMany(List<WordCreateDto> dto)
        {
            try
            {
                foreach (var item in dto)
                {
                    
                    await _service.CreateAsync(item);
                }
                return Ok();

            }
            catch (Exception ex)
            {

                if (ex is IBaseException bEx)
                {
                    return StatusCode(bEx.StatusCode, new
                    {
                        StatusCode = bEx.StatusCode,
                        Message = bEx.ErrorMessage
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        ex.Message,
                    });

                }
            }
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(WordDeleteDto dto) 
        {
            bool result = await _service.DeleteAsync(dto);
           
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(WordUpdateDto dto)
        {
            var result =await _service.UpdateAsync(dto);
            return Ok(result);
        } 

    }
}
