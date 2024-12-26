using AutoMapper;
using Taboo.DTOs.GameDto;
using Taboo.Entities;

namespace Taboo.Profiles
{
    public class GameProfile: Profile
    {
       public GameProfile() {
           
            CreateMap<GameCreateDto, Game>();
         
        }
    }
}
