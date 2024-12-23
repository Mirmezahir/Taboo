using Taboo.DTOs.LanguageDTO;
using Taboo.DTOs;
using Taboo.DTOs.WordDTO;

namespace Taboo.Service.Abstracts
{
    public interface IWordService
    {
        public Task<IEnumerable<WordGetDto>> GetAsync();
        public Task CreateAsync(WordCreateDto dto);
        public Task<Boolean> DeleteAsync(WordDeleteDto dto);
        public Task<Boolean> UpdateAsync(WordUpdateDto dto);
    }
}
