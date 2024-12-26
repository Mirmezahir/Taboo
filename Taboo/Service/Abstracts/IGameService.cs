using Taboo.DTOs.GameDto;
using Taboo.DTOs.WordDTO;
using Taboo.Entities;

namespace Taboo.Service.Abstracts
{
    public interface IGameService
    {
        public Task<Guid> CreateAsync(GameCreateDto dto);
        public Task<WordForGameDto> StartAsync(Guid id);
    
        Task<WordForGameDto> Skip(Guid id);
        Task Fail(Guid id);
        Task End(Guid id);
        Task Succsess(Guid id); 

    }
}
