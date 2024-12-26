using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;
using Taboo.DAL;
using Taboo.DTOs.GameDto;
using Taboo.DTOs.WordDTO;
using Taboo.Entities;
using Taboo.Service.Abstracts;

namespace Taboo.Service.Implements
{
    public class GameService(IMapper _mapper, TaboDbContex _context, IMemoryCache _cache) : IGameService
    {
        async Task<Guid> IGameService.CreateAsync(GameCreateDto dto)
        {
            var game = _mapper.Map<Game>(dto);
            await _context.Games.AddAsync(game);
            await _context.SaveChangesAsync();
            return game.Id;
        }

        Task IGameService.End(Guid id)
        {
            throw new NotImplementedException();
        }

        Task IGameService.Fail(Guid id)
        {
            throw new NotImplementedException();
        }

    

        async Task<WordForGameDto> IGameService.Skip(Guid id)
        {
            var status = _getCurrentGame(id);
            if(status.Skip <= status.MaxSkipCount)
            {
                var currentWord =status.Words.Pop();
                status.Skip++;
                _cache.Set(id,status,TimeSpan.FromMinutes(5));
                return currentWord ;
            }
          
            return null;
        }

        async Task<WordForGameDto> IGameService.StartAsync(Guid id)
        {
            var data = await _context.Games.FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
            {
                throw new Exception();
            }
            IQueryable<Word> query = _context.Words.Where(x => x.LanguageCode == data.LanguageCode);
            var words =  await query.Select(x=> new WordForGameDto
            {
                Id = x.Id,
                 Text = x.Text,
                 BannedWord = x.BannedWords.Select(y=>y.Text).ToList()    
            }).ToListAsync();
            var randomWords = words.OrderBy(x => Guid.NewGuid()).Take(20).ToList();

            var wordstack = new Stack<WordForGameDto>(randomWords);
            WordForGameDto Currenword = wordstack.Pop();

            int time = data.Time;

            var dt = new GameStatusDto
            {
                Status = 0,
                Fail = 0,
                Skip = 0,
                Words = wordstack,
                UsedWordsId = words.Select(x => x.Id),
                MaxSkipCount = data.SkipCount
            };
            _cache.Set<GameStatusDto>(id, dt, TimeSpan.FromMinutes(20));
            return Currenword;
        }
        GameStatusDto _getCurrentGame(Guid id)
        {
            var result = _cache.Get<GameStatusDto>(id); 
            if (result == null) throw new Exception();
            return result;

        }



        Task IGameService.Succsess(Guid id)
        {

            throw new NotImplementedException();
        }

    }
}

