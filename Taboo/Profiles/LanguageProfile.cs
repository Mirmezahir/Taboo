using AutoMapper;
using Taboo.DTOs;
using Taboo.DTOs.LanguageDTO;
using Taboo.Entities;

namespace Taboo.Profiles
{
    public class LanguageProfile : Profile
    {
        public LanguageProfile()
        {
            CreateMap<LanguageCreateDto, Language>();
            CreateMap<Language, LanguageGetDto>();
            CreateMap<LanguageUpdateDto, Language>();
        }
    }
}
