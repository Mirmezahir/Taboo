using System.Reflection.Metadata.Ecma335;
using Taboo.DTOs.WordDTO;
using Taboo.Entities;

namespace Taboo.DTOs.GameDto
{
    public class GameStatusDto
    {
        public byte Status { get; set; }
        public byte Fail { get; set; }
        public byte Score { get; set; }
        public byte Skip { get; set; }
        public  int  MaxSkipCount { get; set; }
        public Stack<WordForGameDto> Words { get; set; }
        public IEnumerable<int> UsedWordsId { get; set; }  

    }
}
