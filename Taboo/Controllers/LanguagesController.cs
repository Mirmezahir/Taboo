using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taboo.DTOs;
using Taboo.DTOs.LanguageDTO;
using Taboo.Entities;
using Taboo.Exceptions;
using Taboo.Service.Abstracts;

namespace Taboo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController(ILAnguageService _service, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return Ok(await _service.GetAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Create(LanguageCreateDto dto)
        {


            var data = _mapper.Map<Language>(dto);
            await _service.CreateAsync(dto);
            return Ok();
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(LanguageDeleteDto dto)
        {
            bool result = await _service.DeleteAsync(dto);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }
        [HttpPut]
        public async Task<IActionResult> Update(LanguageUpdateDto dto)
        {
            bool result = await _service.UpdateAsync(dto);
            if (result)
            {
                return Ok();

            }
            return NotFound();
        }



    }
}
