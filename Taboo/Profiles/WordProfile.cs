using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Taboo.DTOs.WordDTO;
using Taboo.Entities;

namespace Taboo.Profiles
{
    public class WordProfile:Profile
    {
        public WordProfile()
        {
            CreateMap<WordCreateDto, Word>();
            CreateMap<Word, WordGetDto>();
            CreateMap<WordUpdateDto, Word>();
        }
    }
}
