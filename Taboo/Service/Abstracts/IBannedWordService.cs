using Taboo.DTOs.BannedWordDTO;

namespace Taboo.Service.Abstracts
{
    public interface IBannedWordService
    {
        public Task<IEnumerable<BannedWordGetDto>> GetAsync();
        public Task CreateAsync(BannedWordCreateDto dto);
        public Task<Boolean> DeleteAsync(BannedWordDeleteDto dto);
        public Task<Boolean> UpdateAsync(BannedWordUpdateDto dto);
    }
}
