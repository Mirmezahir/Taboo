using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Taboo.DAL;
using Taboo.DTOs.GameDto;
using Taboo.Entities;
using Taboo.Service.Abstracts;

namespace Taboo.Service.Implements
{
    public class GameService(IMapper _mapper, TaboDbContex _context, IMemoryCache _cache, IGameService _service) : IGameService
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

        Task IGameService.GetRandomWord()
        {
            throw new NotImplementedException();
        }

        Task IGameService.Skip(Guid id)
        {
            throw new NotImplementedException();
        }

      async Task<bool> IGameService.StartAsync(Guid id)
        {
          var data = await _context.Games.FirstOrDefaultAsync(x=> x.Id== id);
            if (data == null)
            {
                return false;
            }
            int time = data.Time;
            var dt = new GameStatusDto
            {

                Status = 0,
                Fail = 0,
                Skip = 0,
                Words = new Stack<Word>(),
                UsedWordsId = new int[0]

            };
           _cache.Set<GameStatusDto>("game", dt,TimeSpan.FromSeconds(time)) ;
            return true;
        }



    Task IGameService.Succsess(Guid id)
    {
        throw new NotImplementedException();
    }
}
}
