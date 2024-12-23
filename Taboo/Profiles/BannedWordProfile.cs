using AutoMapper;
using Taboo.DTOs.BannedWordDTO;
using Taboo.Entities;

namespace Taboo.Profiles
{
    public class BannedWordProfile:Profile
    {
        public BannedWordProfile()
        {
            CreateMap<BannedWordCreateDto, BannedWord>();
            CreateMap<BannedWord, BannedWordGetDto>();
            CreateMap<BannedWordUpdateDto, BannedWord>();
        }
    }
}
