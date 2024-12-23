using Microsoft.AspNetCore.Mvc;
using Taboo.DTOs;
using Taboo.DTOs.LanguageDTO;

namespace Taboo.Service.Abstracts
{
    public interface ILAnguageService
    {
        public Task<IEnumerable<LanguageGetDto>> GetAsync();
        public Task CreateAsync(LanguageCreateDto dto);
        public Task<Boolean> DeleteAsync(LanguageDeleteDto dto);
        public Task<Boolean> UpdateAsync(LanguageUpdateDto dto);
    }
}
