using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taboo.DAL;
using Taboo.DTOs;
using Taboo.DTOs.LanguageDTO;
using Taboo.Entities;
using Taboo.Exceptions.Languages;
using Taboo.Service.Abstracts;

namespace Taboo.Service.Implements
{
    public class LanguageService(TaboDbContex _context,IMapper _mapper) : ILAnguageService
    {
        async Task ILAnguageService.CreateAsync(LanguageCreateDto dto)
        {
            if (await _context.Languages.AnyAsync(x => x.Code.ToUpper() == dto.Code.ToUpper()))
                throw new LanguageExistExceptions();
            dto.Name = dto.Name.ToUpper();
            await _context.Languages.AddAsync(_mapper.Map<Language>(dto)) ;
           await _context.SaveChangesAsync();
        }

        async Task<Boolean> ILAnguageService.DeleteAsync(LanguageDeleteDto dto)
        {
            Boolean result = false;
            var data = await _context.Languages.FirstOrDefaultAsync(x => x.Code == dto.Code);
            if (data != null)
            {
               _context.Languages.Remove(data);
               await _context.SaveChangesAsync();
               result = true;   
               return result;
            }
            return result;  
           
        }

        async  Task<IEnumerable<LanguageGetDto>> ILAnguageService.GetAsync()
        {
           var datas = await _context.Languages.ToListAsync();
            return _mapper.Map<IEnumerable<LanguageGetDto>>(datas);


        }

       async Task<Boolean> ILAnguageService.UpdateAsync(LanguageUpdateDto dto)
        {
           Boolean result = false;
            var data =await _context.Languages.FirstOrDefaultAsync(x=> x.Code == dto.Code);
            if (data != null)
            {
               
                data.Code = dto.Code;   
                data.Name = dto.Name;
                data.Icon = dto.Icon;
               await _context.SaveChangesAsync();
                result = true; return result;
            }
            return result;

        }
    }
}
