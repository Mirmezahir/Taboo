using Taboo.DTOs.GameDto;

namespace Taboo.Service.Abstracts
{
    public interface IGameService
    {
        public Task<Guid> CreateAsync(GameCreateDto dto);
        public Task<bool> StartAsync(Guid id);
        Task GetRandomWord();
        Task Skip(Guid id);
        Task Fail(Guid id);
        Task End(Guid id);
        Task Succsess(Guid id); 

    }
}
