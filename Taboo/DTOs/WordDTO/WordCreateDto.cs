using Taboo.Entities;

namespace Taboo.DTOs.WordDTO
{
    public class WordCreateDto
    {
        public string Text { get; set; }
        public string LanguageCode { get; set; }
        public List<string> BannedWords { get; set;}
    }
}
