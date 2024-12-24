using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Taboo.DAL;
using Taboo.DTOs.WordDTO;
using Taboo.Entities;
using Taboo.Exceptions.Languages;
using Taboo.Exceptions.Words;
using Taboo.Service.Abstracts;

namespace Taboo.Service.Implements
{
    public class WordService(TaboDbContex _context,IMapper _mapper) : IWordService
    {
        async Task IWordService.CreateAsync(WordCreateDto dto)
        {
            
            if (!await _context.Languages.AnyAsync(x => x.Code.ToUpper() == dto.LanguageCode.ToUpper()))
                throw new WordLanguageNotFoundException();
            if (await _context.Words.AnyAsync(x => x.Text.ToUpper() == dto.Text.ToUpper()))
                throw new WordExistException();
            Word word = new Word
             { 
                Text = dto.Text,
                LanguageCode = dto.LanguageCode, 
                BannedWords = dto.BannedWords.Select(x=> new BannedWord
                {
                    Text= x
                }).ToList(),
            
            };
                
            await _context.Words.AddAsync(word );
            await _context.SaveChangesAsync();
        }

       async Task<bool> IWordService.DeleteAsync(WordDeleteDto dto)
        {
            var data = await _context.Words.FirstOrDefaultAsync(x => x.Text.ToUpper() == dto.Text.ToUpper());
            if (data != null)
            {
                _context.Words.Remove(data);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        async Task<IEnumerable<WordGetDto>> IWordService.GetAsync()
        {
           var datas = await _context.Words.ToListAsync();
            return _mapper.Map<IEnumerable<WordGetDto>>(datas);
        }

        async Task<bool> IWordService.UpdateAsync(WordUpdateDto dto)
        {
            var data = await _context.Words.FirstOrDefaultAsync(x=>x.Id==dto.Id);
            
            if (data != null)
            {
                //data =  _mapper.Map<Word>(dto) ; 
                data.Text = dto.Text;
                data.LanguageCode = dto.LanguageCode;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
