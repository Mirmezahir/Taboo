using Taboo.Entities;

namespace Taboo.DTOs.GameDto
{
    public class GameStatusDto
    {
        public byte Status { get; set; }
        public byte Fail { get; set; }
        public byte Skip { get; set; }
        public Stack<Word> Words { get; set; }
        public int[] UsedWordsId { get; set; }  

    }
}
