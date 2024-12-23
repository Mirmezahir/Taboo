using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taboo.DAL;
using Taboo.DTOs.BannedWordDTO;
using Taboo.Entities;
using Taboo.Exceptions.BannedWords;
using Taboo.Service.Abstracts;

namespace Taboo.Service.Implements
{
    public class BannedWordService(TaboDbContex _context,IMapper _mapper) : IBannedWordService
    {
        async Task IBannedWordService.CreateAsync(BannedWordCreateDto dto)
        {
           if(await _context.BannedWords.AnyAsync(x=> x.Text==dto.Text))
             throw new BannedWordExistException();
            await _context.BannedWords.AddAsync(_mapper.Map<BannedWord>(dto));
           await _context.SaveChangesAsync();
        }

       async Task<bool> IBannedWordService.DeleteAsync(BannedWordDeleteDto dto)
        {
            var data = await _context.BannedWords.FirstOrDefaultAsync(x=>x.Text==dto.Text);
            if(data!=null)
            {
                _context.BannedWords.Remove(data);
                await _context.SaveChangesAsync();  
                return true;
            }
            return false ;
        }

       async Task<IEnumerable<BannedWordGetDto>> IBannedWordService.GetAsync()
        {
           var datas =await _context.BannedWords.ToListAsync();
            return _mapper.Map<IEnumerable<BannedWordGetDto>>(datas);
        }

       async Task<bool> IBannedWordService.UpdateAsync(BannedWordUpdateDto dto)
        {
           var data = _context.BannedWords.FirstOrDefault(x=>x.Text==dto.Text); 
           if(data!= null)
            {
                _mapper.Map<BannedWord>(dto);
                await _context.SaveChangesAsync();
                return true;
            }
           return false;    
        }
    }
}
